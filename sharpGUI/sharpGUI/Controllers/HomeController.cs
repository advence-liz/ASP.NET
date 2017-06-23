using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace sharpGUI.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Page(string id)
        //{
        //    ViewBag.Page = id + ".cshtml";
        //    return View("~/Views/Demo/" + ViewBag.Page);
        //}
        //http://localhost:1234/home/index
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Ajax()
        {
            ViewBag.Title = "Ajax";

            return View();
        }

        public async Task<JsonResult> IndexAsync()
        {
            var cnblogsTask =  GetStringAsync("http://www.cnblogs.com");
            var myblogTask =  GetStringAsync("http://www.cnblogs.com/wintersun");

            // Asynchronously wait for them all to complete.
            await Task.WhenAll(cnblogsTask, myblogTask);
            var result = new JsonResult();
            result.Data = new { cn = cnblogsTask, self = myblogTask };

            return Json(result,JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// async Task 方法不一定是async，这要看我是否在声明为async Task 的方法中启动线程（.NET提供的async interface 会自己启动新的线程）
        /// 只有当前方法声明为 async Task 才能使用await（await 等待的是其他async Task 的返回结果）
        /// </summary>
        /// <returns></returns>
        public async Task<string> blog()
        {
            var cnblogsTask = await GetStringAsync("http://www.cnblogs.com");
            return cnblogsTask;
        }
        public static async Task<string> GetStringAsync(string uri)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(uri);

                return (await response.Content.ReadAsStringAsync());//return 的是await
            }
        }

    }

   
}
