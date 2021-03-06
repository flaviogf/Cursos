﻿using System.Web.Mvc;
using System.Web.Routing;

namespace BuldingCustomController.Controllers
{
    public class ContactController : IController
    {
        private readonly ILogger _logger;

        public ContactController(ILogger logger)
        {
            _logger = logger;
        }

        public void Execute(RequestContext requestContext)
        {
            _logger.Info("It's executing the 'Execute' method of 'ContactController'");

            requestContext.HttpContext.Response.Write("This message was generated by the custom controller.");
        }
    }
}