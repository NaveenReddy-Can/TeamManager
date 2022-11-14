using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamManager.Interfaces;
using TeamManager.Models;
using System.Data.Entity;
using System.Web.Mvc;

namespace TeamManager.Services
{
    public class PlayerService : IPlayerService
    {

        private ApplicationDbContext db;
        
        public PlayerService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public bool AddPlayer(Player player)
        {
            try
            {
                db.Players.Add(player);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Player> GetAllPlayersOnTeam(string name)
        {
            return db.Players.Where(p => p.TeamName == name).ToList();
        }

        public IEnumerable<String> GetAllTeamNames()
        {
            return db.Players.Select(p => p.TeamName).Distinct();
        }

        public List<SelectListItem> GetAllTeamNamesDropDown()
        {
            return this.GetAllTeamNames().Select(n => new SelectListItem { Text = n, Value = n }).ToList();
        }
    }
}