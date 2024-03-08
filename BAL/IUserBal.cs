using LoyaltyReward.Models;
using LoyaltyReward.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoyaltyReward.BAL
{
    internal interface IUserBal
    {
        IEnumerable<AdminViewModel> Getall();
        int Create(UserVeiwModel user);
        int RemoveVideo(int id);
        int Approve (int id);
        int Block(int id);
        AdminViewModel Login(LoginViewModel user);
        AdminViewModel LoginByID(int UID);
        int AddVideo(VideoAddViewModel vid);
        IEnumerable<Video> GetVideo(int id);
        int AddBalance(int userid,int videoid);
        int TotalBalance(int userid);
        int TotalUsers();
        int TotalVideos();
        int TotalEarned();
        int WalletRedeem(BankDetails user);
        int MostEarned(int id);
        int TotalWatched(int id);
    }
}
