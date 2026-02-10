using BankAccountManagmentSystemApi.Data;
using BankAccountManagmentSystemApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BankAccountManagmentSystemApi.Services.MainServices
{
    public class AuditService 
    {
        private readonly AppDbContext _context;
        public AuditService(AppDbContext context)
        {
            _context = context;
        }

        public async Task LogEventAsync(AuditLogModel logModel)
        {
            var log = new AuditLogModel
            {
                UserId = logModel.UserId,
                Action = logModel.Action,
                EntityName = logModel.EntityName,
                Details = logModel.Details,
                EventType = logModel.EventType,
            };

            _context.AuditLogs.Add(log);
            await _context.SaveChangesAsync();
        }

    }
}
