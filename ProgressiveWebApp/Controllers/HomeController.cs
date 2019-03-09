using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestSharp;
using Newtonsoft.Json;
using ProgressiveWebApp.Models;

namespace ProgressiveWebApp.Controllers
{
    public class HomeController : Controller
    {
        public string api = "Basic YTE5NDg1MGQ0MjNlNWJjNTQ0MTY2ODZmZmFlNTMxZTNkY2JmZWIzMjpiZjExNDRjZjg1MDIwZmE0N2JlNmQxYWE4YzRmYjFiNDgyNWY=";

        public ActionResult LogIn()
        {
            return View();
        }
         [HttpPost]
        public ActionResult Check(string username, string password)
        {
            if(username == "tuncay" && password == "tuncay")
            {
                Session["LogedIn"] = true;
                return RedirectToAction("Index","Home", new { accountid = 194850 });
            }

            return RedirectToAction("LogIn", "Home");
        }
        
        [filter]
        public ActionResult Index(int? accountid)
        {
            if (accountid == null)
            {
                return RedirectToAction("Login", "Home");
            }

            IRestResponse response = accountCalls(accountid);
            IRestResponse responseAccount = accountDetails(accountid);
            

            CallsAndAccount allinone = new CallsAndAccount();
            allinone.account = JsonConvert.DeserializeObject<Account>(responseAccount.Content); ;
            allinone.callsList = JsonConvert.DeserializeObject<CallsList>(response.Content);
            ViewBag.acname = allinone.account.name;
            return View(allinone);

        }

        public IRestResponse accountCalls(int? accountid)
        {
            var client = new RestClient("https://api.calltrackingmetrics.com");

            var req = new RestRequest("api/v1/accounts/" + accountid + "/calls", Method.GET);
            req.AddHeader("Authorization", api);

            IRestResponse response = client.Execute(req);
            return response;
        }

        public IRestResponse accountDetails(int? accountid)
        {
            var client = new RestClient("https://api.calltrackingmetrics.com");

            var req = new RestRequest("api/v1/accounts/" + accountid, Method.GET);
            req.AddHeader("Authorization", api);

            IRestResponse response = client.Execute(req);
            return response;
        }

        public ActionResult detail(string accountid, string callid)
        {
            var client = new RestClient("https://api.calltrackingmetrics.com");

            var req = new RestRequest("api/v1/accounts/" + accountid + "/calls/" + callid, Method.GET);
            req.AddHeader("Authorization", api);

            IRestResponse response = client.Execute(req);
            var content = response.Content;
            CallDetail m = JsonConvert.DeserializeObject<CallDetail>(response.Content);


            return View(m);
        }

        public ActionResult Test(int accountid)
        {
            var client = new RestClient("https://api.calltrackingmetrics.com");

            var req = new RestRequest("api/v1/accounts/" + accountid + "/calls", Method.GET);
            req.AddHeader("Authorization", api);

            IRestResponse response = client.Execute(req);
            var content = response.Content;
            CallsList m = JsonConvert.DeserializeObject<CallsList>(response.Content);



            return View(m);
        }

        [filter]
        public string Number(int id)
        {

            string api = "Basic YTE5NDg1MGQ0MjNlNWJjNTQ0MTY2ODZmZmFlNTMxZTNkY2JmZWIzMjpiZjExNDRjZjg1MDIwZmE0N2JlNmQxYWE4YzRmYjFiNDgyNWY=";
            var client = new RestClient("https://api.calltrackingmetrics.com");

            var req = new RestRequest("api/v1/accounts/"+id+"/numbers.json", Method.GET);
            req.AddHeader("Authorization", api);

            IRestResponse response = client.Execute(req);
            var content = response.Content;
            Number m = JsonConvert.DeserializeObject<Number>(response.Content);

            return m.numbers.FirstOrDefault().number;
        }
    }
}

