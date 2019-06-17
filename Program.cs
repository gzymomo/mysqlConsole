using System.Diagnostics;
using System.Collections.Generic;
using System;
using System.Data;
using Dapper;
using MySql.Data.MySqlClient;
using Sikiro.Dapper.Extension.MySql;

namespace mysqlConsole
{
    class Program
    {
        static void Main(string[] args)
        {

         
            Console.WriteLine("Hello World!");

            string conStr = "server=localhost;username=root;pwd=123456; port=3306;database=ctjs;SslMode=none;";

            using (MySqlConnection connection = new MySqlConnection(conStr))
            {
                //var r = connection.QuerySet<User>().Get();
                //var r = connection.QuerySet<User>().ToList();
                //var r = connection.QuerySet<User>().Where(s=> s.Name=="gzymomo").Select(a => new User { Id = a.Id, Name = a.Name, Age = a.Age }).ToList();
               
              List<User> user =   (List<User>)connection.QuerySet<User>().ToList();
              System.Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(user));
                
               // System.Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(r));
            }

     
        }

        public static void db2()
        {
            string conStr = "server=localhost;username=root;pwd=123456; port=3306;database=ctjs;SslMode=none;";

            using (MySqlConnection connection = new MySqlConnection(conStr))
            {
                //var sql = "select * from user";
                //查询 集合
                //var r = connection.Query<User>(sql).AsList();
                //System.Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(r));

                // //sql 操作
                // var rInt = connection.Execute(" insert User (ID,Name) values (@id,'javc')", new { id = new Random().Next(100, 200) });
                // rInt = connection.Execute(" update User set name=@name where id=1002", new { name = "hellon" });
                // // 查询单个对象

                var rOne = connection.CommandSet<User>().Where(a => a.Id == 123123).Delete();
                //var rOne = connection.QuerySet<User>().Get;

                //var rOne = connection.;
                
        
                System.Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(rOne));
            }
        }

        public void db1()
        {
            var sql = "select * from blacklist limit 100";
            var conStr = "server=localhost;username=root;pwd=123456; port=3306;database=ctjs;SslMode=none;";
            using (MySqlConnection connection = new MySqlConnection(conStr))
            {
                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataAdapter sqlDA = new MySqlDataAdapter();
                sqlDA.SelectCommand = command;
                DataSet dataSet = new DataSet();
                sqlDA.Fill(dataSet);
                System.Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(dataSet));
            }
            //使用 MySqlHelp
            var ds = MySqlHelper.ExecuteDataset(conStr, sql);
            System.Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(ds));
            Console.WriteLine("Hello World!");
        }
    }
}
