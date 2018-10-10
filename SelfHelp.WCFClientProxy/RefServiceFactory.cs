using System;
using SelfHelp.Contract;
using SelfHelp.BLL;

namespace SelfHelp.WCFClientProxy
{
    public class RefServiceFactory
    {
        public IService CreateService()
        {
            return new Service();
        }
        public IAdminLoginService CreateAdminLoginService()
        {
            return new AdminLoginService();
        }
        public IMyTestListService CreateMyTestListService()
        {
            return new MyTestListService();
        }
        public ISystemSettingsService CreateSystemSettingsService()
        {
            return new SystemSettingsService();
        }
        public IMessageService CreateMessageService()
        {
            return new MessageService();
        }
    }
}
