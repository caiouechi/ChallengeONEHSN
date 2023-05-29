using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class RectangleBM
    {
        public int? AdotX { get; set; }
        public int? AdotY { get; set; }
        public int? BdotX { get; set; }
        public int? BdotY { get; set; }
        public int? CdotX { get; set; }
        public int? CdotY { get; set; }
        public int? DdotX { get; set; }
        public int? DdotY { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool IsValid { get; set; }
        public RectangleBM(int? AdotX, int? AdotY, int? BdotX, int? BdotY, int? CdotX, int? CdotY, int? DdotX, int? DdotY)
        {
            this.AdotX = AdotX;
            this.AdotY = AdotY;
            this.BdotX = BdotX;
            this.BdotY = BdotY;
            this.CdotX = CdotX;
            this.CdotY = CdotY;
            this.DdotX = DdotX;
            this.DdotY = DdotY;

            ValidRectangle();
        }

        void ValidRectangle()
        {
            this.IsValid = ((!AdotX.HasValue) || (!AdotY.HasValue) || (!BdotX.HasValue) || (!BdotY.HasValue) || (!CdotX.HasValue) || (!CdotY.HasValue) || (!DdotX.HasValue) || (!DdotY.HasValue)) ? false : true;
        }
    }
}