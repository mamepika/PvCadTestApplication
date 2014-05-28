using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvCadTestApplication.Models.Entities
{
    class WorkLevel
    {
        public string workLevelId { get; set; }

        public string workLevelName { get; set; }


        public override string ToString()
        {
            return "ID:" + this.workLevelId + ",NAME:" + this.workLevelName;
        }
    }
}
