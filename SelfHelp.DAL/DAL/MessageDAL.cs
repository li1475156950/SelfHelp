using SelfHelp.IDAL;
using SelfHelp.Models;
using SelfHelp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.DAL.DAL
{
    public class MessageDAL : DaoBase, IMessageDAL
    {
        public List<User> GetUserMList()
        {
            var list = (from a in context.Users
                        where a.RoleID == 2 || a.RoleID==1
                        select a).ToList();
            return list;
        }
        public int MsgAdd(Message UserModel)
        {
            context.Messages.Add(UserModel);
            return context.SaveChanges();
        }
        public int MsgTitleAdd(MessageTitle MsgTitle)
        {
            context.MessageTitles.Add(MsgTitle);
            context.SaveChanges();
            return MsgTitle.MsgTitleID;
        }
        public DataSet MessageModel(int Sender, int receiver, string title)
        {
            DataSet dt = new DataSet();
            var list = (from a in context.Messages
                        join b in context.Users on a.Sender equals b.UserID
                        join c in context.MessageTitles on a.TitleID equals c.MsgTitleID
                        where a.receiver == receiver && c.TiTle == title
                        select new UMsgModel()
                        {
                            TitleID = a.TitleID,
                            Content = a.Content,
                            UserName = b.UserName,
                            UserImg = b.UserImg,
                        }).ToList();
            var list1 = (from b in context.Messages where b.receiver == receiver select b).ToList();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();

            if (list.Count > 0)
            {
                dt1 = SelfHelp.Utility.Common.ListToDataTable<UMsgModel>(list);
            }
            if (list1.Count > 0)
            {
                dt2 = SelfHelp.Utility.Common.ListToDataTable<Message>(list1);
            }

            dt.Tables.Add(dt1);
            dt.Tables.Add(dt2);
            return dt;
        }

        //查看留言列表
        public DataSet Msglist(int pageSize, int pageIndex, string UserName, string MsgTitle, int receiver)
        {
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataSet dt = new DataSet();
            //var tempList = context.MessageTitles.OrderByDescending(m => m.CreateTime).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
            var tempList = context.MessageTitles.Where(c => c.CreateUID == receiver && !(from z in context.MsgDeletes where z.DeleteUserID == receiver select z.TiTleID).Contains(c.MsgTitleID)).OrderByDescending(m => m.CreateTime).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
            //foreach (var item in tempList)
            //{
            //    if (item.IsOpen == 0)
            //    {
            //        var Mylist = (from a in tempList
            //                      join c in context.Messages on a.MsgTitleID equals c.TitleID
            //                      join b in context.Users on c.receiver equals b.UserID
            //                      where c.receiver == receiver
            //                      select new MsgTitleModel()
            //                      {
            //                          TitleID = a.MsgTitleID,
            //                          UserName = b.UserName,
            //                          Title = a.TiTle,
            //                          IsOpen = a.IsOpen,
            //                          Creatime = a.CreateTime,
            //                          Sender = c.Sender,
            //                          RID = receiver,


            //                      }
            //            ).Distinct(new MyComparer()).ToList();
            //        if (Mylist.Count > 0)
            //        {
            //            dt1 = SelfHelp.Utility.Common.ListToDataTable<MsgTitleModel>(Mylist);
            //        }
            //    }
            //    else
            //    {
            //        var Mylist = (from a in tempList
            //                      join c in context.Messages on a.MsgTitleID equals c.TitleID

            //                      where a.IsOpen == 1
            //                      select new MsgTitleModel()
            //                      {
            //                          TitleID = a.MsgTitleID,

            //                          Title = a.TiTle,
            //                          IsOpen = a.IsOpen,
            //                          Creatime = a.CreateTime,
            //                          Sender = c.Sender,
            //                          RID = receiver,


            //                      }
            //                ).Distinct(new MyComparer()).ToList();
            //        if (Mylist.Count > 0)
            //        {
            //            dt2 = SelfHelp.Utility.Common.ListToDataTable<MsgTitleModel>(Mylist);
            //        }

            //    }


            //}

            if (tempList.Count> 0)
            {
                dt1 = SelfHelp.Utility.Common.ListToDataTable<MessageTitle>(tempList);
            }
            dt.Tables.Add(dt1);
            dt.Tables.Add(dt2);
            return dt;
           
        }
        //查询留言面板
        public List<MsgInfoModel> GetMsgR(int TitleID, int receiver)
        {
            var list = (from a in context.MessageTitles
                        join b in context.Messages on a.MsgTitleID equals b.TitleID
                        join c in context.Users on b.Sender equals c.UserID
                        where a.MsgTitleID == TitleID
                        select new MsgInfoModel 
                        { 
                            MessageID=b.MessageID,
                            receiver=b.receiver,
                            TitleID=b.TitleID,
                            Sender=b.Sender,
                            UserImg=c.UserImg,
                            UserName=c.UserName,
                            Content=b.Content,
                            Title=a.TiTle,
                            CreateUID=a.CreateUID,
                            RoleID=c.RoleID
                        }
                        ).ToList();
             return list;
        }

        public int RemoveMesList(string[] megIDArray)
        {
            for (int i = 0; i < megIDArray.Length; i++)
            {
                var mesID = Convert.ToInt32(megIDArray[i]);
                var entity = context.MessageTitles.FirstOrDefault(m => m.MsgTitleID == mesID);
                context.MessageTitles.Remove(entity);
            }
            return context.SaveChanges();
        }

        /// <summary>
        /// 查看公开留言
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public DataSet MessageModels(int Sender, string title)
        {
            DataSet dt = new DataSet();
            var list = (from a in context.Messages
                        join b in context.Users on a.Sender equals b.UserID
                        join c in context.MessageTitles on a.TitleID equals c.MsgTitleID
                        where c.TiTle == title
                        select new UMsgModel()
                        {
                            TitleID = a.TitleID,
                            Content = a.Content,
                            UserName = b.UserName,
                            UserImg = b.UserImg,
                        }).ToList();
            var list1 = (from b in context.Messages select b).ToList();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();

            if (list.Count > 0)
            {
                dt1 = SelfHelp.Utility.Common.ListToDataTable<UMsgModel>(list);
            }
            if (list1.Count > 0)
            {
                dt2 = SelfHelp.Utility.Common.ListToDataTable<Message>(list1);
            }

            dt.Tables.Add(dt1);
            dt.Tables.Add(dt2);
            return dt;
        }

        //管理端--查看留言列表
        //查看留言列表
        public MsgTitleTableViewModel AdminMsglist(int pageSize, int pageIndex, string UserName, string MsgTitle, int receiver, int RoleType)
        {

            List<MsgTitleModel> list = new List<MsgTitleModel>();
            var tempTable = new MsgTitleTableViewModel();
            if (RoleType == 1)
            {
                var tempList = context.MessageTitles.OrderBy(m => m.CreateTime).ToList();
                list = (from a in tempList
                        join c in context.Messages on a.MsgTitleID equals c.TitleID
                        //join b in context.Users on new { id = a.CreateUID, id1 = a.CreateUID } equals new {id= b.UserID,id1=0 }
                        join b in context.Users on a.CreateUID equals b.UserID
                        where !(from z in context.MsgDeletes where z.DeleteUserID == receiver select z.TiTleID).Contains(a.MsgTitleID) &&
                        b.UserName.Contains(UserName) && a.TiTle.Contains(MsgTitle)
                        select new MsgTitleModel()
                        {
                            TitleID = a.MsgTitleID,
                            UserName = b == null ? "" : b.UserName,
                            Title = a.TiTle,
                            IsOpen = a.IsOpen,
                            Creatime = a.CreateTime,
                            Sender = c.Sender,
                            RID = receiver,

                        }).Distinct(new MyComparer()).OrderByDescending(m => m.Creatime).ToList();
                tempTable.PageCount = list.Count / pageSize;
                if (list.Count < pageSize)
                {
                    tempTable.PageCount = 1;
                }
                if (list.Count % pageSize != 0 && list.Count > pageSize)
                {
                    tempTable.PageCount += 1;
                }
                list = list.OrderByDescending(m => m.Creatime).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
                tempTable.ModelList = list;
                return tempTable;
            }
            else if (RoleType == 2)
            {

                var tempList = context.MessageTitles.OrderBy(m => m.CreateTime).ToList();        
               list = (from a in tempList
                       join c in context.Messages on a.MsgTitleID equals c.TitleID
                       //join b in context.Users on new { id = a.CreateUID, id1 = a.CreateUID } equals new {id= b.UserID,id1=0 }
                       join b in context.Users on  a.CreateUID equals b.UserID

                       where !(from z in context.MsgDeletes where z.DeleteUserID == receiver select z.TiTleID).Contains(a.MsgTitleID)
                       &&(c.receiver == receiver  || a.CreateUID==receiver|| a.IsOpen == 1) && b.UserName.Contains(UserName) && a.TiTle.Contains(MsgTitle)
                      
                       select new MsgTitleModel()
                       {
                           TitleID = a.MsgTitleID,
                           UserName = b == null ? "" : b.UserName,
                           Title = a.TiTle,
                           IsOpen = a.IsOpen,
                           Creatime = a.CreateTime,
                           Sender = c.Sender,
                           RID = receiver,

                       }).Distinct(new MyComparer()).OrderByDescending(m => m.Creatime).ToList();
               tempTable.PageCount = list.Count / pageSize;
               if (list.Count < pageSize)
               {
                   tempTable.PageCount = 1;
               }
               if (list.Count % pageSize != 0 && list.Count > pageSize)
               {
                   tempTable.PageCount += 1;
               }
               list = list.OrderByDescending(m => m.Creatime).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
               tempTable.ModelList = list;
            }           
            return tempTable;
        }
        public int MsgDeleteAdd(MsgDelete MsgDeleteModel)
        {
            context.MsgDeletes.Add(MsgDeleteModel);
            context.SaveChanges();
            return MsgDeleteModel.DeleteUserID;

        }
        public List<MessageTitle> GetMsgTitle(int MsgTitleID)
        {
            var list = context.MessageTitles.Where(m => m.MsgTitleID == MsgTitleID).ToList();
            return list;
        }
    }
}
