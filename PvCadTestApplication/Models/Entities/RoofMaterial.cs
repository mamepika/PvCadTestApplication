using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PvCadTestApplication.Models.Repositories;

namespace PvCadTestApplication.Models.Entities
{
    /// <summary>
    /// 屋根材マスタ
    /// </summary>
    class RoofMaterial
    {
        public string roofMaterialId { get; set; }
        public string roofMaterialName { get; set; }

        private string _supportMaterialSetId;
        public string supportMaterialSetId {
            get
            {
                return this._supportMaterialSetId;
            }
            set
            {
                this._supportMaterialSetId = value;
                SetSupportMaterilas();
            }
        }
        //対応する支持部材のリスト
        public List<String> supportMaterials { get; set; }

        /// <summary>
        /// リポジトリから対応する指示部材を取得する
        /// </summary>
        private void SetSupportMaterilas()
        {
            SupportMaterialSetJoinRepository supportJoinRepository = new SupportMaterialSetJoinRepository();

            supportMaterials =
                supportJoinRepository.FindBySupportMaterialSetId(this._supportMaterialSetId);
        }
    }
}
