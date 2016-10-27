using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
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
            return View(await db.CheckInOut.ToListAsync());
        }

        // GET: Enrollments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckInOut checkInOut = await db.CheckInOut.FindAsync(id);
            if (checkInOut == null)
            {
                return HttpNotFound();
            }
            return View(checkInOut);
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
        public async Task<ActionResult> Create([Bind(Include = "Id,IdUsuario,FechaRegistro,TipoMovimiento,IdSensor,StsModificacion")] CheckInOut checkInOut)
        {
            if (ModelState.IsValid)
            {
                db.CheckInOut.Add(checkInOut);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(checkInOut);
        }

        // GET: Enrollments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckInOut checkInOut = await db.CheckInOut.FindAsync(id);
            if (checkInOut == null)
            {
                return HttpNotFound();
            }
            return View(checkInOut);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,IdUsuario,FechaRegistro,TipoMovimiento,IdSensor,StsModificacion")] CheckInOut checkInOut)
        {
            if (ModelState.IsValid)
            {
                db.Entry(checkInOut).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(checkInOut);
        }

        // GET: Enrollments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckInOut checkInOut = await db.CheckInOut.FindAsync(id);
            if (checkInOut == null)
            {
                return HttpNotFound();
            }
            return View(checkInOut);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CheckInOut checkInOut = await db.CheckInOut.FindAsync(id);
            db.CheckInOut.Remove(checkInOut);
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
