namespace Server.Application.Interfaces
{
    public interface IGeminiChatService
    {
        public Task<string> SendMessageAsync(string message);
    }
}
