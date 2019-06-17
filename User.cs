using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mysqlConsole
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("u_id")]
        [Display(Name = "主键")]
        public long Id {get;set;}
        [Column("u_name")]
        public string Name {get;set;}
       [Column("u_age")]
        public int Age {get;set;}

    }
}