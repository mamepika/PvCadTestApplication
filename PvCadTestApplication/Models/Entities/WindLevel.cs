﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvCadTestApplication.Models.Entities
{
    public class WindLevel
    {
        public string windLevelId { get; set; }

        public string windLevelName { get; set; }


        public override string ToString()
        {
            return "ID:" + this.windLevelId + ",NAME:" + this.windLevelName;
        }
    }
}
