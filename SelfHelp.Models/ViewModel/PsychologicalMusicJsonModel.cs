using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models.ViewModel
{
    public class PsychologicalMusicJsonModel
    {
        public string title { get; set; }
        public string artist { get; set; }
        public string album { get; set; }
        public string cover { get; set; }
        public string mp3 { get; set; }
        public string ogg 
        {
            get 
            {
                return "";
            } 
        }
        public int TabID { get; set; }
        public int PMID { get; set; }
    }
}
