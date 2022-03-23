using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webapi1.Database;
using webapi1.Entities;
using System.Web.Script.Serialization;
using AutoMapper;

namespace webapi1.Controllers
{
    public class StudeptController : ApiController
    {
        public readonly webapi1Entities123 db = new webapi1Entities123();
        [Route("api/stu/getall")]
        [HttpGet]
        public HttpResponseMessage Index()
        {
            var stu = db.Students.ToList();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Student, StudentModel>());
            var mapper = new Mapper(config);
            var stm = mapper.Map<List<StudentModel>>(stu);
            var k = new JavaScriptSerializer().Serialize(stm);
            return Request.CreateResponse(HttpStatusCode.OK, k);
        }
        [Route("api/stu/create")]
        [HttpPost]
        public HttpResponseMessage Create(Student st)
        {
            db.Students.Add(st);
            if (db.SaveChanges() == 1)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Inserted");
            }

            return Request.CreateResponse(HttpStatusCode.OK, "error");
        }
        [Route("api/stu/edit")]
        [HttpPost]
        public HttpResponseMessage Edit(Student st)
        {
            var ost = (from s in db.Students
                       where s.Id == st.Id
                       select s).FirstOrDefault();
            db.Entry(ost).CurrentValues.SetValues(st);
            if (db.SaveChanges() == 1)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Edited");
            }

            return Request.CreateResponse(HttpStatusCode.OK, "error");
        }
        [Route("api/stu/delete/{sid}")]
        [HttpPost]
        public HttpResponseMessage Delete(int sid)
        {
            var ost = (from s in db.Students
                       where s.Id == sid
                       select s).FirstOrDefault();
            if (ost == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "No student with this id");
            }
            db.Students.Remove(ost);
            if (db.SaveChanges() == 1)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
            }

            return Request.CreateResponse(HttpStatusCode.OK, "error");
        }



        [Route("api/department/getall")]
        [HttpGet]
        public HttpResponseMessage Deptgetal()
        {
            var stu = db.Departments.ToList();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Department, DepartmentModel>());
            var mapper = new Mapper(config);
            var stm = mapper.Map<List<DepartmentModel>>(stu);
            var k = new JavaScriptSerializer().Serialize(stm);
            return Request.CreateResponse(HttpStatusCode.OK, k);
        }
        [Route("api/department/create")]
        [HttpPost]
        public HttpResponseMessage Createdept(Department st)
        {
            db.Departments.Add(st);
            if (db.SaveChanges() == 1)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Inserted");
            }

            return Request.CreateResponse(HttpStatusCode.OK, "error");
        }
        [Route("api/department/edit")]
        [HttpPost]
        public HttpResponseMessage EditDept(Department st)
        {
            var ost = (from s in db.Departments
                       where s.Id == st.Id
                       select s).FirstOrDefault();
            db.Entry(ost).CurrentValues.SetValues(st);
            if (db.SaveChanges() == 1)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Edited");
            }

            return Request.CreateResponse(HttpStatusCode.OK, "error");
        }
        [Route("api/department/delete/{sid}")]
        [HttpPost]
        public HttpResponseMessage DeleteDept(int sid)
        {
            var ost = (from s in db.Departments
                       where s.Id == sid
                       select s).FirstOrDefault();
            if (ost == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "No student with this id");
            }
            db.Departments.Remove(ost);
            if (db.SaveChanges() == 1)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
            }

            return Request.CreateResponse(HttpStatusCode.OK, "error");
        }
        [Route("api/department/get/{sid}")]
        [HttpGet]
        public HttpResponseMessage GetDept(int sid)
        {
            var dept = (from d in db.Departments where d.Id == sid select d).FirstOrDefault();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Department, DepartmentStudentModel>();
                cfg.CreateMap<Student, StudentModel>();
            }
            );
            var mapper = new Mapper(config);
            var data = mapper.Map<DepartmentStudentModel>(dept);
            var k = new JavaScriptSerializer().Serialize(data);
            return Request.CreateResponse(HttpStatusCode.OK, k);
        }
    }
}
