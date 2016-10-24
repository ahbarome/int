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
            return View(await db.Tbl_CheckInOut.ToListAsync());
        }

        // GET: Enrollments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_CheckInOut tbl_CheckInOut = await db.Tbl_CheckInOut.FindAsync(id);
            if (tbl_CheckInOut == null)
            {
                return HttpNotFound();
            }
            return View(tbl_CheckInOut);
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
        public async Task<ActionResult> Create([Bind(Include = "Id,IdUsuario,FechaRegistro,TipoMovimiento,IdSensor,StsModificacion")] Tbl_CheckInOut tbl_CheckInOut)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_CheckInOut.Add(tbl_CheckInOut);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tbl_CheckInOut);
        }

        // GET: Enrollments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_CheckInOut tbl_CheckInOut = await db.Tbl_CheckInOut.FindAsync(id);
            if (tbl_CheckInOut == null)
            {
                return HttpNotFound();
            }
            return View(tbl_CheckInOut);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,IdUsuario,FechaRegistro,TipoMovimiento,IdSensor,StsModificacion")] Tbl_CheckInOut tbl_CheckInOut)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_CheckInOut).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tbl_CheckInOut);
        }

        // GET: Enrollments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_CheckInOut tbl_CheckInOut = await db.Tbl_CheckInOut.FindAsync(id);
            if (tbl_CheckInOut == null)
            {
                return HttpNotFound();
            }
            return View(tbl_CheckInOut);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Tbl_CheckInOut tbl_CheckInOut = await db.Tbl_CheckInOut.FindAsync(id);
            db.Tbl_CheckInOut.Remove(tbl_CheckInOut);
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
