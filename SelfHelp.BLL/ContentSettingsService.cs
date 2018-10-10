using SelfHelp.Contract;
using SelfHelp.DAL.DAL;
using SelfHelp.IDAL;
using SelfHelp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelfHelp.Models.ViewModel;

namespace SelfHelp.BLL
{
    public class ContentSettingsService : IContentSettingsService
    {
        public IContentSettingsDAL dal;
        public ContentSettingsService()
        {
            dal = new ContentSettingsDAL();
        }

        public PsychologistTableViewModel GetPsychologistList(int pageSize, int pageIndex, string psyName)
        {
            return dal.GetPsychologistList(pageSize,pageIndex,psyName);
        }

        public int RemovePsychologists(string[] psyIDArray)
        {
            return dal.RemovePsychologists(psyIDArray);
        }

        public int AddPsychologist(Psychologist model)
        {
            return dal.InsertEntity(model);
        }

        public PsychologyExperimentsTableViewModel GetPsychologyExperimentsList(int pageSize, int pageIndex, string peName)
        {
            return dal.GetPsychologyExperimentsList(pageSize,pageIndex,peName);
        }

        public int RemovePsychologyExperiments(string[] pEIDArray)
        {
            return dal.RemovePsychologyExperiments(pEIDArray);
        }

        public int AddPsychologyExperiment(PsychologyExperiment model)
        {
            return dal.InsertEntity(model);
        }

        public PsychologyDictionaryTableViewModel GetPsychologyDictionaryesList(int pageSize, int pageIndex, string pDName)
        {
            return dal.GetPsychologyDictionaryesList(pageSize,pageIndex,pDName);
        }

        public int RemovePsychologyDictionaryes(string[] pDIDArray)
        {
            return dal.RemovePsychologyDictionaryes(pDIDArray);
        }

        public int AddPsychologyDictionary(PsychologyDictionary model)
        {
            return dal.InsertEntity(model);
        }

        public PsychologyImageTableViewModel GetPsychologyImageList(int pageSize, int pageIndex, string psyImgName, int psyImgType)
        {
            return dal.GetPsychologyImageList(pageSize, pageIndex, psyImgName,psyImgType);
        }

        public int RemovePsychologyImages(string[] psyImgIDArray)
        {
            return dal.RemovePsychologyImages(psyImgIDArray);
        }

        public int AddPsychologyImage(PsychologyImage model)
        {
            return dal.InsertEntity(model);
        }

        public PsychicArticleTableViewModel GetPsychicArticleList(int pageSize, int pageIndex, string psyArtName, int articleType)
        {
            return dal.GetPsychicArticleList(pageSize, pageIndex, psyArtName,articleType);
        }

        public int RemovePsychologyArticles(string[] psyArtArray)
        {
            return dal.RemovePsychologyArticles(psyArtArray);
        }

        public int AddPsychologyArticle(PsychicArticle model)
        {
            return dal.InsertEntity(model);
        }

        public List<PsychologyImageType> GetImageTypeList()
        {
            return dal.FindAll<PsychologyImageType>();
        }

        public RecommendBookTableViewModel GetPsychologyBooksList(int pageSize, int pageIndex, string BoName)
        {
            return dal.GetPsychologyBooksList(pageSize,pageIndex,BoName);
        }

        public int RemovePsychologyBooks(string[] BoIDArray)
        {
            return dal.RemovePsychologyBooks(BoIDArray);
        }

        public int AddPsychologyBooks(RecommendBook model)
        {
            return dal.InsertEntity(model);
        }

        public PsychologicalMusicTableViewModel GetPsychologicalMusicList(int pageSize, int pageIndex, string musicName, int musicType)
        {
            return dal.GetPsychologicalMusicList(pageSize, pageIndex, musicName, musicType);
        }

        /// <summary>
        /// 删除心理音乐
        /// </summary>
        /// <param name="BoIDArray"></param>
        /// <returns></returns>
        public int RemovePsychologicalMusics(string[] pMIDArray)
        {
            return dal.RemovePsychologicalMusics(pMIDArray);
        }
        public int AddPsychologicalMusic(PsychologicalMusic model)
        {
            return dal.InsertEntity(model);
        }
        public List<Psychologist> GetPsychologist()
        {
            return dal.GetPsychologist();
        }
        public List<PsychologyExperiment> GetPsychologyExperiment()
        {
            return dal.GetPsychologyExperiment();
        }
        public List<RecommendBook> GetPsychologyBooks()
        {
            return dal.GetPsychologyBooks();
        }
        public List<PsychologyImageViewModel> GetPsychologyImageLists()
        {
            return dal.GetPsychologyImageLists();
        }
        public List<PsychicArticleViewModel> GetPsychologyTypeList()
        {
            return dal.GetPsychologyTypeList();
        }
        public List<PsychologyDictionary> GetPsychologyDictionary() 
        {
            return dal.GetPsychologyDictionary();
        }
        public List<PsychologicalMusicJsonModel> GetMusicList(int mTID)
        {
            var tempList = dal.FindAll<PsychologicalMusic>(m => m.MTID == mTID).Select(m=>
                new PsychologicalMusicJsonModel() { 
                 album = m.PMName,
                 title = m.PMName,
                 artist = "",
                 cover = m.PMImgSrc,
                 mp3 = m.PMSrc,
                 TabID = m.TabID,
                 PMID = m.PMID
                }
                );
            return tempList.ToList();
        }
    }
}
