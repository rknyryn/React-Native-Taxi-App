using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppWebApi.Model.Types.TypeOne
{
    public class TypeOne_Time_Distance
    {
        public DateTime pickUpDatetime { get; set; }
        public float tripDistance { get; set; }
    }
}
