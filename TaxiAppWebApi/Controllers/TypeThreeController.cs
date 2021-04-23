using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppWebApi.GoogleAPI;
using TaxiAppWebApi.Model;
using TaxiAppWebApi.Model.Types.TypeThree;

namespace TaxiAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeThreeController : ControllerBase
    {

        private readonly TaxiAppDBContext _context;

        public TypeThreeController(TaxiAppDBContext taxiAppDBContext)
        {
            _context = taxiAppDBContext;
        }

        [HttpGet]
        [Route("GetThird")]
        public ActionResult<TypeThree_Location_Distance_Group> GetThird()
        {
            var resultShort = _context.TaxiTripData
                .Where(w => w.PassengerCount >= 3)
                .OrderBy(o => o.TripDistance).Take(1);
            var resultShortLocationDO = _context.TaxiZones.FirstOrDefault(p => p.LocationId == resultShort.First().DolocationId);
            string shortLocationDO = resultShortLocationDO.Borough + " / " + resultShortLocationDO.Zone;
            var resultShortLocationPU = _context.TaxiZones.FirstOrDefault(p => p.LocationId == resultShort.First().PulocationId);
            string shortLocationPU = resultShortLocationPU.Borough + " / " + resultShortLocationPU.Zone;
            var coordinateShortDO = GoogleMapApi.GetCoordinate(resultShortLocationDO);
            var coordinateShortPU = GoogleMapApi.GetCoordinate(resultShortLocationPU);

            var resultLong = _context.TaxiTripData
                .Where(w => w.PassengerCount >= 3)
                .OrderByDescending(o => o.TripDistance).Take(1);
            var resultLongLocationDO = _context.TaxiZones.FirstOrDefault(p => p.LocationId == resultLong.First().DolocationId);
            string longLocationDO = resultLongLocationDO.Borough + " / " + resultLongLocationDO.Zone;
            var resultLongLocationPU = _context.TaxiZones.FirstOrDefault(p => p.LocationId == resultLong.First().PulocationId);
            string longLocationPU = resultLongLocationPU.Borough + " / " + resultLongLocationPU.Zone;
            var coordinateLongDO = GoogleMapApi.GetCoordinate(resultLongLocationDO);
            var coordinateLongPU = GoogleMapApi.GetCoordinate(resultLongLocationPU);

            var data = new TypeThree_Location_Distance_Group
            {
                shortRoute = new TypeThree_Location_Distance_Data
                {
                    Distance = resultShort.First().TripDistance,
                    DOLocation = shortLocationDO,
                    PULocation = shortLocationPU,
                    PULocationCoordinate = coordinateShortPU,
                    DOLocationCoordinate = coordinateShortDO,
                },
                longRoute = new TypeThree_Location_Distance_Data
                {
                    Distance = resultLong.First().TripDistance,
                    DOLocation = longLocationDO,
                    PULocation = longLocationPU,
                    PULocationCoordinate = coordinateLongPU,
                    DOLocationCoordinate = coordinateLongDO,
                }
            };
            return data;
        }
    }
}
