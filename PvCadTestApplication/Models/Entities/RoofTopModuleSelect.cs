using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvCadTestApplication.Models.Entities
{
    public class RoofTopModuleSelect
    {
        public string moduleCountId { get; set; }

        public string moduleCountName { get; set; }

        public string moduleAngleId { get; set; }

        public string windLevelId { get; set; }

        public string snowLevelId { get; set; }

        public string minimumHeight { get; set; }

        public string supportMaterialId { get; set; }
        
        public string moduleId { get; set; }


        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(this.moduleCountId).Append("\t");
            stringBuilder.Append(this.moduleCountName).Append("\t");
            stringBuilder.Append(this.moduleAngleId).Append("\t");
            stringBuilder.Append(this.windLevelId).Append("\t");
            stringBuilder.Append(this.snowLevelId).Append("\t");
            stringBuilder.Append(this.minimumHeight).Append("\t");
            stringBuilder.Append(this.supportMaterialId).Append("\t");
            stringBuilder.Append(this.moduleId).Append("\t");
            return stringBuilder.ToString();
        }
    }
}
