using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Beverage_Collection.Models
{
    public partial class Beverage
    {
        // Override ToString Method to concatenate the fields together.
        public override string ToString()
        {
            return string.Format(
                "{0,6} {1,-55} {2,-15} {3,6} {4,-6}",
                this.Id.Trim(),
                this.Name.Trim(),
                this.Pack.Trim(),
                this.Price.ToString("0.00"),
                this.Active ? "True" : "False"
            );
        }
    }
}
