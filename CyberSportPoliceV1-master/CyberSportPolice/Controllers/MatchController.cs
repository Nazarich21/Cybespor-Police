using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CyberSportPolice.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("match")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Game> Get([FromQuery(Name = "sort")] bool sort,[FromQuery(Name = "teamId")] string teamId, [FromQuery(Name = "eventId")] string eventId)
        {
            WebRequest request = WebRequest.Create(
                "https://api.opendota.com/api/proMatches?api_key=0d9ea615-12c0-44e8-9bf4-4de22e618aca");

            WebResponse response = request.GetResponse();
            
            List<Game> games = new List<Game>();
            
            using (Stream dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                var responseFromServer = reader.ReadToEnd();
                games = JsonConvert.DeserializeObject<List<Game>>(responseFromServer);
                response.Close();
            }

            if (teamId != null)
            {
                games = games.Where(item => item.dire_team_id == teamId || item.radiant_team_id == teamId).ToList();
            }
            
            if (eventId != null)
            {
                games = games.Where(item => item.series_id == eventId).ToList();
            }

            if (sort)
            {
                games = games.OrderByDescending(item => item.start_time).ToList();
            }

            if (!sort)
            {
                games = games.OrderBy(item => item.start_time).ToList();
            }

            return games;
        }
    }
}