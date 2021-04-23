using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppWebApi.Model.Types.TypeThree
{
    public class TypeThree_Location_Distance_Data
    {
        public decimal Distance { get; set; }
        public string PULocation { get; set; }
        public string DOLocation { get; set; }

        public TypeThree_Coordinate PULocationCoordinate { get; set; }
        public TypeThree_Coordinate DOLocationCoordinate { get; set; }
    }
}
