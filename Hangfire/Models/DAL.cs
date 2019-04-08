using Hangfire.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hangfire.Models
{
    public class DAL
    {
        private readonly HangfiretestdbContext _context;
        public DAL(HangfiretestdbContext context)
        {
            this._context = context;
        }

        public DAL()
        {
        }

        DateTime now = DateTime.Now;
        public void getdefaulters()
        {
            DateTime currentdate = DateTime.Now;
            HomeController home = new HomeController();
            var allusers = _context.Hangfiretbl.ToList();
            foreach(var items in allusers)
            {
                if((currentdate - items.DatePosted).TotalDays >= 55)
                {
                    home.SendEmail(items.Email);
                }
            }
        }
    }
}