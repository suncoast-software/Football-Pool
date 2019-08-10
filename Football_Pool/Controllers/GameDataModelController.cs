using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using Football_Pool.Models;
using System.Web.UI;

namespace Football_Pool.Controllers
{
    public class GameDataModelController : Controller
    {
       
        // GET: GameDataModel
        [HttpPost]
        public ActionResult Index(string txtSearch)
        {
            List<GameDataModel> games = new List<GameDataModel>();
           
            string[] details = txtSearch.Split(' ');
            string conStr = ConfigurationManager.ConnectionStrings["nfldb"].ConnectionString;
            MySqlConnection con = new MySqlConnection(conStr);
            string query;
            if (details.Count() < 2)
            {
                query = "SELECT * FROM Game WHERE Year ='" + details[0] + "'";
            }
            else
            {
                query = "SELECT * FROM Game WHERE Year ='" + details[0] + "'" + "&& Week='" + details[1] + "'";
            }
            
            MySqlCommand command = new MySqlCommand(query);
            command.Connection = con;
            con.Open();
            MySqlDataReader reader = command.ExecuteReader();
            //txtSearch = null;
            while (reader.Read())
            {
                games.Add(new GameDataModel
                {
                    AwayTeamName = reader["AwayTeamName"].ToString(),
                    HomeTeamName = reader["HomeTeamName"].ToString(),
                    AwayTeamRecord = reader["AwayTeamRecord"].ToString(),
                    HomeTeamRecord = reader["HomeTeamRecord"].ToString(),
                    AwayFinalScore = reader["AwayFinalScore"].ToString(),
                    HomeFinalScore = reader["HomeFinalScore"].ToString(),
                    AQ1 = reader["AQ1"].ToString(),
                    AQ2 = reader["AQ2"].ToString(),
                    AQ3 = reader["AQ3"].ToString(),
                    AQ4 = reader["AQ4"].ToString(),
                    HQ1 = reader["HQ1"].ToString(),
                    HQ2 = reader["HQ2"].ToString(),
                    HQ3 = reader["HQ3"].ToString(),
                    HQ4 = reader["HQ4"].ToString(),
                    Year = reader["Year"].ToString(),
                    Week = reader["Week"].ToString()
                }); 
            }
            con.Close();

            if (games == null)
            {
                ViewBag.Message = "There are no results for your search!";
            }
           
            return View(games);
        }

        public ActionResult Index()
        {
            List<GameDataModel> games = new List<GameDataModel>();
            return View(games);
        }
    }
}