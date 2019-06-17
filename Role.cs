using System.Data.Common;
using System;

namespace mysqlConsole
{
    public class Role
    {
        //[Column("u_id")]
        public long Id {get;set;}
        //[Column("u_name")]
        public string Name {get;set;}
        //[Column("u_age")]
        public int Age {get;set;}
    }
}