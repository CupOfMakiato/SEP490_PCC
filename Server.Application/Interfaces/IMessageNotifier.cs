namespace Server.Application.Interfaces
{
    public interface IMessageNotifier
    {
        public Task NotifyMessageSentAsync(Guid chatThreadId, object message);
    }
}
