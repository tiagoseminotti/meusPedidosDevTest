using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Mvc;

namespace MeusPedidos.DevTest.WebApp.Controllers
{
    /// <summary>
    /// Controller that access the API published
    /// </summary>
    public class UserEvalController : Controller
    {
        //WebAPI URL
        private string _serviceURL = WebConfigurationManager.AppSettings.Get("meusPedidosUEAPIURL");

        // GET: UserEval/Create
        public ActionResult Create()
        {
            return View(new Models.UserEvaluation());
        }

        // POST: UserEval/Create
        [HttpPost]
        public async Task<ActionResult> Create(Models.UserEvaluation pUserEvaluation)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                using (var client = new HttpClient())
                {
                    //Uses API URL
                    client.BaseAddress = new Uri(_serviceURL);
                    client.DefaultRequestHeaders.Clear();

                    HttpResponseMessage responseMessage = await client.PostAsJsonAsync("api/UserEvaluations", pUserEvaluation);
                    //Checks for success
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        //Returns to the listing view
                        ViewBag.message = "Applicant evaluation registered.";
                        return View();
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, string.Format("Error: {0}", responseMessage.ReasonPhrase));
                        return View();
                    }
                }
            }
            catch
            {
                return View();
            }
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;

            var model = new HandleErrorInfo(filterContext.Exception, "Controller", "Action");

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };
        }
    }
}
