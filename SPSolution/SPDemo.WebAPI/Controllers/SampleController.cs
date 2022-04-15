using Microsoft.AspNetCore.Mvc;
using SPDemo.WebAPI.Helper;
using SPDemo.WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SPDemo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        public static List<SampleEntity> privateSamplelist = new List<SampleEntity>();
        // GET: api/<SampleController>
        [HttpGet]
        public IEnumerable<SampleEntity> Get()
        {
            privateSamplelist = new List<SampleEntity>();
            if (privateSamplelist.Count == 0)
            {
                var listCount = AppHelper.rd.Next(3, 15);
                for (int i = 0; i < listCount; i++)
                {
                    privateSamplelist.Add(RandomSampleEntity(i + 1));
                }
            }
            return privateSamplelist;
        }

        private SampleEntity RandomSampleEntity(int id = 0)
        {
            return new SampleEntity()
            {
                Id = id > 0 ? id : AppHelper.rd.Next(1000),
                Property01 = AppHelper.CreateString(15),
                Property02 = AppHelper.CreateString(15),
                Property03 = DateTime.Now.AddDays(-1 * AppHelper.rd.Next(1000)),
                Property04 = DateTime.Now.AddDays(-1 * AppHelper.rd.Next(1000)),
                Property05 = AppHelper.rd.Next(1000),
                Property06 = AppHelper.rd.Next(1000),
                Property07 = AppHelper.CreateString(15)
            };
        }

        // GET api/<SampleController>/5
        [HttpGet("{id}")]
        public SampleEntity Get(int id)
        {
            var findSampleList = privateSamplelist.FirstOrDefault(x => x.Id == id);
            return findSampleList;
        }

        // POST api/<SampleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SampleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SampleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
