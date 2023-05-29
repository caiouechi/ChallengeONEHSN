using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class CoordinateBM
    {
        public int? X { get; set; }
        public int? Y { get; set; }
        public bool IsValid { get; set; }
        public CoordinateBM(int? x, int? y)
        {
            this.X = x;
            this.Y = y;

            Validate();
        }

        void Validate()
        {
            IsValid = !(!this.X.HasValue || !this.X.HasValue);

        }
    }
}