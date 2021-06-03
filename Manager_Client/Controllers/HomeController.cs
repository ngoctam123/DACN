using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manager_Client.Models;
using Manager_Client.ViewModels;
using Newtonsoft.Json;

namespace Manager_Client.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Teacher()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Student()
        {
            List<Teacher> listTeacher = db.Teachers.ToList();
            ViewBag.listTeacher = listTeacher;
            List<Science> listScience = db.Sciences.ToList();
            ViewBag.listScience = listScience;
            var listClass = new List<ClassViewModel>();
            db.Classes.ToList().ForEach(item =>
            {
                listClass.Add(new ClassViewModel(item.ID, item.Name, item.Address, item.TeacherID, item.ScienceID, item.CreatedDate, item.ModifiedDate));

            });
            ViewBag.listClass = listClass;

            return View();
        }
        public ActionResult Class(string id)
        {
            List<Teacher> listTeacher = db.Teachers.ToList();
            ViewBag.listTeacher = listTeacher;
            List<Science> listScience = db.Sciences.ToList();
            ViewBag.listScience = listScience;
            var listClass = new List<ClassViewModel>();
            db.Classes.ToList().ForEach(item =>
            {
                listClass.Add(new ClassViewModel(item.ID, item.Name, item.Address, item.TeacherID, item.ScienceID, item.CreatedDate, item.ModifiedDate));
                
            });
            ViewBag.listClass = listClass;

            return View();
        }
        public ActionResult getList(int id)
        {

            JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var hs = db.Classes.SingleOrDefault(x => x.ID == id);
            var result = JsonConvert.SerializeObject(hs, Formatting.Indented, jss);
            return this.Json(result, JsonRequestBehavior.AllowGet);



        }
        public List<Class> GetData()
        {
            return db.Classes.ToList();


        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Liên hệ";

            return View();
        }
    }
}