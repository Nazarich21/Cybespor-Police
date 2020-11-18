using System.Collections.Generic;

namespace CyberSportPolice
{
    public class Game
    {
        public string match_id { get; set; }
        public string duration { get; set; }
        public string start_time { get; set; }
        public string radiant_team_id { get; set; }
        public string radiant_name { get; set; }
        public string dire_team_id { get; set; }
        public string dire_name { get; set; }
        public string leagueid { get; set; }
        public string league_name { get; set; }
        public string series_id { get; set; }
        public string series_type { get; set; }
        public string radiant_score { get; set; }
        public string dire_score { get; set; }
        public bool radiant_win { get; set; }
    }
}