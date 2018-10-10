using System;
using System.Data.Entity;
using SelfHelp.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.Composition;
using System.Configuration;
namespace SelfHelp.DAL
{
    [Export("DB")]
    public class DbContext : System.Data.Entity.DbContext
    {
        public DbContext()
            : base("MyDbContext")
        {
            
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = false;
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Amount_Info> Amount_Infos { get; set; }
        public DbSet<Amount_Dimension_Relation> Amount_Dimension_Relations { get; set; }
        public DbSet<AmountDimension_Info> AmountDimension_Infos { get; set; }
        public DbSet<Dimension_Norm_Relation> Dimension_Norm_Relation { get; set; }
        public DbSet<Dimension_Subject_Relation> Dimension_Subject_Relations { get; set; }
        public DbSet<DimensionFormula_Info> DimensionFormula_Infos { get; set; }
        public DbSet<Norm_Info> Norm_Infos { get; set; }
        public DbSet<Operation_Info> Operation_Infos { get; set; }
        public DbSet<Subject_Info> Subject_Infos { get; set; }
        public DbSet<Subject_Operation_Relation> Subject_Operation_Relations { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<Amount_Subject_Relation> Amount_Subject_Relations { get; set; }
        public DbSet<NewsCenter> NewsCenters { get; set; }
        public DbSet<Psychologist> Psychologists { get; set; }
        public DbSet<PsychicArticle> PsychicArticles { get; set; }
        public DbSet<ArticleType> ArticleTypes { get; set; }
        public DbSet<PsychologyExperiment> PsychologyExperiments { get; set; }
        public DbSet<PsychologyDictionary> PsychologyDictionaryes { get; set; }
        public DbSet<AnswerAdd> AnswerAdds { get; set; }
        public DbSet<PsychologyImage> PsychologyImages { get; set; }
        public DbSet<PsychologyImageType> PsychologyImageTypes { get; set; }
        public DbSet<RecommendBook> RecommendBooks { get; set; }
        public DbSet<Norm_Explain_Relation> Norm_Explain_Relations { get; set; }
        public DbSet<NormExplain_Info> NormExplain_Infos { get; set; }
        public DbSet<MovieAppreciation> MovieAppreciations { get; set; }
        public DbSet<AmountType_Info> AmountType_Infos { get; set; }
        public DbSet<PsychologicalMusic> PsychologicalMusics { get; set; }
        public DbSet<MusicType> MusicTypes { get; set; }
        public DbSet<VideoClip> VideoClips { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<GameType> GameTypes { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<MessageTitle> MessageTitles { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<TabType> TabTypes { get; set; }
        public DbSet<Tab> Tabs { get; set; }
        public DbSet<AnalysisData> AnalysisDatas { get; set; }
        public DbSet<MsgDelete> MsgDeletes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //禁用表的复数形式
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(500));
            //if (EntityMappers == null)
            //{
            //    return;
            //    //throw PublicHelper.ThrowDataAccessException("实体映射对象个数为0，创建DbContext上下文对象失败。");
            //}

            //foreach (var mapper in EntityMappers)
            //{
            //    mapper.RegistTo(modelBuilder.Configurations);
            //}
        }
    }
}
