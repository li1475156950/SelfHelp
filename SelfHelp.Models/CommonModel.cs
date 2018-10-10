using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
  public  class CommonModel
    {

    }
  public class Subject_InfoModel
  {
       [Key]
      public string SubjectCode { get; set; }
      public int Sort { get; set; }
      public string SubjectContent { get; set; }
  }
  public class Subject_OperationModel
  {
      public string OperationCode { get; set; }
      public string OperationContent { get; set; }
      public string OperationFraction { get; set; }
      public string OperationNum { get; set; }
      public string SubjectCode { get; set; }
      public string DimensionCode { get; set; }
      public int Sort { get; set; }
  }
  public class AmountDRModel
  {
         
      public string DimensionCode { get; set; }
  
      public string DimensionName { get; set; }
      public int SubjectNum { get; set; }
      public int ScoringMode { get; set; }
      public int Sort { get; set; }
      public DateTime? CreateTime { get; set; }
      public int U_ID { get; set; }
      public int IS_Delete { get; set; }
      public string FormulaCode { get; set; }
      public string FormulaStr { get; set; }
  }
    public class NormModel
    {
        public string ExplainCode { get; set; }  
        public string ExplainName { get; set; }
        public int NormSex { get; set; }
        public decimal NormStartAge { get; set; }
        public decimal NormEndAge { get; set; }
        public decimal StartFraction { get; set; }
        public decimal EndFraction { get; set; }      
        public string NormExplain { get; set; }      
        public string NormProposal { get; set; }
        public DateTime? CreateTime { get; set; }     
        public string First_Symbol { get; set; }     
        public string Second_Symbol { get; set; }
        public string DimensionCode { get; set; }
    }
    public class DimensionEntity
    {

        public string D_Code { get; set; }
        public string WD_Name { get; set; }
        public double Score { get; set; }
        public int ScoreType { get; set; }
        public string Formulas { get; set; }
        public string ConversionFormula { get; set; }
        public string CMAllScore { get; set; }
        public List<CMModel> CmmodelList { get; set; }
    }
    public class CMModel
    {
        public string StartScore { get; set; }
        public string EndScore { get; set; }
        public string Result { get; set; }
        public string Proposal { get; set; }
        public string NormName { get; set; }
        public string NormSex { get; set; }
        public string NormStartAge { get; set; }
        public string NormEndAge { get; set; }
        public string CmendScore { get; set; }
        public string CMstartScore { get; set; }
    }
    public class Rport
    {
        public string datas { get; set; }
    }
    public class Operation_InfoModel
    {
        public string OperationCode { get; set; }
        public string OperationFraction { get; set; }
    }
    public class  Dimension_Subject_RelationModel
    {
        public string SubjectCode { get; set; }
        public string DimensionCode { get; set; }

    }

    public class ReportListModel
    {
        public int AnswerAdd_ID { get; set; }
        public string Acode { get; set; }
        public string AName { get; set; }
        public string UserName { get; set; }
        public string AtypeName { get; set; }
        public DateTime? AnswerTime { get; set; }
        public string ARCode { get; set; }
        public int RoleType { get; set; }
        public int IS_Delete { get; set; }
    }
    public class UAModel
    {
        public string UID { get; set; }
        public string Acode { get; set; }
        public string UName { get; set; }
        public string ARecode { get; set; }
        public DateTime? AswerTime { get; set; }
        public string AnswerTimeFormat { get; set; }
        public string Amount_Name { get; set; }
        public string Amount_Marks { get; set; }
        public string NewRcodes { get; set; }
    }
    public class UMsgModel
    {
        public int TitleID { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public string UserImg { get; set; }

    }
    public class MsgTitleModel
    {
        public int Sender { get; set; }
        public int TitleID { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public DateTime? Creatime { get; set; }
        public int IsOpen { get; set; }

        public int RID { get; set; }
    }
    public class MsgInfoModel
    {
        public int MessageID { get; set;     }
        public int receiver { get; set; }
        public int TitleID { get; set; }
        public string Title { get; set; }
        public int Sender { get; set; }
        public string UserImg { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public int CreateUID { get; set; }
        public int RoleID { get; set; }
    }
    public class MyComparer : IEqualityComparer<MsgTitleModel>
    {
        public bool Equals(MsgTitleModel x, MsgTitleModel y)
        {
            if (x.TitleID == null)
                return true;
            else
                return (x.TitleID == y.TitleID);
        }

        public int GetHashCode(MsgTitleModel gsbm)
        {
            return gsbm.ToString().GetHashCode();
        }
    }
}



