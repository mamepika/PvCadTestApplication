using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PvCadTestApplication.Models.Entities;

namespace PvCadTestApplication.Models
{
    public class PvCadContext : DbContext
    {
        public DbSet<WindLevel> M_Wind_Lv { get; set; }
    }
}
