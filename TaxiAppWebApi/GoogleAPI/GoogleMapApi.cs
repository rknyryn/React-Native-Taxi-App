using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppWebApi.Model;
using TaxiAppWebApi.Model.Types.TypeThree;
using Newtonsoft.Json.Linq;
using System.Net;

namespace TaxiAppWebApi.GoogleAPI
{
    public static class GoogleMapApi
    {
        public static TypeThree_Coordinate GetCoordinate(TaxiZone taxiZone)
        {
            string APIKey = "AIzaSyCOA7g0o-KcAnxg7C_d74h8quV_Ffsc4Ng";
            GoogleCoordinate coordinate;
            string address = string.Join(" ", taxiZone.Borough, taxiZone.Zone);
            var _queryLink = $@"https://maps.googleapis.com/maps/api/geocode/json?address={address}&key={APIKey}";
            WebClient webClient = new WebClient();
            string answer = webClient.DownloadString(_queryLink);
            JObject jObject = JObject.Parse(answer);
            var variable = jObject["results"][0]["geometry"]["location"];
            coordinate = Newtonsoft.Json.JsonConvert.DeserializeObject<GoogleCoordinate>(variable.ToString());
            return new TypeThree_Coordinate { Latitude = coordinate.lat, Longitude = coordinate.lng };
        }
    }
}
