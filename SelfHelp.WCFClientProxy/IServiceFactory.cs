using System;
using SelfHelp.Contract;

namespace SelfHelp.WCFClientProxy
{
    public interface IServiceFactory
    {
        IService CreateService();
        IAdminLoginService CreateAdminLoginService();
        IMyTestListService CreateMyTestListService();
        ISystemSettingsService CreateSystemSettingsService();
        IStartAnswerService CreateStartAnswerService();
        IPsychologyVideoService CreatePsychologyVideoService();
        IContentSettingsService CreateContentSettingsService();
        IMessageService CreateMessageService();
        IPsychologicalGameService CreatePsychologicalGameService();
    }
}
