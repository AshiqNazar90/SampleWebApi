using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleWebApi.Data;
using SampleWebApi.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        ExampleDbContext _dbcontext;


        public ExampleController(ExampleDbContext _dbcontext) //Constuctor injection
        {
            this._dbcontext= _dbcontext;    
        }

        //Get aa data from the table
        // GET: api/<ExampleController>
        [HttpGet]
        public List<Example> GetDetail()
        {
           
            var result=_dbcontext.Examples.ToList();
            return result;
        }

        //Searchind data through id
        // GET api/<ExampleController>/5
        [HttpGet("{id}")]
        public Example GetExamples(int id)
        {

            var example = _dbcontext.Examples.Find(id);

            return example;
        }
     
        // Add Data to the table
        // POST api/<ExampleController>
        [HttpPost]
       
        public List<Example> PostExample(Example example)
        {
            var result=_dbcontext.Examples.Add(example);
            _dbcontext.SaveChanges();

            return null;
        }


        //Delete data from the table
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExample(int id)
        {
            var example = await _dbcontext.Examples.FindAsync(id);
            if (example == null)
            {
                return NotFound();
            }

            _dbcontext.Examples.Remove(example);
            await _dbcontext.SaveChangesAsync();

            return NoContent();
        }

        //Replacing the data in table
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExample(int id, Example example)
        {
            if (id != example.ID)
            {
                return BadRequest();
            }

            _dbcontext.Entry(example).State = EntityState.Modified;

            try
            {
                await _dbcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
              
                    throw;
            }

            return NoContent();
        }

    }
}
