namespace Trace.Common.Queueing.Interfaces;

/// <summary>
/// A channel provider that Declares and Binds a specific queue
/// </summary>
internal interface IQueueChannelProvider<in TQueueMessage> : IChannelProvider where TQueueMessage : IQueueMessage {
}
