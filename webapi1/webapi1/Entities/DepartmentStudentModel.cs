using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi1.Entities
{
    public class DepartmentStudentModel : DepartmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StudentModel> Students { get; set; }
        public DepartmentStudentModel()
        {
            Students = new List<StudentModel>();
        }
    }
}