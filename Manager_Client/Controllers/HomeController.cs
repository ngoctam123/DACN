using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manager_Client.Models;
using Manager_Client.ViewModels;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Manager_Client.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();

        public ActionResult Index()
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
        public ActionResult dangnhap()
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
        public ActionResult dangki()
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
        public ActionResult TeacherClass()
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
        public ActionResult Contact1()
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
        public ActionResult StudentClass()
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
        public ActionResult Teacher()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Classall()
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
        public bool isThemMoi;
        public ActionResult listmonhoc()
        {
            //List<Science> listScience = db.Sciences.ToList();
            //ViewBag.listScience = listScience;
            isThemMoi = true;
            ViewBag.Check = isThemMoi;

            string maincnn = ConfigurationManager.ConnectionStrings["MTWDbContext"].ConnectionString;
            SqlConnection sqlcnn = new SqlConnection(maincnn);
            string condition = "select * from Science where (1=1) order by CreatedDate desc";
            SqlDataAdapter sqlda = new SqlDataAdapter(condition, maincnn);
            sqlcnn.Open();
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            IEnumerable<Science> model = ConvertToTankReadings(dt);

            ViewBag.listSciense = model;

            sqlcnn.Close();


            return View();
        }
        private IEnumerable<Science> ConvertToTankReadings(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                yield return new Science
                {
                    ID = Convert.ToInt32(row["ID"]),
                    Name = Convert.ToString(row["Name"]),
                    Address = Convert.ToString(row["Address"]),
                    Description = Convert.ToString(row["Description"]),
                    Founding = Convert.ToDateTime(row["Founding"])



                };
            }
        }
        public ActionResult getListmonhoc(int id)
        {
            JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var hs = db.Sciences.SingleOrDefault(x => x.ID == id);
            var result = JsonConvert.SerializeObject(hs, Formatting.Indented, jss);
            return this.Json(result, JsonRequestBehavior.AllowGet);



        }
        public List<Science> GetDatamonhoc()
        {
            return db.Sciences.ToList();


        }
    }
}