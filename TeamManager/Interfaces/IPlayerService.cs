using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TeamManager.Models;

namespace TeamManager.Interfaces
{
    public interface IPlayerService
    {

        bool AddPlayer(Player player);

        IEnumerable<Player> GetAllPlayersOnTeam(string name);

        IEnumerable<string> GetAllTeamNames();

        List<SelectListItem> GetAllTeamNamesDropDown();
    }
}
