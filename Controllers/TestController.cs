using System;
using System.Threading.Tasks;
using efcore.tests.Domain.Context;
using efcore.tests.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efcore.tests.Controllers
{

    [Route("[controller]")]
    public class TestController : ControllerBase
    {

        private readonly DbTestContext _context;

        public TestController(DbTestContext context) => (_context) = (context);


        [HttpGet]
        [Route("cars")]
        public async Task<IActionResult> GetCars()
        {
            // for this to work it is necessary the code that is in Startup class, line 31, to avoid error about json looping
            // services.AddControllers().AddNewtonsoftJson(options => ...
            // the same about the others GETs inside this controller
            var cars = await _context
                                .Car
                                .AsNoTracking()
                                .Include(x => x.Brand)
                                .Include(x => x.Stores)
                                .ToListAsync();
            return Ok(cars);
        }

        [HttpGet]
        [Route("autostores")]
        public async Task<IActionResult> GetAutoStores()
        {
            var autoStores = await _context
                                    .AutoStore
                                    .AsNoTracking()
                                    .Include(x => x.Cars)
                                    .ToListAsync();
            return Ok(autoStores);
        }

        [HttpGet]
        [Route("brands")]
        public async Task<IActionResult> GetBrands()
        {
            var brands = await _context
                                    .Brand
                                    .AsNoTracking()
                                    .ToListAsync();
            return Ok(brands);
        }


        [HttpPost]
        public async Task<IActionResult> Post()
        {
            try
            {
                var ford = new Brand("Ford");
                var fiat = new Brand("Fiat");

                var ka = new Car("KA", ford);
                var ecosport = new Car("Ecosport", ford);
                var palio = new Car("Palio", fiat);

                var storeA = new AutoStore("Best store");
                storeA.Cars.Add(ecosport);
                storeA.Cars.Add(palio);
                storeA.Cars.Add(ka);
                //storeA.Cars.Add(ka);

                var storeB = new AutoStore("Other store");
                storeB.Cars.Add(palio);

                _context.AutoStore.AddRange(storeA, storeB);

                var result = await _context.SaveChangesAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}