using SelfHelp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelfHelp.Models.ViewModel;

namespace SelfHelp.IDAL
{
    public interface IContentSettingsDAL : IRepository
    {
        int RemovePsychologists(string[] psyIDArray);
        int RemovePsychologyExperiments(string[] pEIDArray);
        int RemovePsychologyDictionaryes(string[] pDIDArray);
        int RemovePsychologyImages(string[] psyImgIDArray);
        int RemovePsychologyArticles(string[] psyArtArray);
        RecommendBookTableViewModel GetPsychologyBooksList(int pageSize, int pageIndex, string BoName);
        PsychologyDictionaryTableViewModel GetPsychologyDictionaryesList(int pageSize, int pageIndex, string pDName);
        PsychologyExperimentsTableViewModel GetPsychologyExperimentsList(int pageSize, int pageIndex, string peName);
        PsychicArticleTableViewModel GetPsychicArticleList(int pageSize, int pageIndex, string psyArtName, int articleType);
        PsychologyImageTableViewModel GetPsychologyImageList(int pageSize, int pageIndex, string psyImgName, int psyImgType);
        int RemovePsychologyBooks(string[] BoIDArray);
        PsychologicalMusicTableViewModel GetPsychologicalMusicList(int pageSize, int pageIndex, string musicName, int musicType);
        int RemovePsychologicalMusics(string[] pMIDArray);
        List<Psychologist> GetPsychologist();
        List<PsychologyExperiment> GetPsychologyExperiment();
        List<RecommendBook> GetPsychologyBooks();
        List<PsychologyImageViewModel> GetPsychologyImageLists();
        List<PsychicArticleViewModel> GetPsychologyTypeList();
        List<PsychologyDictionary> GetPsychologyDictionary();
        PsychologistTableViewModel GetPsychologistList(int pageSize, int pageIndex, string psyName);
    }
}
