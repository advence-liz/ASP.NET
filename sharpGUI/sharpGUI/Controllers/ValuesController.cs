using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace sharpGUI.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        //  //http://localhost:1234/api/values/get
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
           
            return "value";
        }

        // POST api/values
        public IEnumerable<string> Post()
        {
            return new string[] { "value1", "value2" };
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }

    //public ActionResult QueryUser(String user) 看着就是ActionResult 能返回任何类型
    //{
    //    var num = -1;
    //    while (true)
    //    {
    //        num = new Random().Next(1, 10);
    //        if (num < 6)
    //        {
    //            break;
    //        }
    //        else
    //        {
    //            Thread.Sleep(1000);
    //        }

    //    }
    //    return Json(new { message = num, userId = user });
    //}
}
