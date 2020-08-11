using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ZJM
{
    class User
    {
        //登录验证
        public bool userLogin(string User_id, string User_pasw)
        {
            string cmd = "select count(*) from U where User_id=@User_id and User_pasw=@User_pasw";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("User_id", User_id),
                new SqlParameter("User_pasw", User_pasw)
            };
            int ret = int.Parse(SQLHelper.ExecOneSQL(cmd, paras));
            if (0 < ret)
            {
                return true;
            }
            return false;
        }
       //根据用户名和id进行数据库查询
        public DataSet getUsersByNameandid(string User_id,string User_name)
        {
            string cmd = "select * from U where User_id like '%" + User_id + "%'and User_name like '%" + User_name + "%'";
            DataSet ds = SQLHelper.ExecSQLByDataSet(cmd,null);
            return ds;
        }
        //删除指定用户
        public bool deleteUser(string User_id)
        {
            string cmd = "delete from U where User_id=@User_id";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("User_id", User_id) };
            int ret = SQLHelper.ExecNonSQL(cmd, paras);
            if (ret > 0) return true;
            return false;
        }
        //添加新用户
        public bool addUser(string User_id, string Car_id, string User_name, string User_pasw, string User_identity, string User_all, string User_status, string User_address, string User_new)
        {
            string cmd = "insert into U values(@User_id,@Car_id,@User_name,@User_pasw,@User_identity,@User_all,@User_status,@User_address,@User_new)";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("User_id", User_id),
                new SqlParameter("Car_id", Car_id),
                new SqlParameter("User_name", User_name),
                new SqlParameter("User_pasw", User_pasw),
                new SqlParameter("User_identity", User_identity),
                new SqlParameter("User_all", User_all),
                new SqlParameter("User_status", User_status),
                new SqlParameter("User_address", User_address),
                new SqlParameter("User_new", User_new)
            };
            int ret = SQLHelper.ExecNonSQL(cmd, paras);
            if (ret > 0) return true;
            return false;
        }
        //添加新卡
        public bool addCard(string Car_id, string User_id, string Card_pasw)
        {
            string cmd = "update U set Car_id=@Car_id where User_id like '%" + User_id + "%' and User_pasw like '%" + Card_pasw + "%' ";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("Car_id", Car_id),
            };
            int ret = SQLHelper.ExecNonSQL(cmd, paras);
            if (ret > 0) return true;
            return false;
        }
        //挂失卡
        public bool updateCard(string Card_id, string Card_pasw)
        {
            string cmd = "update Ca set Card_status='挂失'where card_id like '%" + Card_id + "%' and Card_pasw like '%" + Card_pasw + "%'";
            SqlParameter[] paras = new SqlParameter[] {               
                new SqlParameter("Card_pasw", Card_pasw),
            };
            int ret = SQLHelper.ExecNonSQL(cmd, paras);
            if (ret > 0) return true;
            return false;
        }
        //恢复卡
        public bool updatereCard(string Card_id, string Card_pasw)
        {
            string cmd = "update Ca set Card_status='正常'where card_id like '%" + Card_id + "%' and Card_pasw like '%" + Card_pasw + "%'";
            SqlParameter[] paras = new SqlParameter[] {               
                new SqlParameter("Card_pasw", Card_pasw),
            };
            int ret = SQLHelper.ExecNonSQL(cmd, paras);
            if (ret > 0) return true;
            return false;
        }
        //更新用户密码
        public bool updateUser(string User_id,string User_pasw)
        {
            string cmd = "update U set User_pasw=@User_pasw where User_id like '%" + User_id + "%'";
            SqlParameter[] paras = new SqlParameter[] {               
                new SqlParameter("User_pasw", User_pasw)
            };
            int ret = SQLHelper.ExecNonSQL(cmd, paras);
            if (ret > 0) return true;
            return false;
        }

        //更新ATM_id
        public bool updateATMid(string Atm_id, string Card_id)
        {
            string cmd = "update ATM set Atm_id=@Atm_id where Card_id like '%" + Card_id + "%'";
            SqlParameter[] paras = new SqlParameter[] {               
                new SqlParameter("Card_id", Card_id)
            };
            int ret = SQLHelper.ExecNonSQL(cmd, paras);
            if (ret > 0) return true;
            return false;
        }
        //根据卡id和卡密码进行数据库查询
        public DataSet getUsersByall(string Card_id, string User_pasw)
        {
            string cmd = "select * from ATM where Card_id like '%" + Card_id + "%'and User_pasw like '%" + User_pasw + "%'";
            DataSet ds = SQLHelper.ExecSQLByDataSet(cmd, null);
            return ds;
        }
        //根据账号进行数据库查询
        public DataSet getUsersByid(string User_id)
        {
            string cmd = "select * from U where User_id like '%" + User_id + "%'";
            DataSet ds = SQLHelper.ExecSQLByDataSet(cmd, null);
            return ds;
        }
        //根据卡号进行数据库查询
        public DataSet getUsersBycid(string Card_id)
        {
            string cmd = "select * from U where Car_id like '%" + Card_id + "%'";
            DataSet ds = SQLHelper.ExecSQLByDataSet(cmd, null);
            return ds;
        }
        //更新ATM表信息
        public bool updateATM1(string Card_id, string Atm_out)
        {
            string cmd = "update Atm set Atm_out=@Atm_out where Card_id like '%" + Card_id + "%'";
            SqlParameter[] paras = new SqlParameter[] {               
                new SqlParameter("Atm_out", Atm_out)              
            };
            int ret = SQLHelper.ExecNonSQL(cmd, paras);
            if (ret > 0) return true;
            return false;
        }
        //更新U表信息
        public bool updateUser1(string Card_id, string User_all)
        {
            string cmd = "update U set User_all=User_all-@User_all where Car_id like '%" + Card_id + "%'";
            SqlParameter[] paras = new SqlParameter[] {               
                new SqlParameter("User_all", User_all)              
            };
            int ret = SQLHelper.ExecNonSQL(cmd, paras);
            if (ret > 0) return true;
            return false;
        }

        //更新U表信息
        public bool updateUser2(string User_id, string User_all)
        {
            string cmd = "update U set User_all=User_all+@User_all where User_id like '%" + User_id + "%'";
            SqlParameter[] paras = new SqlParameter[] {               
                new SqlParameter("User_all", User_all)              
            };
            int ret = SQLHelper.ExecNonSQL(cmd, paras);
            if (ret > 0) return true;
            return false;
        }

        //更新U表信息
        public bool updateUser3(string Card_id, string User_all)
        {
            string cmd = "update U set User_all=User_all+@User_all where Car_id like '%" + Card_id + "%'";
            SqlParameter[] paras = new SqlParameter[] {               
                new SqlParameter("User_all", User_all)              
            };
            int ret = SQLHelper.ExecNonSQL(cmd, paras);
            if (ret > 0) return true;
            return false;
        }
        //更新U表信息
        public bool updateUser4(string User_id, string User_all)
        {
            string cmd = "update U set User_all=User_all-@User_all where User_id like '%" + User_id + "%'";
            SqlParameter[] paras = new SqlParameter[] {               
                new SqlParameter("User_all", User_all)              
            };
            int ret = SQLHelper.ExecNonSQL(cmd, paras);
            if (ret > 0) return true;
            return false;
        }
    }
}
