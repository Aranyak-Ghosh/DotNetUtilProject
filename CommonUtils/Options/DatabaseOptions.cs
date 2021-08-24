using System;
using System.Collections.Generic;
using System.Text;

namespace CommonUtils.Options
{
    public class DatabaseOptions : BaseOptions
    {
        public static string Accessor { get => Key; set => Key = "Database"; }

        public string ConnectionString { get; }
        public string DatabaseProvider { get; }


    }
}
