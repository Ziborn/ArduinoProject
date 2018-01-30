using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdruinoProject.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdruinoProject.Controllers
{
    [Route("api/email")]
    public class EmailController : Controller
    {
        private readonly DataManager dataManager;

        public EmailController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        [Route("sendEmail")]
        public IActionResult SendEmail()
        {
            dataManager.SendEMail();
            return Ok("Mail sent!");
        }
    }
}
