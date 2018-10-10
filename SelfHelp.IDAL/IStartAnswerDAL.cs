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
    public interface IStartAnswerDAL : IRepository
    {
        IEnumerable<Subject_Info> SubJectInfo(string Acode);
        List<Subject_Operation_Relation> Subject_Operation_Relations(string SubjectCode);
        List<Operation_Info> Operation_InfoList(List<string> OperationCodeList);
        //int InsertAnswer(AnswerAdd Amodel);
        DataSet SubjectOp(string Acode);
        List<string> GetSubjectCodeByDimensionCode(string DCode);
        ReportListTableViewModel GetReportList(int pageSize, int pageIndex, string UserName, string Str, int RoleType);
        int RemoveAnswer(string[] ncIDArray);
        List<UAModel> AnswerAddModel(string AnswerID);
        List<Amount_Info> GetAmount_Info(string Acode);
        List<ReportListModel> GetReportListshow(int pageSize, int pageIndex, DateTime beginTime, DateTime endTime, string str);
        int UpdateAnswer(AnswerAdd user);
    }
}
