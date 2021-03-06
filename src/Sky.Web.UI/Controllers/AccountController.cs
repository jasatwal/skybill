﻿using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Sky.Billing;
using Sky.Billing.Statistics;
using Sky.Web.Mvc;
using Sky.Web.UI.ViewModels.Account;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Sky.Web.UI.Controllers
{
    [Authorize]
    public class AccountController : SkyController
    {
        private readonly JsonConverter[] jsonConverters;
        private readonly IBillingService billingService;

        public AccountController(JsonConverter[] jsonConverters, IBillingService billingService)
        {
            this.jsonConverters = jsonConverters;
            this.billingService = billingService;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            // Login as jbloggs for demo purposes.

            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, "jbloggs"),
                new Claim(ClaimTypes.Name, "Joe Bloggs"),
                new Claim(ClaimTypes.Email, "jbloggs@sky.com"),
                new Claim("AccountNumber", "1234567890")
            }, DefaultAuthenticationTypes.ApplicationCookie);

            HttpContext.GetOwinContext().Authentication.SignIn(identity);

            return RedirectToAction("Billing");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Billing()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> GetBillWithStatistics()
        {
            var accountNumber = new CustomerAccountNumber(ClaimsPrincipal.Current.FindFirst("AccountNumber").Value);
            var bill = await billingService.Find(accountNumber);

            var vm = new BillWithStatisticsViewModel
            {
                Bill = bill,
                CalledFrequency = bill.GetCalledFrequency(),
                SkyStoreChargesValue = bill.GetSkyStoreChargesValue()
            };

            return Json(vm, jsonConverters);
        }
    }
}