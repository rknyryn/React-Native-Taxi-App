using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppWebApi.Model;
using TaxiAppWebApi.Model.Types.TypeTwo;

namespace TaxiAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeTwoController : ControllerBase
    {
        private readonly TaxiAppDBContext _context;

        public TypeTwoController(TaxiAppDBContext taxiAppDBContext)
        {
            _context = taxiAppDBContext;
        }

        [HttpGet]
        [Route("GetSecond")]
        public ActionResult<IEnumerable<TypeTwo_Date_AverageAmount>> GetSecond()
        {
            var result = new List<TypeTwo_Date_AverageAmount>();
            var response = _context.TaxiTripData
                .GroupBy(g => g.PickupDatetime, a => a.TotalAmount)
                .Select(s => new
                {
                    pickUpDatetime = s.Key,
                    avgAmount = s.Average(),
                }).OrderBy(o => o.avgAmount).ToList();

            DateTime dateTimeStart;
            DateTime dateTimeEnd;
            if (response[0].pickUpDatetime < response[1].pickUpDatetime)
            { 
                dateTimeStart = response[0].pickUpDatetime;
                dateTimeEnd = response[1].pickUpDatetime;
            }
            else
            {
                dateTimeStart = response[1].pickUpDatetime;
                dateTimeEnd = response[0].pickUpDatetime;
            }

            response.ForEach(r =>
            {
                if(r.pickUpDatetime >= dateTimeStart && r.pickUpDatetime <= dateTimeEnd)
                {
                    result.Add(new TypeTwo_Date_AverageAmount
                    {
                        pickUpDatetime = r.pickUpDatetime,
                        averageAmount = (float)r.avgAmount,
                    });
                }
                
            });
            return result;
        }

        [HttpPost]
        [Route("GetThird")]
        public ActionResult<IEnumerable<TaxiTripDatum>> GetThird(TypeTwo_Date_StartEnd date_StartEnd)
        {
            return _context.TaxiTripData
                .Where(w => w.PickupDatetime > date_StartEnd.start)
                .Where(w => w.PickupDatetime < date_StartEnd.end)
                .OrderBy(o => o.TripDistance).Take(5).ToList();
        }
    }
}
