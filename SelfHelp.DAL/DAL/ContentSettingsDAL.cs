using SelfHelp.IDAL;
using SelfHelp.Models;
using SelfHelp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.DAL.DAL
{
    public class ContentSettingsDAL : DaoBase, IContentSettingsDAL
    {
        public int RemovePsychologists(string[] psyIDArray)
        {
            for (int i = 0; i < psyIDArray.Length; i++)
            {
                var psyID = Convert.ToInt32(psyIDArray[i]);
                var entity = context.Psychologists.FirstOrDefault(m => m.PsyID == psyID);
                context.Psychologists.Remove(entity);
            }
            return context.SaveChanges();
        }
        public int RemovePsychologyExperiments(string[] pEIDArray)
        {
            for (int i = 0; i < pEIDArray.Length; i++)
            {
                var peID = Convert.ToInt32(pEIDArray[i]);
                var entity = context.PsychologyExperiments.FirstOrDefault(m => m.PEID == peID);
                context.PsychologyExperiments.Remove(entity);
            }
            return context.SaveChanges();
        }
        public int RemovePsychologyDictionaryes(string[] pDIDArray)
        {
            for (int i = 0; i < pDIDArray.Length; i++)
            {
                var pDID = Convert.ToInt32(pDIDArray[i]);
                var entity = context.PsychologyDictionaryes.FirstOrDefault(m => m.PDID == pDID);
                context.PsychologyDictionaryes.Remove(entity);
            }
            return context.SaveChanges();
        }
        public int RemovePsychologyImages(string[] psyImgIDArray)
        {
            for (int i = 0; i < psyImgIDArray.Length; i++)
            {
                var psyImgID = Convert.ToInt32(psyImgIDArray[i]);
                var entity = context.PsychologyImages.FirstOrDefault(m => m.PsyImgID == psyImgID);
                context.PsychologyImages.Remove(entity);
            }
            return context.SaveChanges();
        }
        public RecommendBookTableViewModel GetPsychologyBooksList(int pageSize, int pageIndex, string BoName)
        {
            var tempTable = new RecommendBookTableViewModel();
            var totalCount = context.RecommendBooks.Where(m => m.RecBoName.Contains(BoName)).ToList().Count;
            tempTable.PageCount = totalCount / pageSize;
            if (totalCount < pageSize)
            {
                tempTable.PageCount = 1;
            }
            if (totalCount % pageSize != 0 && totalCount > pageSize)
            {
                tempTable.PageCount += 1;
            }
            SqlParameter[] param = { 
                new SqlParameter("@BoName","%"+BoName+"%")
                                   };
            var convertList = new List<RecommendBook>();
            convertList = context.Database.SqlQuery<RecommendBook>("select * from RecommendBook where RecBoName like @BoName order by CreateTime desc", param).ToList().Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            tempTable.ModelList = convertList;
            return tempTable;
        }
        public PsychologyDictionaryTableViewModel GetPsychologyDictionaryesList(int pageSize, int pageIndex, string pDName)
        {
            var tempTable = new PsychologyDictionaryTableViewModel();
            var totalCount = context.PsychologyDictionaryes.Where(m => m.PDName.Contains(pDName)).ToList().Count;
            tempTable.PageCount = totalCount / pageSize;
            if (totalCount < pageSize)
            {
                tempTable.PageCount = 1;
            }
            if (totalCount % pageSize != 0 && totalCount > pageSize)
            {
                tempTable.PageCount += 1;
            }
            SqlParameter[] param = { 
                new SqlParameter("@pDName","%"+pDName+"%")
                                   };
            var convertList = new List<PsychologyDictionary>();
            convertList = context.Database.SqlQuery<PsychologyDictionary>("select * from PsychologyDictionary  where PDName like @pDName order by CreateTime desc", param).ToList().Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            tempTable.ModelList = convertList;
            return tempTable;
        }
        public PsychologyExperimentsTableViewModel GetPsychologyExperimentsList(int pageSize, int pageIndex, string peName)
        {
            var tempTable = new PsychologyExperimentsTableViewModel();
            var totalCount = context.PsychologyExperiments.Where(m => m.PEName.Contains(peName)).ToList().Count;
            tempTable.PageCount = totalCount / pageSize;
            if (totalCount < pageSize)
            {
                tempTable.PageCount = 1;
            }
            if (totalCount % pageSize != 0 && totalCount > pageSize)
            {
                tempTable.PageCount += 1;
            }
            SqlParameter[] param = { 
                new SqlParameter("@peName","%"+peName+"%")
                                   };
            var convertList = new List<PsychologyExperiment>();
            convertList = context.Database.SqlQuery<PsychologyExperiment>("select *  from PsychologyExperiment where PEName like @peName order by CreateTime desc", param).ToList().Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            tempTable.ModelList = convertList;
            return tempTable;
        }
        public PsychologistTableViewModel GetPsychologistList(int pageSize, int pageIndex, string psyName)
        {
            var tempTable = new PsychologistTableViewModel();
            var totalCount = context.Psychologists.Where(m => m.PsyName.Contains(psyName)).ToList().Count;
            tempTable.PageCount = totalCount / pageSize;
            if (totalCount < pageSize)
            {
                tempTable.PageCount = 1;
            }
            if (totalCount % pageSize != 0 && totalCount > pageSize)
            {
                tempTable.PageCount += 1;
            }
            SqlParameter[] param = { 
                new SqlParameter("@psyName","%"+psyName+"%")
                                   };
            var convertList = new List<Psychologist>();
            convertList = context.Database.SqlQuery<Psychologist>("select * from Psychologist where PsyName like @psyName order by CreateTime desc", param).ToList().Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            tempTable.ModelList = convertList;
            return tempTable;

        }
        public PsychologyImageTableViewModel GetPsychologyImageList(int pageSize, int pageIndex, string psyImgName, int psyImgType)
        {
            var tempTable = new PsychologyImageTableViewModel();
            var totalCount = context.PsychologyImages.Where(m => m.PsyImgName.Contains(psyImgName)).ToList().Count;
            if (psyImgType != 0)
            {
                totalCount = context.PsychologyImages.Where(m => m.PsyImgName.Contains(psyImgName) && m.PsyImgTypeID == psyImgType).ToList().Count;
            }
            tempTable.PageCount = totalCount / pageSize;
            if (totalCount < pageSize)
            {
                tempTable.PageCount = 1;
            }
            if (totalCount % pageSize != 0 && totalCount > pageSize)
            {
                tempTable.PageCount += 1;
            }
            SqlParameter[] param = { 
                new SqlParameter("@psyImgName","%"+psyImgName+"%"),
                new SqlParameter("@psyImgType",psyImgType)
                                   };
            var convertList = new List<PsychologyImageViewModel>();
            if (psyImgType == 0)
            {
                convertList = context.Database.SqlQuery<PsychologyImageViewModel>("select PsychologyImage.*,PsychologyImageType.PsyImgTypeName from PsychologyImage inner join PsychologyImageType on PsychologyImage.PsyImgTypeID = PsychologyImageType.PsyImgTypeID where PsychologyImage.PsyImgName like @psyImgName order by CreateTime desc", param).ToList().Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
            if (psyImgType != 0)
            {
                convertList = context.Database.SqlQuery<PsychologyImageViewModel>("select PsychologyImage.*,PsychologyImageType.PsyImgTypeName from PsychologyImage inner join PsychologyImageType on PsychologyImage.PsyImgTypeID = PsychologyImageType.PsyImgTypeID where PsychologyImage.PsyImgName like @psyImgName and PsychologyImage.PsyImgTypeID =@psyImgType order by CreateTime desc", param).ToList().Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
            tempTable.ModelList = convertList;
            return tempTable;
        }
        public int RemovePsychologyArticles(string[] psyArtArray)
        {
            for (int i = 0; i < psyArtArray.Length; i++)
            {
                var psyArtID = Convert.ToInt32(psyArtArray[i]);
                var entity = context.PsychicArticles.FirstOrDefault(m => m.PAID == psyArtID);
                context.PsychicArticles.Remove(entity);
            }
            return context.SaveChanges();
        }
        public PsychicArticleTableViewModel GetPsychicArticleList(int pageSize, int pageIndex, string psyArtName, int articleType)
        {
            var tempTable = new PsychicArticleTableViewModel();
            var totalCount = context.PsychicArticles.Where(m => m.PAName.Contains(psyArtName)).ToList().Count;
            if (articleType != 0)
            {
                totalCount = context.PsychicArticles.Where(m => m.PAName.Contains(psyArtName) && m.ATID == articleType).ToList().Count;
            }
            tempTable.PageCount = totalCount / pageSize;
            if (totalCount < pageSize)
            {
                tempTable.PageCount = 1;
            }
            if (totalCount % pageSize != 0 && totalCount > pageSize)
            {
                tempTable.PageCount += 1;
            }
            SqlParameter[] param = { 
                new SqlParameter("@psyArtName","%"+psyArtName+"%"),
                new SqlParameter("@articleType",articleType)
                                   };
            var convertList = new List<PsychicArticleViewModel>();
            if (articleType != 0)
            {
                convertList = context.Database.SqlQuery<PsychicArticleViewModel>("select PsychicArticle.*,ATName from PsychicArticle inner join ArticleType on PsychicArticle.ATID = ArticleType.ATID where PsychicArticle.PAName like @psyArtName and PsychicArticle.ATID =@articleType order by CreateTime desc", param).ToList().Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
            else
            {
                convertList = context.Database.SqlQuery<PsychicArticleViewModel>("select PsychicArticle.*,ATName from PsychicArticle inner join ArticleType on PsychicArticle.ATID = ArticleType.ATID where PsychicArticle.PAName like @psyArtName order by CreateTime desc", param).ToList().Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
            tempTable.ModelList = convertList;
            return tempTable;
        }
        public int RemovePsychologyBooks(string[] BoIDArray)
        {
            for (int i = 0; i < BoIDArray.Length; i++)
            {
                var boID = Convert.ToInt32(BoIDArray[i]);
                var entity = context.RecommendBooks.FirstOrDefault(m => m.RecBoID == boID);
                context.RecommendBooks.Remove(entity);
            }
            return context.SaveChanges();
        }
        public PsychologicalMusicTableViewModel GetPsychologicalMusicList(int pageSize, int pageIndex, string musicName, int musicType)
        {
            var tempTable = new PsychologicalMusicTableViewModel();
            var totalCount = context.PsychologicalMusics.Where(m => m.PMName.Contains(musicName)).ToList().Count;
            if (musicType != 0)
            {
                totalCount = context.PsychologicalMusics.Where(m => m.PMName.Contains(musicName) && m.MTID == musicType).ToList().Count;
            }
            tempTable.PageCount = totalCount / pageSize;
            if (totalCount < pageSize)
            {
                tempTable.PageCount = 1;
            }
            if (totalCount % pageSize != 0 && totalCount > pageSize)
            {
                tempTable.PageCount += 1;
            }
            SqlParameter[] param = { 
                new SqlParameter("@musicName","%"+musicName+"%"),
                new SqlParameter("@musicType",musicType)
                                   };
            var convertList = new List<PsychologicalMusicViewModel>();
            if (musicType != 0)
            {
                convertList = context.Database.SqlQuery<PsychologicalMusicViewModel>("select PsychologicalMusic.*,MusicType.MTName from PsychologicalMusic inner join MusicType on MusicType.MTID = PsychologicalMusic.MTID where PsychologicalMusic.PMName like @musicName and MusicType.MTID = @musicType order by CreateTime desc", param).ToList().Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
            else
            {
                convertList = context.Database.SqlQuery<PsychologicalMusicViewModel>("select PsychologicalMusic.*,MusicType.MTName from PsychologicalMusic inner join MusicType on MusicType.MTID = PsychologicalMusic.MTID where PsychologicalMusic.PMName like @musicName order by CreateTime desc", param).ToList().Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
            tempTable.ModelList = convertList;
            return tempTable;

        }
        public int RemovePsychologicalMusics(string[] pMIDArray)
        {
            for (int i = 0; i < pMIDArray.Length; i++)
            {
                var pMID = Convert.ToInt32(pMIDArray[i]);
                var entity = context.PsychologicalMusics.FirstOrDefault(m => m.PMID == pMID);
                context.PsychologicalMusics.Remove(entity);
            }
            return context.SaveChanges();
        }
        public List<Psychologist> GetPsychologist()
        {
            return context.Psychologists.ToList();
        }
        public List<PsychologyExperiment> GetPsychologyExperiment()
        {
            return context.PsychologyExperiments.ToList();
        }
        public List<RecommendBook> GetPsychologyBooks()
        {
            return context.RecommendBooks.ToList();
        }
        public List<PsychologyImageViewModel> GetPsychologyImageLists()
        {
            var psyImage = from images in context.PsychologyImages
                           join tp in context.PsychologyImageTypes
                           on images.PsyImgTypeID equals tp.PsyImgTypeID
                           select new PsychologyImageViewModel() { CreatePerson = images.CreatePerson, CreateTime = images.CreateTime, PsyImgID = images.PsyImgID, PsyImgName = images.PsyImgName, PsyImgSrc = images.PsyImgSrc, PsyImgTypeID = tp.PsyImgTypeID, PsyImgTypeName = tp.PsyImgTypeName };
            return psyImage.ToList();
        }
        public List<PsychicArticleViewModel> GetPsychologyTypeList()
        {
            var article = from a in context.PsychicArticles
                          join t in context.ArticleTypes
                          on a.ATID equals t.ATID
                          select new PsychicArticleViewModel() { CreatePerson = a.CreatePerson, CreateTime = a.CreateTime, ATID = a.ATID, ATName = t.ATName, PAContent = a.PAContent, PAID = a.PAID, PAName = a.PAName, TabID = a.TabID };
            return article.ToList();
        }
        public List<PsychologyDictionary> GetPsychologyDictionary()
        {
            return context.PsychologyDictionaryes.ToList();
        }
    }
}
