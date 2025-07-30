using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories
{
    public class ChatThreadRepository : GenericRepository<ChatThread>, IChatThreadRepository
    {
        private readonly AppDbContext _context;

        public ChatThreadRepository(AppDbContext context,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(context, timeService, claimsService)
        {
            _context = context;
        }

        public async Task<ChatThread?> GetChatThreadByIdAsync(Guid chatThreadId)
        {
            return await _context.ChatThread
                .Where(ct => ct.Id == chatThreadId && !ct.IsDeleted)
                .Select(ct => new ChatThread
                {
                    Id = ct.Id,
                    UserId = ct.UserId,
                    ConsultantId = ct.ConsultantId,
                    Status = ct.Status,
                    User = ct.User,
                    Messages = ct.Messages
                        .Where(m => !m.IsDeleted)
                        .Select(m => new Message
                        {
                            Id = m.Id,
                            SenderId = m.SenderId,
                            MessageText = m.MessageText,
                            IsRead = m.IsRead,
                            SentAt = m.SentAt,
                            ReadAt = m.ReadAt,
                            Media = m.Media != null
                                ? m.Media.Where(media => !media.IsDeleted).ToList()
                                : new List<Media>()
                        })
                        .ToList(),
                    IsDeleted = ct.IsDeleted
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<ChatThread?>> GetChatThreadByUserIdAsync(Guid userId)
        {
            return await _context.ChatThread
                .Where(ct => ct.ConsultantId == userId || ct.UserId == userId && !ct.IsDeleted)
                .ToListAsync();
        }

        public async Task<ChatThread?> GetExistingChatThreadByIdAsync(Guid userId, Guid consultantId)
        {
            return await _context.ChatThread
                .Include(ct => ct.User)
                .FirstOrDefaultAsync(ct => ct.UserId == userId
                                        && ct.ConsultantId == consultantId
                                        && !ct.IsDeleted);
        }
    }
}
