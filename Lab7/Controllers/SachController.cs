using Lab7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lab7.Controllers
{
    public class SachController : ApiController
    {
        Sach[] sachs = new Sach[]
{
        new Sach { Id = 1, Title = "Tôi thấy hoa vàng trên cỏ xanh", AuthorName ="Nguyễn Nhật Ánh", Price = 1, Content="Truyện kể về Tuổi thơ..." },
        new Sach { Id = 2, Title = "Pro ASP.NET MVC5", AuthorName = "Adam Freeman", Content="The ASP.NET MVC 5 Framework is the latest evolution of Microsoft’s ASP.NET web platform.", Price = 3.75M },};
        public IEnumerable<Sach> GetAll()
        {
            return sachs;
        }
        public IHttpActionResult GetSach(int id)
        {
            var sach = sachs.FirstOrDefault((p) => p.Id == id);
            if (sach == null)
            {
                return NotFound();
            }
            return Ok(sach);
        }

        [HttpGet]
        public List<Sach> GetSachLists()
        {
            DbSachDataContext db = new DbSachDataContext();
            return sachs.ToList();
        }

        [HttpGet]
        public Sach Getsach(int id)
        {
            DbSachDataContext db = new DbSachDataContext();
            return sachs.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public bool InsertNewFood(int Id, string Title, string Content, string AuthorName, int Price)
        {
            try
            {
                DbSachDataContext db = new DbSachDataContext();
                Sach sach = new Sach();
                sach.Id = Id;
                sach.Title = Title;
                sach.Content = Content;
                sach.AuthorName = AuthorName;
                sach.Price = Price;
                db.sachs.InsertOnSubmit(sach);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpPut]
        public bool UpdateSach(int id, string Content, string Title, string AuthorName, int Price)
        {
            try
            {
                DbSachDataContext db = new DbSachDataContext();
                
                Sach sach = db.Sachs.FirstOrDefault(x => x.Id == id);
                if (sach == null) return false;
                sach.AuthorName = AuthorName;
                sach.Title = Title;
                sach.Price = Price;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpDelete]
        public bool DeleteFood(int id)
        {
            DbSachDataContext db = new DbSachDataContext();
           
            Sach food = db.Sachs.FirstOrDefault(x => x.id == id);
            if (food == null) return false;
            db.Sachs.DeleteOnSubmit(sach);
            db.SubmitChanges();
            return true;
        }
    }
}
