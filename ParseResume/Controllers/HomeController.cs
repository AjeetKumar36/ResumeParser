using ParseReume.Models;
using System.Web.Mvc;

namespace ParseReume.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ReadResumeData res = new Models.ReadResumeData();
            return View(res);
        }
        [HttpPost]
        public ActionResult Index(ReadResumeData res,string btnsubmit)
        {

            if (btnsubmit == "Submit")
            {
                res.Read();
            }
            return View(res);
        }

    }
}