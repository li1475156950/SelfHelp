using SelfHelp.Contract;
using SelfHelp.DAL.DAL;
using SelfHelp.IDAL;
using SelfHelp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.BLL
{
    public class PsychologicalGameService : IPsychologicalGameService
    {
        public IPsychologicalGameDAL dal
        {
            get
            {
                return new PsychologicalGameDAL();
            }
        }
        public List<Game> GetGameList(int gTID)
        {
            return dal.FindAll<Game>(m=>m.GTID==gTID);
        }
        public Game GetGameByID(int gameID)
        {
            return dal.FindAll<Game>(m => m.GameID == gameID)[0];
        }
    }
}
