using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities
{
    public class RawMaterial
    {
        public int RawMaterialID { get; set; }
        public string RawMaterialName { get; set; }
        public int RawMaterialUnitPrice { get; set; }
    }
}
