using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvCadTestApplication.Models.Entities
{
    public class WindLevel
    {
        public string id { get; set; }

        public string name { get; set; }


        public override string ToString()
        {
            return "ID:" + this.id + ",NAME:" + this.name;
        }
    }
}
