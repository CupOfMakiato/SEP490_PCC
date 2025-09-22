namespace Server.Application.Interfaces
{
    public interface IMessageNotifier
    {
        Task NotifyMessageSentAsync(Guid chatThreadId, object payload, string type);
    }
}
