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
    public interface IStartAnswerService
    {
        [OperationContract(IsOneWay = false)]
        IEnumerable<Subject_Info> SubJectInfo(string Acode);
        [OperationContract(IsOneWay = false)]
        List<Subject_Operation_Relation> Subject_Operation_Relations(string SubjectCode);
        [OperationContract(IsOneWay = false)]
        List<Operation_Info> Operation_InfoList(List<string> OperationCodeList);
        [OperationContract]
        int InsertAnswer(AnswerAdd Amodel);
        [OperationContract]
        DataSet SubjectOp(string Acode);
        [OperationContract]
        List<string> GetSubjectCodeByDimensionCode(string DCode);
        [OperationContract]
        ReportListTableViewModel GetReportList(int pageSize, int pageIndex, string UserName, string Str, int RoleType);
        [OperationContract]
        int RemoveAnswer(string[] ncIDArray);
        [OperationContract]
        List<UAModel> AnswerAddModel(string AnswerID);
        [OperationContract]
        List<Amount_Info> GetAmount_Info(string Acode);
        [OperationContract]
        List<ReportListModel> GetReportListshow(int pageSize, int pageIndex, DateTime beginTime, DateTime endTime, string str);
        [OperationContract]
        int UpdateAnswer(AnswerAdd user);
    }
}
