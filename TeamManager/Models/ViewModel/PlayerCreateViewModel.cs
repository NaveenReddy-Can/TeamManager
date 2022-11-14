using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeamManager.Models.ViewModel
{
    public class PlayerCreateViewModel
    {

        public string Name { get; set; }

        public int Age { get; set; }
        public string TeamName { get; set; }
        public List<SelectListItem> TeamsDropDownItems { get; set; }
    }
}