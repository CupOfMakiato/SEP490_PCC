namespace Server.Domain.Enums
{
    public enum UserSubscriptionStatus
    {
        Pending,   // Vừa tạo, chưa có Payment thành công
        Active,    // Có Payment thành công, đang trong thời hạn
        Expired,   // Hết hạn, không có Payment mới
        Canceled   // User hoặc hệ thống hủy
    }
}
