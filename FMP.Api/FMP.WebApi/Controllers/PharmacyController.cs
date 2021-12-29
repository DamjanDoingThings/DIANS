using FMP.Database.Database.Contexts;
using FMP.Database.Database.Models;
using FMP.WebApi.Algorithms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMP.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PharmacyController : Controller
    {
        private readonly ILogger<PharmacyController> _logger;
        private readonly FindMyPharmacyDbContext _dbContext;

        public PharmacyController(ILogger<PharmacyController> logger,
            FindMyPharmacyDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet("FindClosest")]
        public async Task<ActionResult<Pharmacy>> FindClosest(string origin, string drugKeyword)
        {
            var pharmaciesQuery = from p in _dbContext.Pharmacies
                             join pd in _dbContext.PharmacyDrugs
                                on p.Id equals pd.PharmacyId
                             join d in _dbContext.Drugs
                                 on pd.DrugId equals d.Id
                             where d.Name.ToLower().Contains(drugKeyword.ToLower())
                             select p;

            var pharmacies = await pharmaciesQuery.ToListAsync();

            var distances = PharmacyDistanceAlgorithm.Distances(origin, pharmacies);

            distances = distances.OrderBy(x => x.DistanceFromOrigin).ToList();

            return Ok(distances);
        }
    }
}
