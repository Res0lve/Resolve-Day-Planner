using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResolveDayPlanner.Models;

namespace ResolveDayPlanner.Services
{
    public class ErrandDataStore : IDataStore<Errand>
    {
        public async Task<Errand> GetErrandAsync(string id)
        {
            List<Errand> errands = XmlSerializerService.ReadFromXmlFile<List<Errand>>();

            return await Task.FromResult(errands.FirstOrDefault(s => s.Id == id));
        }
    }
}
