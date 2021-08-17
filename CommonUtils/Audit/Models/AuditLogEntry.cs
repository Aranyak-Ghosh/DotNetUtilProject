using System;
using System.Collections.Generic;
using System.Text;

namespace CommonUtils.Audit.Models
{
    public class AuditLogEntry
    {
        public Guid TransactionId { get; set; }
        public string ActivityType { get; set; }
        public string ObjectType { get; set; }
        public DateTime ActivityTime { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string AffectedColumns { get; set; }
        public string UserId { get; set; }
        public string ObjectKey { get; set; }
        public string Query { get; set; }
    }
}
