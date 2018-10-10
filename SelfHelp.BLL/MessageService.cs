using SelfHelp.Contract;
using SelfHelp.DAL.DAL;
using SelfHelp.Models;
using SelfHelp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.BLL
{
    public class MessageService : IMessageService
    {
        public MessageDAL dal;
        public MessageService()
        {
            dal = new MessageDAL();
        }
      public List<User> GetUserMList()
      {
          return dal.GetUserMList();
      }
      public int MsgAdd(Message UserModel)
      {
          return dal.MsgAdd(UserModel);
      }
      public DataSet MessageModel(int Sender, int receiver, string title)
      {
          return dal.MessageModel(Sender, receiver,  title);
      }
      public int MsgTitleAdd(MessageTitle MsgTitle)
      {
          return dal.MsgTitleAdd(MsgTitle);
      }
      public DataSet Msglist(int pageSize, int pageIndex, string UserName, string MsgTitle, int receiver)
      {
          return dal.Msglist(pageSize,pageIndex,UserName,MsgTitle,receiver);
      }
      public List<MsgInfoModel> GetMsgR(int TitleID, int receiver)
      {
          return dal.GetMsgR(TitleID,receiver);
      }
      public int RemoveMesList(string[] megIDArray)
      {
          return dal.RemoveMesList(megIDArray);
      }
      public DataSet MessageModels(int Sender, string title)
      {
          return dal.MessageModels(Sender, title);
      }
      public MsgTitleTableViewModel AdminMsglist(int pageSize, int pageIndex, string UserName, string MsgTitle, int receiver, int RoleType)
      {
          return dal.AdminMsglist(pageSize, pageIndex, UserName, MsgTitle, receiver, RoleType);
      }
      public int MsgDeleteAdd(MsgDelete MsgDeleteModel)
      {
          return dal.MsgDeleteAdd(MsgDeleteModel);
      }
      public List<MessageTitle> GetMsgTitle(int MsgTitleID)
      {
          return dal.GetMsgTitle(MsgTitleID);
      }
    }
}
