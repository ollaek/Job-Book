using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Job_Book.Models;
using Microsoft.AspNet.Identity;

namespace Job_Book.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {


            return View(db.Jobs.ToList());
        }

        public ActionResult Details(int JobId )
        {
            var job = db.Jobs.Find(JobId);
            if(job == null)
            {
                return HttpNotFound();
            }
            Session["JobId"] = JobId;
            return View(job);
        }
       [Authorize]
        public ActionResult Apply()
        {
            return View(); 
        }
        [HttpPost]
        public ActionResult Apply(string Message , int MobilePhone)
        {
            var UserId = User.Identity.GetUserId();
            var JobId = (int)Session["JobId"];

            var check = db.ApplyforJobs.Where(a => a.JobId== JobId && a.UserId == UserId).ToList();

            if (check.Count < 1)
            {
                var job = new ApplyforJob();
                job.JobId = JobId;
                job.Message = Message;
                job.UserId = UserId;
                job.MobilePhone = MobilePhone;        
                job.ApplyDate = DateTime.Now;
                db.ApplyforJobs.Add(job);
                db.SaveChanges();
                ViewBag.result = "Your request is done";
               

          
            }
            else
            {
                ViewBag.result = "You have already applied";
            }
      
         
            return View();
        }
        [Authorize]
        public ActionResult GetJobsByUsers()
        {
            var UserId = User.Identity.GetUserId();
            var jobs = db.ApplyforJobs.Where(a => a.UserId == UserId);
            return View(jobs.ToList());
        }
        public ActionResult GetJobsbyOnlyExistpublisher()
        {
            var UserId = User.Identity.GetUserId();
            var number = db.Jobs.Where(a=>a.UserId == UserId );
            return View(number.ToList());
        }
        public ActionResult Editt(int id)
        {

            var job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editt(Job job , HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = System.IO.Path.Combine(Server.MapPath("/Uploads"), upload.FileName);
                upload.SaveAs(path);

                job.JobImage = upload.FileName;
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetJobsbyOnlyExistpublisher");
            }
            return View(job);
        }

        public ActionResult Detailss(int Id)
        {
            var job = db.Jobs.Find(Id);
            if (job == null)
            {
                return HttpNotFound();
            }

            return View(job);
        }

        public ActionResult Deletee(int id)
        {

            var Job = db.Jobs.Find(id);
            if (Job == null)
            {
                return HttpNotFound();
            }
            return View(Job);
        }
        [HttpPost, ActionName("Deletee")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Job job)
        {
            var MyJob = db.Jobs.Find(job.id);
            db.Jobs.Remove(MyJob);
            db.SaveChanges();
            return RedirectToAction("GetJobsbyOnlyExistpublisher");
        }

        [Authorize]
        public ActionResult DetailsOfJob(int Id)
        {
            var job = db.ApplyforJobs.Find(Id);
            if (job == null)
            {
                return HttpNotFound();
            }
           
            return View(job);
        }

        public ActionResult Edit(int id)
        {
       
           var job = db.ApplyforJobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ApplyforJob  job)
        { 
            if (ModelState.IsValid)
            {
                job.ApplyDate = DateTime.Now;
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetJobsByUsers");
            }
            return View(job);
        }
        public ActionResult Delete(int id)
        {
         
            var Job = db.ApplyforJobs.Find(id);
            if (Job == null)
            {
                return HttpNotFound();
            }
            return View(Job);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(ApplyforJob Job)
        {
            var MyJob = db.ApplyforJobs.Find(Job.id);
            db.ApplyforJobs.Remove(MyJob);
            db.SaveChanges();
            return RedirectToAction("GetJobsByUsers");
        }
        [Authorize]
        public ActionResult GetJobsByPuplisher()
        {
            var UserId = User.Identity.GetUserId();
            var Jobs = from app in db.ApplyforJobs
                       join Job in db.Jobs
                       on app.JobId equals Job.id
                       where Job.User.Id == UserId
                       select app;

           
                         
                    
                       
            return View(Jobs.ToList());
        }
        public ActionResult DeleteOfJob(int id)
        {

            var Job = db.ApplyforJobs.Find(id);
            if (Job == null)
            {
                return HttpNotFound();
            }
            return View(Job);
        }
        [HttpPost, ActionName("DeleteOfJob")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedOfJob(ApplyforJob Job)
        {
            var MyJob = db.ApplyforJobs.Find(Job.id);
            db.ApplyforJobs.Remove(MyJob);
            db.SaveChanges();
            return RedirectToAction("GetJobsByPuplisher");
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

        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(String SearchName)
        {
            var result = db.Jobs.Where(a => a.JobTitle.Contains(SearchName) ||
            a.JobContent.Contains(SearchName) ||
            a.Categories.categoryDescription.Contains(SearchName)||
            a.Categories.categoryDescription.Contains(SearchName) ||a.CategoryId.Contains(SearchName)).ToList();
            return View(result);
        }


    }
    
    }
