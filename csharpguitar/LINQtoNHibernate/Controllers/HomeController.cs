using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Linq;

namespace NHPosts.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Willkommen bei ASP.NET MVC";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult PostList(string sidx, string sord, int page, int rows)
        {
            Configuration config = new Configuration();

            config.AddAssembly("NHPosts");
            ISessionFactory factory = config.BuildSessionFactory();
            ISession session = factory.OpenSession();

            #region ICriteria

            ICriteria criteria = session.CreateCriteria(typeof(Posts));
            criteria.SetMaxResults(25);
            IList<Posts> posts = criteria.List<Posts>();

            #endregion

            #region LINQ to NHibernate

            //var postsCount = session.Query<Posts>().ToFuture();

            //IList<Posts> posts = (from p in session.Query<Posts>()
            //                      select p).Take(25).ToList();

            //IList<Posts> posts = (from p in session.Query<Posts>()
            //                      select p).Take(25).ToFuture().ToList();

            #endregion

            var jsonData = new
            {
                page = page,
                //records = postsCount.Count(),
                rows = (
                        from po in posts
                        select new
                        {
                            id = po.Id,
                            cell = new string[] {
                                po.Id.ToString(),
                                po.Title,
                                po.Text,
                                po.PostedAt.ToString(),
                                po.BlogId.ToString(),
                                po.UserId.ToString()}
                        }).ToArray()
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BlogList(string sidx, string sord, int page, int rows, int id)
        {
            Configuration config = new Configuration();

            config.AddAssembly("NHPosts");
            ISessionFactory factory = config.BuildSessionFactory();
            ISession session = factory.OpenSession();

            #region IQuery - HQL

            IQuery query = session.CreateQuery("from Blogs where Id = :BLOGID");
            query.SetString("BLOGID", id.ToString());
            IList<Blogs> blogs = query.List<Blogs>();

            #endregion

            #region LINQ to NHibernate

            //IList<Blogs> blogs = (from b in session.Query<Blogs>()
            //                      where b.Id == id
            //                      select b).ToList();
            #endregion

            var jsonData = new
            {
                page = page,
                records = 25,
                rows = (
                        from bl in blogs
                        select new
                        {
                            id = bl.Id,
                            cell = new string[] {
                                bl.Id.ToString(),
                                bl.Title,
                                bl.Subtitle,
                                bl.AllowsComments.ToString(),
                                bl.CreatedAt.ToString()}
                        }).ToArray()
            };
            

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}
