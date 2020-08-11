using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ZJM
{
    class Tms
    {
        //登录验证
        public bool userLogin(string Tms_id, string Tms_pasw)
        {
            string cmd = "select count(*) from Tms where Tms_id=@Tms_id and Tms_pasw=@Tms_pasw";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("Tms_id", Tms_id),
                new SqlParameter("Tms_pasw", Tms_pasw)
            };
            int ret = int.Parse(SQLHelper.ExecOneSQL(cmd, paras));
            if (0 < ret)
            {
                return true;
            }
            return false;
        }
    }
}
