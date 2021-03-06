namespace EtwTools
{
    public enum EventType : byte
    {
        Info,
        Start,
        End,
        Stop = End,
        DataCollectionStart,
        DataCollectionEnd,
        Extension,
        Reply,
        Dequeue,
        Resume = Dequeue,
        Checkpoint,
        Suspend = Checkpoint,
        Send,
        Recieve = 0xF0
    }
}
