using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppWebApi.Model;
using TaxiAppWebApi.Model.Types.TypeOne;

namespace TaxiAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOneController : ControllerBase
    {
        private readonly TaxiAppDBContext _context;

        public TypeOneController(TaxiAppDBContext taxiAppDBContext)
        {
            _context = taxiAppDBContext;
        }

        [HttpGet]
        [Route("GetFirst")]
        public ActionResult<IEnumerable<TypeOne_Time_PassengerCount>> GetFirst()
        {
            var result = new List<TypeOne_Time_PassengerCount>();
            var response = _context.TaxiTripData
                .GroupBy(g => g.PickupDatetime)
                .Select(s => new
                {
                    pickUpDatetime = s.Key,
                    passengerCount = s.Sum(s => s.PassengerCount),
                }).OrderByDescending(o => o.passengerCount).Take(5).ToList();

            response.ForEach(r =>
            {
                result.Add(new TypeOne_Time_PassengerCount
                {
                    pickUpDatetime = r.pickUpDatetime,
                    passengerCount = r.passengerCount,
                });
            });
            return result;
        }

        [HttpGet]
        [Route("GetThird")]
        public ActionResult<IEnumerable<TypeOne_Time_Distance>> GetThird()
        {
            var result = new List<TypeOne_Time_Distance>();
            var response = _context.TaxiTripData
                .OrderByDescending(o => o.TripDistance)
                .Select(s => new
                {
                    pickUpDatetime = s.PickupDatetime,
                    tripDistance = s.TripDistance,
                }).Take(5).ToList();
            response.ForEach(r =>
            {
                result.Add(new TypeOne_Time_Distance
                {
                    pickUpDatetime = r.pickUpDatetime,
                    tripDistance = (float)r.tripDistance,
                });
            });
            return result;
        }
    }
}
