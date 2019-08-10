using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Football_Pool.Models
{
    public class GameDataModel
    {
        public string AwayTeamName { get; set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamRecord { get; set; }
        public string HomeTeamRecord { get; set; }
        public string AwayFinalScore { get; set; }
        public string HomeFinalScore { get; set; }
        public string AQ1 { get; set; }
        public string AQ2 { get; set; }
        public string AQ3 { get; set; }
        public string AQ4 { get; set; }
        public string HQ1 { get; set; }
        public string HQ2 { get; set; }
        public string HQ3 { get; set; }
        public string HQ4 { get; set; }
        public string Year { get; set; }
        public string Week { get; set; }
    }
}