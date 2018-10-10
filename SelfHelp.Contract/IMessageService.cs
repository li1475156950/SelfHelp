using SelfHelp.Models;
using SelfHelp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Contract
{
    [ServiceContract]
    public interface IMessageService
    {
        [OperationContract(IsOneWay = false)]
        List<User> GetUserMList();
        [OperationContract(IsOneWay = false)]
        int MsgAdd(Message UserModel);
        [OperationContract(IsOneWay = false)]
        DataSet MessageModel(int Sender, int receiver, string title);
        [OperationContract(IsOneWay = false)]
        int MsgTitleAdd(MessageTitle MsgTitle);
        [OperationContract(IsOneWay = false)]
        DataSet Msglist(int pageSize, int pageIndex, string UserName, string MsgTitle, int receiver);
        [OperationContract(IsOneWay = false)]
        List<MsgInfoModel> GetMsgR(int TitleID, int receiver);
        [OperationContract]
        int RemoveMesList(string[] megIDArray);
        [OperationContract]
        DataSet MessageModels(int Sender, string title);
        [OperationContract]
        MsgTitleTableViewModel AdminMsglist(int pageSize, int pageIndex, string UserName, string MsgTitle, int receiver, int RoleType);
        [OperationContract]
        int MsgDeleteAdd(MsgDelete MsgDeleteModel);
          [OperationContract]
        List<MessageTitle> GetMsgTitle(int MsgTitleID);
    }
}
