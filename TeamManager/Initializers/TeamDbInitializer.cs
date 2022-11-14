using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;
using TeamManager.Models;

namespace TeamManager.Initializers
{
    public class TeamDBInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            context.Players.Add(new Player { ID = 1, Name = "Virat", Age = 25, TeamName = "India-A" });
            context.Players.Add(new Player { ID = 2, Name = "Samson", Age = 26, TeamName = "India-B" });
            context.Players.Add(new Player { ID = 3, Name = "Rahul", Age = 28, TeamName = "India-C" });
            context.Players.Add(new Player { ID = 4, Name = "Rohith", Age =38, TeamName = "India-A" });
            context.Players.Add(new Player { ID = 5, Name = "Surya", Age = 29, TeamName = "India-B" });
            context.Players.Add(new Player { ID = 6, Name = "Hardik", Age = 26, TeamName = "India-C" });
            context.Players.Add(new Player { ID = 7, Name = "Jadeja", Age = 23, TeamName = "India-C" });
            context.Players.Add(new Player { ID = 8, Name = "Dhawan", Age = 26, TeamName = "India-B" });
            context.Players.Add(new Player { ID = 9, Name = "Chahar", Age = 28, TeamName = "India-A" });
            context.Players.Add(new Player { ID = 10, Name = "Rishab", Age = 28, TeamName = "India-A" });

            base.Seed(context);
        }
    }
}