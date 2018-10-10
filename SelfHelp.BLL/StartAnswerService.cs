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
    public class StartAnswerService : IStartAnswerService
    {
        public StartAnswerDAL dal;
        public StartAnswerService()
        {
            dal = new StartAnswerDAL();
        }
        public IEnumerable<Subject_Info> SubJectInfo(string Acode)
        {
            return dal.SubJectInfo(Acode);
        }
        public List<Subject_Operation_Relation> Subject_Operation_Relations(string SubjectCode)
        {
            return dal.Subject_Operation_Relations(SubjectCode);
        }
        public List<Operation_Info> Operation_InfoList(List<string> OperationCodeList)
        {
            return dal.Operation_InfoList(OperationCodeList);
        }
        public int InsertAnswer(AnswerAdd Amodel)
        {
            return dal.InsertEntity<AnswerAdd>(Amodel);

        }
        public DataSet SubjectOp(string Acode)
        {
            return dal.SubjectOp(Acode);
        }
        public List<string> GetSubjectCodeByDimensionCode(string DCode)
        {
            return dal.GetSubjectCodeByDimensionCode(DCode);
        }
        public ReportListTableViewModel GetReportList(int pageSize, int pageIndex, string UserName, string Str, int RoleType)
        {
            return dal.GetReportList(pageSize, pageIndex, UserName, Str, RoleType);
        }
        public int RemoveAnswer(string[] ncIDArray)
        {
            return dal.RemoveAnswer(ncIDArray);
        }
        public List<UAModel> AnswerAddModel(string AnswerID)
        {
            return dal.AnswerAddModel(AnswerID);
        }
        public List<Amount_Info> GetAmount_Info(string Acode)
        {
            return dal.GetAmount_Info(Acode);
        }
        public List<ReportListModel> GetReportListshow(int pageSize, int pageIndex, DateTime beginTime, DateTime endTime, string str)
        {
            return dal.GetReportListshow(pageSize, pageIndex, beginTime, endTime, str);
        }
        public int UpdateAnswer(AnswerAdd user)
        {
            return dal.UpdateAnswer(user);
        }
    }
}
