using CommonUtils.Audit.Enums;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonUtils.Audit.Models
{
    public class AuditEntry
    {
        public AuditEntry(EntityEntry entry)
        {
            Entry = entry;
        }

        public AuditEntry() { }

        public EntityEntry Entry { get; }
        public string UserId { get; set; }
        public string TableName { get; set; }
        public string Query { get; set; }
        public Dictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();
        public List<PropertyEntry> TemporaryProperties { get; } = new List<PropertyEntry>();
        public bool HasTemporaryProperties => TemporaryProperties.Any();
        public ActivityType AuditType { get; set; }
        public List<string> ChangedColumns { get; } = new List<string>();
        public AuditLogEntry ToAudit()
        {
            var audit = new AuditLogEntry();
            audit.UserId = UserId;
            audit.ActivityType = AuditType.ToString();
            audit.ObjectType = TableName;
            audit.ActivityTime = DateTime.UtcNow;
            audit.ObjectKey = JsonConvert.SerializeObject(KeyValues);
            audit.OldValue = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues);
            audit.NewValue = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues);
            audit.AffectedColumns = ChangedColumns.Count == 0 ? null : JsonConvert.SerializeObject(ChangedColumns);
            audit.Query = Query;
            return audit;
        }
    }
}
