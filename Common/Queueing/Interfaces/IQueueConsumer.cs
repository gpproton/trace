namespace Trace.Common.Queueing.Interfaces;

public interface IQueueConsumer<in TQueueMessage> where TQueueMessage : class, IQueueMessage {
    Task ConsumeAsync(TQueueMessage message);
}