using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using INT.Service.DAL.Model;

namespace INT.Service.WebApp.Controllers
{
    public class DevicesDetailsController : Controller
    {
        private IntellisoftEntities db = new IntellisoftEntities();

        // GET: DevicesDetals
        public async Task<ActionResult> Index()
        {
            var tbl_DetalleMaquinaOnLine = db.Tbl_DetalleMaquinaOnLine.Include(t => t.Tbl_MaquinaOnLine).Include(t => t.Tbl_SensorMaquinaOnline);
            return View(await tbl_DetalleMaquinaOnLine.ToListAsync());
        }

        // GET: DevicesDetals/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_DetalleMaquinaOnLine tbl_DetalleMaquinaOnLine = await db.Tbl_DetalleMaquinaOnLine.FindAsync(id);
            if (tbl_DetalleMaquinaOnLine == null)
            {
                return HttpNotFound();
            }
            return View(tbl_DetalleMaquinaOnLine);
        }

        // GET: DevicesDetals/Create
        public ActionResult Create()
        {
            ViewBag.NumeroMaquina = new SelectList(db.Tbl_MaquinaOnLine, "NumeroMaquina", "NombreMaquina");
            ViewBag.IdSensor = new SelectList(db.Tbl_SensorMaquinaOnline, "Id", "Nombre");
            return View();
        }

        // POST: DevicesDetals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,NumeroMaquina,IdSensor")] Tbl_DetalleMaquinaOnLine tbl_DetalleMaquinaOnLine)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_DetalleMaquinaOnLine.Add(tbl_DetalleMaquinaOnLine);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.NumeroMaquina = new SelectList(db.Tbl_MaquinaOnLine, "NumeroMaquina", "NombreMaquina", tbl_DetalleMaquinaOnLine.NumeroMaquina);
            ViewBag.IdSensor = new SelectList(db.Tbl_SensorMaquinaOnline, "Id", "Nombre", tbl_DetalleMaquinaOnLine.IdSensor);
            return View(tbl_DetalleMaquinaOnLine);
        }

        // GET: DevicesDetals/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_DetalleMaquinaOnLine tbl_DetalleMaquinaOnLine = await db.Tbl_DetalleMaquinaOnLine.FindAsync(id);
            if (tbl_DetalleMaquinaOnLine == null)
            {
                return HttpNotFound();
            }
            ViewBag.NumeroMaquina = new SelectList(db.Tbl_MaquinaOnLine, "NumeroMaquina", "NombreMaquina", tbl_DetalleMaquinaOnLine.NumeroMaquina);
            ViewBag.IdSensor = new SelectList(db.Tbl_SensorMaquinaOnline, "Id", "Nombre", tbl_DetalleMaquinaOnLine.IdSensor);
            return View(tbl_DetalleMaquinaOnLine);
        }

        // POST: DevicesDetals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,NumeroMaquina,IdSensor")] Tbl_DetalleMaquinaOnLine tbl_DetalleMaquinaOnLine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_DetalleMaquinaOnLine).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.NumeroMaquina = new SelectList(db.Tbl_MaquinaOnLine, "NumeroMaquina", "NombreMaquina", tbl_DetalleMaquinaOnLine.NumeroMaquina);
            ViewBag.IdSensor = new SelectList(db.Tbl_SensorMaquinaOnline, "Id", "Nombre", tbl_DetalleMaquinaOnLine.IdSensor);
            return View(tbl_DetalleMaquinaOnLine);
        }

        // GET: DevicesDetals/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_DetalleMaquinaOnLine tbl_DetalleMaquinaOnLine = await db.Tbl_DetalleMaquinaOnLine.FindAsync(id);
            if (tbl_DetalleMaquinaOnLine == null)
            {
                return HttpNotFound();
            }
            return View(tbl_DetalleMaquinaOnLine);
        }

        // POST: DevicesDetals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Tbl_DetalleMaquinaOnLine tbl_DetalleMaquinaOnLine = await db.Tbl_DetalleMaquinaOnLine.FindAsync(id);
            db.Tbl_DetalleMaquinaOnLine.Remove(tbl_DetalleMaquinaOnLine);
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
