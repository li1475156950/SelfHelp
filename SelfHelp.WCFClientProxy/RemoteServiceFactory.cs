using System;
using System.ServiceModel;
using SelfHelp.Utility;
using System.Xml;
using System.ServiceModel.Description;
using SelfHelp.Contract;
using System.Configuration;
namespace SelfHelp.WCFClientProxy
{
    public class RemoteServiceFactory : IServiceFactory
    {
        //need to get it from a config file after implemented a dynamic config manage module
        public string serviceUrl = "";
        public string servicePrefix = ConfigurationManager.AppSettings["ServicePrefix"].ToString();
        public IService CreateService()
        {
            serviceUrl = servicePrefix + "/Service.svc";
            return this.CreateService<IService>(serviceUrl);
        }
        public IAdminLoginService CreateAdminLoginService()
        {
            serviceUrl = servicePrefix + "/AdminLoginService.svc";
            return this.CreateService<IAdminLoginService>(serviceUrl);
        }
        public IMyTestListService CreateMyTestListService()
        {
            serviceUrl = servicePrefix+ "/MyTestListService.svc";
            return this.CreateService<IMyTestListService>(serviceUrl);
            
        }
        public ISystemSettingsService CreateSystemSettingsService()
        {
            serviceUrl = servicePrefix + "/SystemSettingsService.svc";
            return this.CreateService<ISystemSettingsService>(serviceUrl);
        }
        public IStartAnswerService CreateStartAnswerService()
        {
            serviceUrl = servicePrefix + "/StartAnswerService.svc";
            return this.CreateService<IStartAnswerService>(serviceUrl);
        }
        public IContentSettingsService CreateContentSettingsService()
        {
            serviceUrl = servicePrefix + "/ContentSettingsService.svc";
            return this.CreateService<IContentSettingsService>(serviceUrl);
        }
        public IPsychologyVideoService CreatePsychologyVideoService()
        {
            serviceUrl = servicePrefix + "/PsychologyVideoService.svc";
            return this.CreateService<IPsychologyVideoService>(serviceUrl);
        }
        public IMessageService CreateMessageService()
        {
            serviceUrl = servicePrefix + "/MessageService.svc";
            return this.CreateService<IMessageService>(serviceUrl);
        }
        public IPsychologicalGameService CreatePsychologicalGameService()
        {
            serviceUrl = servicePrefix + "/PsychologicalGameService.svc";
            return this.CreateService<IPsychologicalGameService>(serviceUrl);
        }
        private T CreateService<T>(string uri)
        {
            var key = string.Format("{0} - {1}", typeof(T), uri);

            if (Caching.Get(key) == null)
            {
                var binding = new BasicHttpBinding();
                binding.MaxReceivedMessageSize = maxReceivedMessageSize;
                binding.ReaderQuotas = new XmlDictionaryReaderQuotas();
                binding.ReaderQuotas.MaxStringContentLength = maxReceivedMessageSize;
                binding.ReaderQuotas.MaxArrayLength = maxReceivedMessageSize;
                binding.ReaderQuotas.MaxBytesPerRead = maxReceivedMessageSize;

                ChannelFactory<T> chan = new ChannelFactory<T>(binding, new EndpointAddress(uri));
                chan.Endpoint.Behaviors.Add(new SelfHelp.WCFExtension.InspectorBehavior());
                foreach (var op in chan.Endpoint.Contract.Operations)
                {
                    var dataContractBehavior = op.Behaviors.Find<DataContractSerializerOperationBehavior>() as DataContractSerializerOperationBehavior;
                    if (dataContractBehavior != null)
                        dataContractBehavior.MaxItemsInObjectGraph = int.MaxValue;
                }

                chan.Open();

                var service = chan.CreateChannel();
                Caching.Set(key, service);

                return service;
            }
            else
            {
                return (T)Caching.Get(key);
            }
        }

        private const int maxReceivedMessageSize = 2147483647;
    }
}
