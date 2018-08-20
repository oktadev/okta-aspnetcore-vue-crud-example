using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class FoodRecordsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public FoodRecordsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET api/foodrecords
        [HttpGet]
        public async Task<ActionResult<List<FoodRecord>>> Get()
        {
            return await _dbContext.FoodRecords.ToListAsync();
        }

        // GET api/foodrecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodRecord>> Get(string id)
        {
            return await _dbContext.FoodRecords.FindAsync(id);
        }

        // POST api/foodrecords
        [HttpPost]
        public async Task Post(FoodRecord model)
        {
            await _dbContext.AddAsync(model);

            await _dbContext.SaveChangesAsync();
        }

        // PUT api/foodrecords/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, FoodRecord model)
        {
            var exists = await _dbContext.FoodRecords.AnyAsync(f => f.Id == id);
            if (!exists)
            {
                return NotFound();
            }

            _dbContext.FoodRecords.Update(model);

            await _dbContext.SaveChangesAsync();

            return Ok();

        }

        // DELETE api/foodrecords/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var entity = await _dbContext.FoodRecords.FindAsync(id);

            _dbContext.FoodRecords.Remove(entity);

            await _dbContext.SaveChangesAsync();
            
            return Ok();
        }
    }
}