using SelfHelp.IDAL;
//using SelfHelp.IDAL;
using SelfHelp.Models;
using SelfHelp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.DAL.DAL
{
    public class StartAnswerDAL : DaoBase, IStartAnswerDAL
    {
        /// <summary>
        /// 获取题干的详细信息
        /// </summary>
        /// <param name="Acode"></param>
        /// <returns></returns>
        public IEnumerable<Subject_Info> SubJectInfo(string Acode)
        {
            var list = (from x in context.Amount_Subject_Relations
                        join y in context.Subject_Infos on x.SubjectCode equals y.SubjectCode
                        where x.Amount_Code == Acode
                        select y).ToList();
            return list;

        }
        /// <summary>
        /// 获取题干的题支
        /// </summary>
        /// <param name="strSubjecttCode"></param>
        /// <returns></returns>
        public List<Subject_Operation_Relation> Subject_Operation_Relations(string SubjectCode)
        {

            //var list = (from m in context.Subject_Operation_Relations where idList.Contains(m.SubjectCode) select m).ToList();
            var list = context.Subject_Operation_Relations.AsNoTracking().Where(m => m.SubjectCode.Contains(SubjectCode)).ToList();
            return list;
        }
        /// <summary>
        /// 根据题支获取编码的选项
        /// </summary>
        /// <param name="OperationCode"></param>
        /// <returns></returns>
        public List<Operation_Info> Operation_InfoList(List<string> OperationCodeList)
        {
            //var list = context.Operation_Infos.AsNoTracking().Where(m => m.OperationCode.Contains(OperationCode)).ToList();
            var list = (from m in context.Operation_Infos where OperationCodeList.Contains(m.OperationCode) select m).ToList();
            return list;
        }
        /// <summary>
        /// 查询维度和题支题干的维度
        /// </summary>
        /// <param name="Acode"></param>
        /// <returns></returns>
        public DataSet SubjectOp(string Acode)
        {

            DataSet ds = new DataSet();
            var list_S = (from a in context.Operation_Infos
                          join b in context.Subject_Operation_Relations on a.OperationCode equals b.OperationCode
                          join c1 in context.Subject_Infos on b.SubjectCode equals c1.SubjectCode
                          join c in context.Dimension_Subject_Relations on b.SubjectCode equals c.SubjectCode
                          join d in context.AmountDimension_Infos on c.DimensionCode equals d.DimensionCode
                          join e in context.Amount_Dimension_Relations on c.DimensionCode equals e.DimensionCode
                          where e.Amount_Code == Acode
                          select new Subject_OperationModel()
                          {
                              OperationCode = a.OperationCode,
                              OperationContent = a.OperationContent,
                              OperationFraction = a.OperationFraction,
                              OperationNum = a.OperationNum,
                              SubjectCode = c1.SubjectCode,
                              DimensionCode = d.DimensionCode,
                              Sort = c1.Sort,
                          }).ToList();
            //查询常模解释
            var list_A = (from a in context.Amount_Dimension_Relations
                          join b in context.AmountDimension_Infos on a.DimensionCode equals b.DimensionCode
                          join c in context.DimensionFormula_Infos on b.DimensionCode equals c.DimensionCode into temp
                          from dd in temp.DefaultIfEmpty()
                          where a.Amount_Code == Acode
                          select new AmountDRModel()
                          {
                              DimensionCode = b.DimensionCode,
                              DimensionName = b.DimensionName,
                              SubjectNum = b.SubjectNum,
                              ScoringMode = b.ScoringMode,
                              Sort = b.Sort,
                              FormulaCode = dd.FormulaCode,
                              FormulaStr = dd.FormulaStr,
                          }).ToList();
            var list_N = (from a in context.Norm_Explain_Relations
                          join b in context.Dimension_Norm_Relation on a.NormCode equals b.NormCode
                          join c in context.NormExplain_Infos on a.ExplainCode equals c.ExplainCode
                          join d in context.Amount_Dimension_Relations on b.DimensionCode equals d.DimensionCode
                          where d.Amount_Code == Acode
                          select new NormModel()
                          {
                              ExplainName = c.ExplainName,
                              ExplainCode = a.ExplainCode,
                              NormSex = c.NormSex,
                              NormStartAge = c.NormStartAge,
                              NormEndAge = c.NormEndAge,
                              StartFraction = c.StartFraction,
                              EndFraction = c.EndFraction,
                              NormExplain = c.NormExplain,
                              NormProposal = c.NormProposal,
                              First_Symbol = c.First_Symbol,
                              Second_Symbol = c.Second_Symbol,
                              DimensionCode = d.DimensionCode,
                          }).ToList();
            var list_Op = (from a in context.Amount_Infos
                           join b in context.Amount_Subject_Relations on a.Amount_Code equals b.Amount_Code into temp1
                           from tt1 in temp1.DefaultIfEmpty()
                           join c in context.Subject_Operation_Relations on tt1.SubjectCode equals c.SubjectCode into temp2
                           from tt2 in temp2.DefaultIfEmpty()
                           join d in context.Operation_Infos on tt2.OperationCode equals d.OperationCode into temp3
                           from tt3 in temp3.DefaultIfEmpty()
                           where a.Amount_Code == Acode
                           select new Operation_InfoModel()
                        {
                            OperationCode = tt3.OperationCode,
                            OperationFraction = tt3.OperationFraction
                        }).ToList();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            if (dt1 != null)
            {
                dt1 = SelfHelp.Utility.Common.ListToDataTable<Subject_OperationModel>(list_S);
            }
            if (dt2 != null)
            {
                dt2 = SelfHelp.Utility.Common.ListToDataTable<AmountDRModel>(list_A);
            }
            if (dt3 != null)
            {
                dt3 = SelfHelp.Utility.Common.ListToDataTable<NormModel>(list_N);
            }
            if (dt4 != null)
            {
                dt4 = SelfHelp.Utility.Common.ListToDataTable<Operation_InfoModel>(list_Op);
            }
            ds.Tables.Add(dt1);
            ds.Tables.Add(dt2);
            ds.Tables.Add(dt3);
            ds.Tables.Add(dt4);
            return ds;
        }
        /// <summary>
        /// 查询题干题支
        /// </summary>
        /// <param name="DCode"></param>
        /// <returns></returns>
        public List<string> GetSubjectCodeByDimensionCode(string DCode)
        {
            List<string> liststr = new List<string>();
            var list = (from a in context.Subject_Infos
                        join b in context.Dimension_Subject_Relations on a.SubjectCode equals b.SubjectCode into temp
                        from tt in temp.DefaultIfEmpty()
                        join c in context.AmountDimension_Infos on tt.DimensionCode equals c.DimensionCode
                        where c.DimensionCode == DCode
                        select new Dimension_Subject_RelationModel()
                        {
                            SubjectCode = a.SubjectCode,
                            DimensionCode = c.DimensionCode
                        }).ToList();
            foreach (var item in list)
            {
                string str = item.SubjectCode;
                liststr.Add(str);

            }
            return liststr;

        }
        public List<Operation_Info> GetScoreTableByAmount_Code(string Acode)
        {
            var list = (from a in context.Amount_Infos
                        join b in context.Amount_Subject_Relations on a.Amount_Code equals b.Amount_Code
                        join c in context.Subject_Operation_Relations on b.SubjectCode equals c.SubjectCode
                        join d in context.Operation_Infos on c.OperationCode equals d.OperationCode
                        where a.Amount_Code == Acode
                        select new Operation_Info()
                        {
                            OperationCode = d.OperationCode,
                            OperationFraction = d.OperationFraction
                        }).ToList();
            return list;
        }
        public ReportListTableViewModel GetReportList(int pageSize, int pageIndex, string UserName, string Str, int RoleType)
        {
            //b.RoleID == 3
            List<ReportListModel> list = new List<ReportListModel>();
            var tempTable = new ReportListTableViewModel();
            if (RoleType == 1 || RoleType == 2)
            {
                list = (from a in context.AnswerAdds
                        join b in context.Users on a.AnswerPeople equals b.UserID
                        join c in context.Amount_Infos on a.Amount_Code equals c.Amount_Code
                        join d in context.AmountType_Infos on c.Amount_TypeID equals d.Amount_TypeID
                        where b.UserName.Contains(UserName) && (d.AmountType_Name.Contains(Str) || c.Amount_Name.Contains(Str))
                        select new ReportListModel()
                        {
                            AnswerAdd_ID = a.AnswerAdd_ID,
                            Acode = a.Amount_Code,
                            UserName = b.UserName,
                            AName = c.Amount_Name,
                            AtypeName = d.AmountType_Name,//c.Amount_TypeID
                            AnswerTime = a.Answer_CreateTime,
                            ARCode = a.AnswerAdd_Code,
                            RoleType = RoleType
                        }).ToList();
                tempTable.PageCount = list.Count / pageSize;
                if (list.Count < pageSize)
                {
                    tempTable.PageCount = 1;
                }
                if (list.Count % pageSize != 0 && list.Count > pageSize)
                {
                    tempTable.PageCount += 1;
                }
                list = list.OrderByDescending(m => m.AnswerTime).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
                tempTable.ModelList = list;
            }
            //else if (RoleType == 2)
            //{

            //    list = (from a in context.AnswerAdds
            //            join b in context.Users on a.AnswerPeople equals b.UserID
            //            join c in context.Amount_Infos on a.Amount_Code equals c.Amount_Code
            //            join d in context.AmountType_Infos on c.Amount_TypeID equals d.Amount_TypeID
            //            where (b.RoleID == 2 || b.RoleID == 3) && b.UserName.Contains(UserName) && (d.AmountType_Name.Contains(Str) || c.Amount_Name.Contains(Str))
            //            select new ReportListModel()
            //            {
            //                AnswerAdd_ID = a.AnswerAdd_ID,
            //                Acode = a.Amount_Code,
            //                UserName = b.UserName,
            //                AName = c.Amount_Name,
            //                AtypeName = d.AmountType_Name,//c.Amount_TypeID
            //                AnswerTime = a.Answer_CreateTime,
            //                ARCode = a.AnswerAdd_Code,
            //                RoleType = RoleType
            //            }).ToList();
            //    tempTable.PageCount = list.Count / pageSize;
            //    if (list.Count < pageSize)
            //    {
            //        tempTable.PageCount = 1;
            //    }
            //    if (list.Count % pageSize != 0 && list.Count > pageSize)
            //    {
            //        tempTable.PageCount += 1;
            //    }
            //    list = list.OrderByDescending(m => m.AnswerTime).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
            //    tempTable.ModelList = list;
            //}
            else if (RoleType == 3)
            {
                list = (from a in context.AnswerAdds
                        join b in context.Users on a.AnswerPeople equals b.UserID
                        join c in context.Amount_Infos on a.Amount_Code equals c.Amount_Code
                        join d in context.AmountType_Infos on c.Amount_TypeID equals d.Amount_TypeID
                        where (b.RoleID == 3) && b.UserName.Contains(UserName) && (d.AmountType_Name.Contains(Str) || c.Amount_Name.Contains(Str))
                        select new ReportListModel()
                        {
                            AnswerAdd_ID = a.AnswerAdd_ID,
                            Acode = a.Amount_Code,
                            UserName = b.UserName,
                            AName = c.Amount_Name,
                            AtypeName = d.AmountType_Name,//c.Amount_TypeID
                            AnswerTime = a.Answer_CreateTime,
                            ARCode = a.AnswerAdd_Code,
                            RoleType = RoleType
                        }).ToList();
                list = list.OrderByDescending(m => m.AnswerTime).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
                tempTable.ModelList = list;
            }
            return tempTable;

        }
        /// <summary>
        /// 删除作答记录
        /// </summary>
        /// <param name="ncIDArray"></param>
        /// <returns></returns>
        public int RemoveAnswer(string[] ncIDArray)
        {
            for (int i = 0; i < ncIDArray.Length; i++)
            {
                var ncID = Convert.ToInt32(ncIDArray[i]);
                var entity = context.AnswerAdds.FirstOrDefault(m => m.AnswerAdd_ID == ncID);
                context.AnswerAdds.Remove(entity);
            }
            return context.SaveChanges();
        }
        public List<UAModel> AnswerAddModel(string AnswerAdd_Code)
        {
            var list = (from a in context.AnswerAdds
                        join b in context.Amount_Infos on a.Amount_Code equals b.Amount_Code
                        join c in context.Users on a.AnswerPeople equals c.UserID
                        where a.AnswerAdd_Code == AnswerAdd_Code
                        select new UAModel()
                        {
                            UName = c.UserName,
                            ARecode = a.AnswerAdd_Record,
                            AswerTime = a.Answer_CreateTime,
                            Amount_Name = b.Amount_Name,
                            Amount_Marks = b.Amount_Marks,
                            NewRcodes = a.NewRecord,
                            Acode = b.Amount_Code
                        }).ToList();
            return list;
        }
        public List<Amount_Info> GetAmount_Info(string Acode)
        {
            var models = (from a in context.Amount_Infos where a.Amount_Code == Acode select a).ToList();
            return models;
        }


        public List<ReportListModel> GetReportListshow(int pageSize, int pageIndex, DateTime beginTime, DateTime endTime, string str)
        {

            var tempList = context.AnswerAdds.Where(m=>m.AnswerIsDelete==0).OrderByDescending(m => m.Answer_CreateTime).ToList();
            if (beginTime != Convert.ToDateTime("1900-01-01") && endTime == Convert.ToDateTime("1900-01-01"))
            {
                var list = (from a in tempList
                            join b in context.Users on a.AnswerPeople equals b.UserID
                            join c in context.Amount_Infos on a.Amount_Code equals c.Amount_Code
                            join d in context.AmountType_Infos on c.Amount_TypeID equals d.Amount_TypeID
                            where (d.AmountType_Name.Contains(str) || c.Amount_Name.Contains(str)) && a.Answer_CreateTime > beginTime&&a.AnswerIsDelete==0
                            select new ReportListModel()
                            {
                                AnswerAdd_ID = a.AnswerAdd_ID,
                                Acode = a.Amount_Code,
                                UserName = b.UserName,
                                AName = c.Amount_Name,
                                IS_Delete = (int)a.AnswerIsDelete,
                                AtypeName = d.AmountType_Name,//c.Amount_TypeID
                                AnswerTime = a.Answer_CreateTime,
                                ARCode = a.AnswerAdd_Code
                            }).ToList();
                return list;
            }
            if (beginTime == Convert.ToDateTime("1900-01-01") && endTime != Convert.ToDateTime("1900-01-01"))
            {
                var list = (from a in tempList
                            join b in context.Users on a.AnswerPeople equals b.UserID
                            join c in context.Amount_Infos on a.Amount_Code equals c.Amount_Code
                            join d in context.AmountType_Infos on c.Amount_TypeID equals d.Amount_TypeID
                            where (d.AmountType_Name.Contains(str) || c.Amount_Name.Contains(str)) && a.Answer_CreateTime < endTime && a.AnswerIsDelete == 0
                            select new ReportListModel()
                            {
                                AnswerAdd_ID = a.AnswerAdd_ID,
                                Acode = a.Amount_Code,
                                UserName = b.UserName,
                                AName = c.Amount_Name,
                                IS_Delete = (int)a.AnswerIsDelete,
                                AtypeName = d.AmountType_Name,//c.Amount_TypeID
                                AnswerTime = a.Answer_CreateTime,
                                ARCode = a.AnswerAdd_Code
                            }).ToList();
                return list;
            }
            if (beginTime != Convert.ToDateTime("1900-01-01") && endTime != Convert.ToDateTime("1900-01-01"))
            {
                var list = (from a in tempList
                            join b in context.Users on a.AnswerPeople equals b.UserID
                            join c in context.Amount_Infos on a.Amount_Code equals c.Amount_Code
                            join d in context.AmountType_Infos on c.Amount_TypeID equals d.Amount_TypeID
                            where (d.AmountType_Name.Contains(str) || c.Amount_Name.Contains(str)) && (a.Answer_CreateTime > beginTime && a.Answer_CreateTime < endTime) && a.AnswerIsDelete == 0
                            select new ReportListModel()
                            {
                                AnswerAdd_ID = a.AnswerAdd_ID,
                                Acode = a.Amount_Code,
                                UserName = b.UserName,
                                AName = c.Amount_Name,
                                IS_Delete = (int)a.AnswerIsDelete,
                                AtypeName = d.AmountType_Name,//c.Amount_TypeID
                                AnswerTime = a.Answer_CreateTime,
                                ARCode = a.AnswerAdd_Code
                            }).ToList();
                return list;
            }
            if (beginTime == Convert.ToDateTime("1900-01-01") && endTime == Convert.ToDateTime("1900-01-01"))
            {
                var list = (from a in tempList
                            join b in context.Users on a.AnswerPeople equals b.UserID
                            join c in context.Amount_Infos on a.Amount_Code equals c.Amount_Code
                            join d in context.AmountType_Infos on c.Amount_TypeID equals d.Amount_TypeID
                            where d.AmountType_Name.Contains(str) || c.Amount_Name.Contains(str) && a.AnswerIsDelete == 0
                            select new ReportListModel()
                            {
                                AnswerAdd_ID = a.AnswerAdd_ID,
                                Acode = a.Amount_Code,
                                UserName = b.UserName,
                                AName = c.Amount_Name,
                                IS_Delete = (int)a.AnswerIsDelete,
                                AtypeName = d.AmountType_Name,//c.Amount_TypeID
                                AnswerTime = a.Answer_CreateTime,
                                ARCode = a.AnswerAdd_Code
                            }).ToList();
                return list;
            }
            return null;
        }
        public int UpdateAnswer(AnswerAdd user)
        {

            DbEntityEntry<AnswerAdd> entry = context.Entry<AnswerAdd>(user);
            entry.State = System.Data.Entity.EntityState.Unchanged;
            entry.Property("AnswerIsDelete").IsModified = true;
            return context.SaveChanges();
        }
    }


}
