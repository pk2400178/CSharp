using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTest
{
    class Program
    {
        private static string strConnection = 
            "server=localhost;uid=MyAPI;pwd=123456789;database=Store1";

        static void Main(string[] args)
        {
            List<Member> results;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                string strSql = @"
SELECT
    ID
    ,FirstName
    ,MidName
    ,LastName
    ,Age
FROM
    Member
WHERE
    FirstName = @FirstName
";
                results = conn
                    .Query<Member>(strSql, new
                    {
                        FirstName = new DbString { Value = "Kuo"}
                    })
                    .ToList();
              
            }
            foreach (var member in results)
            {
                Console.WriteLine($"FirstName:{member.FirstName}, LastName:{member.LastName} ");
            }


            Console.WriteLine("End");
            Console.ReadKey();
        }
    }
}
