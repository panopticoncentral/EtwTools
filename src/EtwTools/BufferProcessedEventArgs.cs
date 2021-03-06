using System;

namespace EtwTools
{
    /// <summary>
    /// Event arguments for buffer processing event.
    /// </summary>
    public sealed class BufferProcessedEventArgs : EventArgs
    {
        /// <summary>
        /// The time the buffer was processed.
        /// </summary>
        public DateTime ProcessedTime { get; init; }

        /// <summary>
        /// The number of buffers read so far.
        /// </summary>
        public uint BuffersRead { get; init; }

        /// <summary>
        /// The overall size of the buffer.
        /// </summary>
        public uint BufferSize { get; init; }

        /// <summary>
        /// The number of bytes used in the buffer.
        /// </summary>
        public uint BufferUsed { get; init; }

        /// <summary>
        /// The context provided when the trace was opened.
        /// </summary>
        public nint Context { get; init; }

        /// <summary>
        /// Whether processing should continue.
        /// </summary>
        public bool Continue { get; set; }

        /// <summary>
        /// Creates event arguments for the buffer processed event.
        /// </summary>
        /// <param name="processedTime">The time the buffer was processed.</param>
        /// <param name="buffersRead">The number of buffers read so far.</param>
        /// <param name="bufferSize">The overall size of the buffer.</param>
        /// <param name="bufferUsed">The number of bytes used in the buffer.</param>
        /// <param name="context">The context provided when the trace was opened.</param>
        public BufferProcessedEventArgs(DateTime processedTime, uint buffersRead, uint bufferSize, uint bufferUsed, nint context)
        {
            ProcessedTime = processedTime;
            BuffersRead = buffersRead;
            BufferSize = bufferSize;
            BufferUsed = bufferUsed;
            Context = context;
            Continue = true;
        }
    }
}
