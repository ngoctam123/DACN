using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Manager_Client.Models;

namespace Manager_Client.ViewModels
{
    public class ClassViewModel
    {
        public ClassViewModel()
        {
            GetTeacher();
            GetScience();
        }
        public ClassViewModel(int classID, string name, string address, int teacherID, int scienceID, DateTime? createdDate, DateTime? modifiedDate)
        {
            ID = classID;
            Name = name;
            Address = address;
            TeacherID = teacherID;
            ScienceID = scienceID;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
            GetTeacher();
            GetScience();

        }

        public int ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
        public int TeacherID { get; set; }
        public int ScienceID { get; set; }
        public string TeacherName { get; set; }
        public string ScienceName { get; set; }
        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public void GetTeacher()
        {
            if (TeacherID > 0)
            {
                using (Model1 db = new Model1())
                {
                    this.TeacherName = db.Teachers.Find(this.TeacherID) != null ?
                        db.Teachers.Find(this.TeacherID).Name_Teacher : string.Empty;
                }
            }
        }
        public void GetScience()
        {
            if (ScienceID > 0)
            {
                using (Model1 db = new Model1())
                {
                    this.ScienceName = db.Sciences.Find(this.ScienceID) != null ?
                        db.Sciences.Find(this.ScienceID).Name : string.Empty;
                }
            }
        }
    }
}