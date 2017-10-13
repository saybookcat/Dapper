using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Diagnostics;

namespace Dapper.NewTest
{
    class Program
    {
        static void Main(string[] args)
        {
            
           var connection = GetMySqlConnection();
            DynamicParameters param = new DynamicParameters();
            param.Add("@BranchCode", "ydhead");
            S_Branch br = new S_Branch();
            br.BranchCode = "ydsoft";
            T_Base_User_Search br1 = new T_Base_User_Search();
            br1.RoleId = 1;
            br1.PrincipalId = 0;
            br1.PageIndex = 1;
            br1.PageSize = 1;
            br1.Asc = true;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var list1 = connection.Get(br.GetType(), 1);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);

            Console.ReadKey();
        }

        private static MySql.Data.MySqlClient.MySqlConnection GetMySqlConnection(bool open = true,
          bool convertZeroDatetime = false, bool allowZeroDatetime = false)
        {
            string connstring = "Server=localhost;Database=yd_plat;Uid=root;Pwd=zh;";
            var conn = new MySql.Data.MySqlClient.MySqlConnection(connstring);
            if (open) conn.Open();
            return conn;
        }

        /// <summary>
        /// 分公司或者校区
        /// </summary>
        [Dapper.Contrib.Extensions.Table("S_Branch")]
        public class S_Branch
        {
            [Key]
            public string Id { get; set; }

            [ExplicitKey]
            public string GroupCode { get; set; }
            [ExplicitKey]
            public string BranchCode { get; set; }
            public string BranchName { get; set; }
            public string Address { get; set; }
        }


        [Dapper.Contrib.Extensions.Table("t_base_User")]
        public class T_Base_User
        {
            [Dapper.Contrib.Extensions.Key]
            public int UserId { get; set; }
            public int OrganId { get; set; }
            public int SubjectId { get; set; }
            public int RoleId { get; set; }
            public string UserName { get; set; }
            public int Sex { get; set; }
            public int PrincipalId { get; set; }
            public string JobNo { get; set; }
            public string CardNo { get; set; }
            public string TelNo { get; set; }
            public string LoginId { get; set; }
            public string LoginPwd { get; set; }
            public DateTime CreateTime { get; set; }
            public DateTime UpdateTime { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public int Status { get; set; }
            public string Notes { get; set; }

        }

        public class T_Base_User_Search
        {
            /// <summary>
            /// 页码
            /// </summary>
            /// 
            [Write(false)]
            public int? PageIndex { get; set; }

            /// <summary>
            /// 页数
            /// </summary>
            [Write(false)]
            public int? PageSize { get; set; }


            /// <summary>
            /// 查询顺序
            /// </summary>
            [Write(false)]
            public bool? Asc { get; set; }

            /// <summary>
            /// 用户名
            /// </summary>
            public string UserName { get; set; }

            /// <summary>
            /// 工号/学号
            /// </summary>
            public string JobNo { get; set; }


            /// <summary>
            /// 负责人
            /// </summary>
            public int PrincipalId { get; set; }

            /// <summary>
            /// 角色
            /// </summary>
            public int? RoleId { get; set; }

            /// <summary>
            /// 所属组织
            /// </summary>
            public int? OrganId { get; set; }
            /// <summary>
            /// 所属班级
            /// </summary>
            public int? SubjectId { get; set; }


            /// <summary>
            /// 一卡通卡号
            /// </summary>
            public string CardNo { get; set; }

            /// <summary>
            /// 审核状态
            /// </summary>
            public int? Status { get; set; }
            /// <summary>
            /// 用户ID字符串，逗号隔开
            /// </summary>
            public string UString { get; set; }

            /// <summary>
            /// 过期日期
            /// </summary>
            public DateTime? ExpriDate { get; set; }
        }
    }
}
