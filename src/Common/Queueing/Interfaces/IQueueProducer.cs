namespace Trace.Common.Queueing.Interfaces;

public interface IQueueProducer<in TQueueMessage> where TQueueMessage : IQueueMessage {
    void PublishMessage(TQueueMessage message);
}