using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace sharpGUI.Controllers
{
    public class AjaxController : ApiController
    {
       

        // GET api/values
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
        public void Post([FromBody]string value)
        {
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

    
   
}
//在ASP.NET中（ASP.NET天生是多线程的，基于线程池的，没有UI线程的概念），如果你调用了一个async方法，如果有await相伴，当前线程立马被释放回线程池，线程的上下文信息（比如reqeust context）被保存；如果没有await相伴（也没有其他的wait代码），调用async方法之后，代码会继续往下执行，直至完成，当前线程被释放回线程池，线程的上下文信息不会被保存。当async中的异步任务完成后（注：异步任务不是在另外一个线程中完成的，是在一个状态机中完成的），会从线程池中取出一个线程继续执行，执行时会读取当时调用它的原线程的上下文信息（默认情况下的行为，如果ConfigureAwait(false) ，就没有这一步操作），如果当初调用时没有使用await，线程的上下文信息没有被保存，这时就会引发NullReferenceException。而在这种级别发生的未处理null引用异常，会引发整个应用程序崩溃，更准确地说是应用程序所在的进程崩溃。因为这样的异常实在太危险，为了不让一只老鼠坏了一锅汤，只能被牺牲。 

//所以，如果不想被牺牲，要么老老实实地await；要么告诉async方法，不要读取原线程的上下文信息（ConfigureAwait(false)，未经实际验证是否有效）；要么调用async方法的线程没有需要保存的上下文信息，比如在Task.Run（或Task.Factory.StartNew）中调用async方法，也就是用一个新的线程调用async方法。