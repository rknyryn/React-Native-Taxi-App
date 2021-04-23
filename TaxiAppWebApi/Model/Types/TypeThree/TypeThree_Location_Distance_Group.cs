using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiAppWebApi.Model.Types.TypeThree
{
    public class TypeThree_Location_Distance_Group
    {
        public TypeThree_Location_Distance_Data shortRoute { get; set; }
        public TypeThree_Location_Distance_Data longRoute { get; set; }
    }
}
