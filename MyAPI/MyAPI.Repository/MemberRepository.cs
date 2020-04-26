using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace MyAPI.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly IDatabaseHelper databaseHelper;

        public MemberRepository(IDatabaseHelper databaseHelper)
        {
            this.databaseHelper = databaseHelper;
        }

        public IEnumerable<Member> Get()
        {
            // 資料庫實作
            using (IDbConnection conn = this.databaseHelper.GetConnection())
            {
                string sql = @"
SELECT
    ID
    , Name
FROM
    Member
";
                return conn.Query<Member>(sql);
            }
        }

        //public async Task<IEnumerable<Member>> GetAsync()
        //{
        //    // 資料庫實作
        //    using (IDbConnection conn = this._databaseHelper.GetConnection())
        //    {
        //        string sql = @"
        //                    SELECT
        //                        BlogId,
        //                        Url
        //                    FROM Blog
        //                    WHERE
        //                        BlogId = @BlogId OR
        //                        Url = @Url";

        //        var Blogs = await conn.QueryAsync<Blog>(
        //            sql,
        //            new
        //            {
        //                blogQuery.BlogId,
        //                blogQuery.Url
        //            });

        //        return Blogs;
        //    }
        //}
    }
}
