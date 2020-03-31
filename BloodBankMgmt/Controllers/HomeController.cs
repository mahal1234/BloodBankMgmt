using BloodBankMgmt.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBankMgmt.Controllers
{
    public class HomeController : Controller
    {
        DataBase instanceConnection = new DataBase();


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
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AdminLogin()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult FeedBack()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Correct()
        {
            return View();
        }

        public ActionResult Wrong()
        {
            return View();
        }



        public ActionResult adminLoginCheck(LoginClass login)
        {
            String Query = "select * from AdminLogin where UserName='"+login.UserName+"' and UserPassword='"+login.UserPassword+"'";
            DataTable tbl = new DataTable();
            tbl = instanceConnection.dataRecord(Query);
            if (tbl.Rows.Count > 0)
            {
                return View("Correct");
            }
            else {
                return View("Wrong");
            }

        }
            public ActionResult passMessage(ContactClass data)
        {
            String query = "insert into Contact(Name,Contact,Email,Message) values ('"+data.TxtName+"','"+data.TxtContact+"','"+data.TxtEmail+"','"+data.TxtMessage+"')" ;
            instanceConnection.Query(query);
            return View("FeedBack");
        }


    }
}