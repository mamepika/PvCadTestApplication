using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvCadTestApplication.Models.Entities
{
    /// <summary>
    /// 屋根材マスタ
    /// </summary>
    class RoofMaterial
    {
        public string id { get; set; }

        public string name { get; set; }

        public string supportMaterialSetId { get; set; }
    }
}
