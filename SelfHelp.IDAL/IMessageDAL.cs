using SelfHelp.Models;
using SelfHelp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.IDAL
{
    public interface IMessageDAL : IRepository
   {
       List<User> GetUserMList();
       int MsgAdd(Message UserModel);
       DataSet MessageModel(int Sender, int receiver, string title);
       int MsgTitleAdd(MessageTitle MsgTitle);
       DataSet Msglist(int pageSize, int pageIndex, string UserName, string MsgTitle, int receiver);
       List<MsgInfoModel> GetMsgR(int TitleID, int receiver);
       int RemoveMesList(string[] megIDArray);
       DataSet MessageModels(int Sender, string title);
       MsgTitleTableViewModel AdminMsglist(int pageSize, int pageIndex, string UserName, string MsgTitle, int receiver, int RoleType);
       int MsgDeleteAdd(MsgDelete MsgDeleteModel);
       List<MessageTitle> GetMsgTitle(int MsgTitleID);
    }
}
