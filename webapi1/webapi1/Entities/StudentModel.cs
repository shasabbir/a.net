using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi1.Entities
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dob { get; set; }
        public Nullable<int> D_id { get; set; }
    }
}