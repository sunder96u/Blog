using Blog.Models;
using System;
using System.Configuration;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Blog.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            EmailModel model = new EmailModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var body = "<p>Email From: <bold>{0}</bold>" + "({1})</p><p>Message:</p><p>{2}</p>";
                    var from = "MyBlog<Steven@Mailinator.com>";
                    //model.Body = "This is a message from your Blog Site. The Name and Email of the contacting person is above.";

                    var email = new MailMessage(from, ConfigurationManager.AppSettings["emailto"])
                    {
                        Subject = "Blog Contact Email",
                        Body = string.Format(body, model.FromName, model.FromEmail, model.Body),
                        IsBodyHtml = true
                    };

                    var svc = new PersonalEmail();
                    await svc.SendAsync(email);

                    return View(new EmailModel());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    await Task.FromResult(0);
                }
            }
            return View(model);
        }
    }
}