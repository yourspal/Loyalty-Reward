using Dapper;
using LoyaltyReward.Models;
using LoyaltyReward.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;

namespace LoyaltyReward.BAL
{
    public class UserBal : IUserBal
    {
        static readonly string connstr = ConfigurationManager.ConnectionStrings["MyConnection"].ToString();
        SqlConnection conn = new SqlConnection(connstr);
        int IUserBal.Create(UserVeiwModel user)
        {
            try
            {
                conn.Open();
                int result = conn.Execute("AddDetails", user, commandType: CommandType.StoredProcedure);
                conn.Close();
                return result;

            }
            catch (Exception)
            {
                
                throw new InvalidOperationException("Duplicate Entry!!! Some Field already exists"); 
            }
        }

        int IUserBal.Block(int id)
        {
                conn.Open();
                int result = conn.Execute("BlockUser", new { id = id }, commandType: CommandType.StoredProcedure);
                conn.Close();
                return result;
        }
        IEnumerable<AdminViewModel> IUserBal.Getall()
        {
                conn.Open();
                List<AdminViewModel> result = SqlMapper.Query<AdminViewModel>(conn, "ShowAll").ToList();
                conn.Close();
                return result;
        }

        int IUserBal.Approve(int id)
        {
                conn.Open();
                int result = conn.Execute("AdminApprove", new { @id = id }, commandType: CommandType.StoredProcedure);
                conn.Close();
                return result;
        }
        AdminViewModel IUserBal.Login(LoginViewModel user)
        {
                AdminViewModel result = conn.QueryFirstOrDefault<AdminViewModel>("select * from UserDetails WHERE LoginName=@Loginname AND Password=@Password ", new { LoginName = user.LoginName, Password = user.Password });

                return result;

        }

        AdminViewModel IUserBal.LoginByID(int UID)
        {
                AdminViewModel result = conn.QueryFirstOrDefault<AdminViewModel>("select * from UserDetails WHERE UserId=@UID");
                return result;

        }

        int IUserBal.AddVideo(VideoAddViewModel vid)
        {

                conn.Open();
                int result = conn.Execute("VideoUpdate", vid, commandType: CommandType.StoredProcedure);
                conn.Close();
                return result;
        }

        IEnumerable<Video> IUserBal.GetVideo(int id)
        {
                conn.Open();
                List<Video> result = SqlMapper.Query<Video>(conn, "GetVideos", new { @userId = id }, commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                return result;

        }

        int IUserBal.AddBalance(int userid, int videoid)
        {
            conn.Open();
            int result = conn.Execute("AddBalance", new { @UserID = userid, @videoId = videoid }, commandType: CommandType.StoredProcedure);
            conn.Close();
            return result;
        }

        int IUserBal.TotalBalance(int userid)
        {
            conn.Open();
            int result = conn.QueryFirstOrDefault<int>("GetBalance", new { @UserId = userid }, commandType: CommandType.StoredProcedure);
            conn.Close();
            return result;
        }

        int IUserBal.RemoveVideo(int id)
        {
            conn.Open();
            int result = conn.Execute("RemoveVideo", new { @id = id }, commandType: CommandType.StoredProcedure);
            conn.Close();
            return result;
        }
        int IUserBal.TotalUsers()
        {
            conn.Open();
            int result = conn.QueryFirstOrDefault<int>("select count(*) from UserDetails");
            conn.Close();
            return result;
        }
        int IUserBal.TotalVideos()
        {
            conn.Open();
            int result = conn.QueryFirstOrDefault<int>("select count(*) from VideoMaster");
            conn.Close();
            return result;
        }
        int IUserBal.TotalEarned()
        {
            conn.Open();
            int result = conn.QueryFirstOrDefault<int>("select sum(TotalAmount) from Tbl_Dashboard_Balance");
            conn.Close();
            return result;
        }

        int IUserBal.WalletRedeem(BankDetails user)
        {
            conn.Open();
            int result = conn.Execute("Withdraw", new { @userId = user.UserID, @spent = @user.Amount }, commandType: CommandType.StoredProcedure);
            conn.Close();
            return result;
        }
        int IUserBal.MostEarned(int id)
        {
            conn.Open();
            int result = conn.QueryFirstOrDefault<int>("MostEarn", new { @Userid = id }, commandType: CommandType.StoredProcedure);
            conn.Close();
            return result;
        }
        int IUserBal.TotalWatched(int id)
        {
            conn.Open();
            int result = conn.QueryFirstOrDefault<int>("TotalWatched", new { @userId = id }, commandType: CommandType.StoredProcedure);
            conn.Close();
            return result;
        }

    }
}