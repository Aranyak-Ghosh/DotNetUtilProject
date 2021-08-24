using System;
using System.Collections.Generic;
using System.Text;

namespace CommonUtils.Options
{
    public class StorageLoggerOptions : BaseOptions
    {
        public static string Accessor { get { return Key; } set { Key = "Logger:StorageAccount"; } }
        public string ConnectionString { get; }
        public string TableName { get; }
    }

    public class SQLLoggerOptions : BaseOptions
    {
        public static string Accessor { get { return Key; } set { Key = "Logger:SQL"; } }

        public string ConnectionString { get; }
        public string TableName { get; }
    }
}
