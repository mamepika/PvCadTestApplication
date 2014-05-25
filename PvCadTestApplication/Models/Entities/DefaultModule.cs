using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvCadTestApplication.Models.Entities
{
    public class DefaultModule
    {
        public string id { get; set; }

        public string moduleTypeId { get; set; }

        public string rectangle { get; set; }

        public double widthSize1 { get; set; }

        public double widthSize2 { get; set; }

        public double heightSize1 { get; set; }

        public double heightSize2 { get; set; }

        public double lowVirticalSize { get; set; }

        public double highVirticalSize { get; set; }

        public string direction { get; set; }

        public override string ToString()
        {
            return "id:" + this.id + ",moduleTypeId:" + this.moduleTypeId; 
        }
    }
}
