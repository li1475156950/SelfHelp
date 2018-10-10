using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using SelfHelp.Models;
namespace SelfHelp.Contract
{
    [ServiceContract]
    public interface IPsychologicalGameService
    {
        [OperationContract]
        List<Game> GetGameList(int gTID);
        [OperationContract]
        Game GetGameByID(int gameID);
    }
}
