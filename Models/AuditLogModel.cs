using BankAccountManagmentSystemApi.Enums;

namespace BankAccountManagmentSystemApi.Models
{
    public class AuditLogModel:BaseModel
    {
        // I have used lond DT beacause of high quantity records 
        public long Id { get; set; }

        /// <summary>
        /// نوع رویداد (Success, Error, ...)
        /// </summary>
        public AuditEventType EventType { get; set; }

        /// <summary>
        /// نام عملیاتی که انجام شده
        /// مثال: GetUserAccounts, CreateAccount
        /// </summary>
        public string Action { get; set; } = string.Empty;

        /// <summary>
        /// نام موجودیت یا جدول مرتبط
        /// مثال: Account, User
        /// </summary>
        public string EntityName { get; set; } = string.Empty;

        /// <summary>
        /// شناسه کاربر انجام‌دهنده عملیات
        /// </summary>
        public string? UserId { get; set; }

        /// <summary>
        /// کد ملی یا شناسه مرتبط (در صورت نیاز)
        /// </summary>
        public string? ReferenceCode { get; set; }

        /// <summary>
        /// جزئیات کامل رویداد (JSON یا متن)
        /// </summary>
        public string Details { get; set; } = string.Empty;

        /// <summary>
        /// آی‌پی درخواست
        /// </summary>
        public string? IpAddress { get; set; }

    }
}
