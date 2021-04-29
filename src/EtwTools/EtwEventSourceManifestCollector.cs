using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace EtwTools
{
    /// <summary>
    /// Manages the manifests that EventSource source emit into events.
    /// </summary>
    public sealed class EtwEventSourceManifestCollector
    {
        private readonly Dictionary<(Guid Provider, uint Pid, uint Tid), Manifest> _manifests = new();

        /// <summary>
        /// Returns whether an event is an EventSource manifest event.
        /// </summary>
        /// <param name="e">The event.</param>
        /// <returns>Whether it is an EventSource manifest event.</returns>
        public static bool IsEventSourceManifestEvent(ref EtwEvent e) =>
            e.Descriptor.Id == 0xFFFE && e.Descriptor.Opcode == (EtwEventOpcode)0xFE && e.Descriptor.Task == 0xFFFE;

        /// <summary>
        /// Processes an EventSource manifest event.
        /// </summary>
        /// <param name="e">The event.</param>
        /// <returns>The manifest if it is complete.</returns>
        public string ProcessEventSourceManifestEvent(ref EtwEvent e)
        {
            if (!IsEventSourceManifestEvent(ref e))
            {
                return null;
            }

            if (!_manifests.TryGetValue((e.Provider, e.ProcessId, e.ThreadId), out var manifest))
            {
                _manifests[(e.Provider, e.ProcessId, e.ThreadId)] = manifest = new();
            }

            return manifest.AddEvent(ref e) ? manifest.GetManifest() : null;
        }

        /// <summary>
        /// Gets all completed manifests.
        /// </summary>
        /// <returns>Completed manifests.</returns>
        public IEnumerable<(Guid Provider, uint Pid, uint Tid, string Manifest)> GetCompletedManifests() =>
            _manifests.Where(kvp => kvp.Value.Complete).Select(kvp => (kvp.Key.Provider, kvp.Key.Pid, kvp.Key.Tid, kvp.Value.GetManifest())).ToArray();

        [StructLayout(LayoutKind.Sequential)]
        private readonly struct ManifestEnvelope
        {
            public const int MaxChunkSize = 0xFF00;
            public const byte MagicNumber = 0x5B;

            public ManifestFormats Format { get; }
            public byte MajorVersion { get; }
            public byte MinorVersion { get; }
            public byte Magic { get; }
            public ushort TotalChunks { get; }
            public ushort ChunkNumber { get; }

            public enum ManifestFormats : byte
            {
                SimpleXmlFormat = 1
            }
        };

        private sealed class Manifest
        {
            private byte[][] _chunks;
            private int _chunksLeft;
            private byte _majorVersion;
            private byte _minorVersion;

            public bool Complete => _chunks != null && _chunksLeft == 0;

            public string GetManifest()
            {
                if (_chunks == null || _chunksLeft > 0)
                {
                    return null;
                }

                var length = _chunks.Sum(c => c.Length);
                var data = new byte[length];
                var current = 0;

                for (var i = 0; i < _chunks.Length; i++)
                {
                    Array.Copy(_chunks[i], 0, data, current, _chunks[i].Length);
                    current += _chunks[i].Length;
                }

                return Encoding.UTF8.GetString(data);
            }

            internal unsafe bool AddEvent(ref EtwEvent e)
            {
                if (e.Data.Length <= sizeof(ManifestEnvelope))
                {
                    _chunks = null;
                    return false;
                }

                fixed (byte* buffer = e.Data)
                {
                    var envelope = (ManifestEnvelope*)buffer;

                    if (envelope->Magic != ManifestEnvelope.MagicNumber
                        || envelope->Format != ManifestEnvelope.ManifestFormats.SimpleXmlFormat
                        || envelope->ChunkNumber >= envelope->TotalChunks
                        || envelope->TotalChunks == 0
                        || (_chunks == null && envelope->ChunkNumber != 0))
                    {
                        _chunks = null;
                        return false;
                    }

                    if (_chunks == null)
                    {
                        _majorVersion = envelope->MajorVersion;
                        _minorVersion = envelope->MinorVersion;
                        _chunksLeft = envelope->TotalChunks;
                        _chunks = new byte[envelope->TotalChunks][];
                    }
                    else if (_majorVersion != envelope->MajorVersion
                        || _minorVersion != envelope->MinorVersion
                        || _chunks.Length <= envelope->ChunkNumber
                        || (_chunks[envelope->ChunkNumber] != null && _chunks[envelope->ChunkNumber].Length != (e.Data.Length - sizeof(ManifestEnvelope))))
                    {
                        _chunks = null;
                        return false;
                    }

                    if (_chunks[envelope->ChunkNumber] == null)
                    {
                        _chunks[envelope->ChunkNumber] = e.Data[sizeof(ManifestEnvelope)..].ToArray();
                        _chunksLeft -= 1;
                    }
                }

                return _chunksLeft == 0;
            }
        }
    }
}
