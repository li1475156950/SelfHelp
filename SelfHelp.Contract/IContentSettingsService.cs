using SelfHelp.Models;
using SelfHelp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Contract
{
    [ServiceContract(Namespace = "SelfHelp.WCFService")]
    public interface IContentSettingsService
    {
        [OperationContract]
        PsychologistTableViewModel GetPsychologistList(int pageSize, int pageIndex, string psyName);
        [OperationContract]
        int RemovePsychologists(string[] psyIDArray);
        [OperationContract]
        int AddPsychologist(Psychologist model);
        [OperationContract]
        PsychologyExperimentsTableViewModel GetPsychologyExperimentsList(int pageSize, int pageIndex, string peName);
        [OperationContract]
        int RemovePsychologyExperiments(string[] pEIDArray);
        [OperationContract]
        int AddPsychologyExperiment(PsychologyExperiment model);
        [OperationContract]
        PsychologyDictionaryTableViewModel GetPsychologyDictionaryesList(int pageSize, int pageIndex, string pDName);
        [OperationContract]
        int RemovePsychologyDictionaryes(string[] pDIDArray);
        [OperationContract]
        int AddPsychologyDictionary(PsychologyDictionary model);
        [OperationContract]
        int RemovePsychologyImages(string[] psyImgIDArray);
        [OperationContract]
        int AddPsychologyImage(PsychologyImage model);
        [OperationContract]
        PsychicArticleTableViewModel GetPsychicArticleList(int pageSize, int pageIndex, string psyArtName, int articleType);
        [OperationContract]
        int RemovePsychologyArticles(string[] psyArtArray);
        [OperationContract]
        int AddPsychologyArticle(PsychicArticle model);
        [OperationContract]
        PsychologyImageTableViewModel GetPsychologyImageList(int pageSize, int pageIndex, string psyImgName, int psyImgType);
        [OperationContract]
        List<PsychologyImageType> GetImageTypeList();
        [OperationContract]
        RecommendBookTableViewModel GetPsychologyBooksList(int pageSize, int pageIndex, string BoName);
        [OperationContract]
        int RemovePsychologyBooks(string[] BoIDArray);
        [OperationContract]
        int AddPsychologyBooks(RecommendBook model);
        [OperationContract]
        PsychologicalMusicTableViewModel GetPsychologicalMusicList(int pageSize, int pageIndex, string musicName, int musicType);
        [OperationContract]
        int RemovePsychologicalMusics(string[] pMIDArray);
        [OperationContract]
        int AddPsychologicalMusic(PsychologicalMusic model);
        [OperationContract]
        List<Psychologist> GetPsychologist();
        [OperationContract]
        List<PsychologyExperiment> GetPsychologyExperiment();
        [OperationContract]
        List<RecommendBook> GetPsychologyBooks();
        [OperationContract]
        List<PsychologyImageViewModel> GetPsychologyImageLists();
        [OperationContract]
        List<PsychicArticleViewModel> GetPsychologyTypeList();
        [OperationContract]
        List<PsychologyDictionary> GetPsychologyDictionary();
        [OperationContract]
        List<PsychologicalMusicJsonModel> GetMusicList(int mTID);
    }
}
