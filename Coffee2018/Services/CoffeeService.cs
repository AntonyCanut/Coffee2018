using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Coffee2018.Models;

namespace Coffee2018.Services
{
    public class CoffeeService : ICoffeeService
    {
        private const string Url = "https://parisdata.opendatasoft.com/api/records/1.0/search/?dataset=liste-des-cafes-a-un-euro&rows=200&facet=arrondissement";

        public async Task<List<Record>> GetCoffeeListAsync(CancellationToken ct)
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(Url, ct).ConfigureAwait(false))
                {
                    var jsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var rootObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Coffees>(jsonString);

                    return rootObject.records;
                }
            }
        }
    }
}
