using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Linq;
using System.Web.Mvc;
using INT.Service.DAL.Model;

namespace INT.Service.WebApp.Controllers
{
    public class EnrollmentsController : Controller
    {
        private IntellisoftEntities db = new IntellisoftEntities();

        // GET: Enrollments
        public async Task<ActionResult> Index()
        {
            var untilDate = DateTime.Now.AddDays(-7);
            var enrollements =
                await db.CHECKINOUT.Where(
                    enrollment =>
                    enrollment.CheckTime > untilDate).ToListAsync();
            return View(enrollements);
        }

        // GET: Enrollments/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHECKINOUT cHECKINOUT = await db.CHECKINOUT.FindAsync(id);
            if (cHECKINOUT == null)
            {
                return HttpNotFound();
            }
            return View(cHECKINOUT);
        }

        // GET: Enrollments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Userid,CheckTime,CheckType,Sensorid,StsModificacion")] CHECKINOUT cHECKINOUT)
        {
            if (ModelState.IsValid)
            {
                db.CHECKINOUT.Add(cHECKINOUT);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cHECKINOUT);
        }

        // GET: Enrollments/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHECKINOUT cHECKINOUT = await db.CHECKINOUT.FindAsync(id);
            if (cHECKINOUT == null)
            {
                return HttpNotFound();
            }
            return View(cHECKINOUT);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Userid,CheckTime,CheckType,Sensorid,StsModificacion")] CHECKINOUT cHECKINOUT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHECKINOUT).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cHECKINOUT);
        }

        // GET: Enrollments/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHECKINOUT cHECKINOUT = await db.CHECKINOUT.FindAsync(id);
            if (cHECKINOUT == null)
            {
                return HttpNotFound();
            }
            return View(cHECKINOUT);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            CHECKINOUT cHECKINOUT = await db.CHECKINOUT.FindAsync(id);
            db.CHECKINOUT.Remove(cHECKINOUT);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
