using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using INT.Service.DAL.Model;

namespace INT.Service.WebApp.Controllers
{
    public class SyncDevicesController : Controller
    {
        private IntellisoftEntities db = new IntellisoftEntities();

        // GET: SyncDevices
        public async Task<ActionResult> Index()
        {
            return View(await db.Tbl_SincronizacionMaquinaOnLine.ToListAsync());
        }

        // GET: SyncDevices/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_SincronizacionMaquinaOnLine tbl_SincronizacionMaquinaOnLine = await db.Tbl_SincronizacionMaquinaOnLine.FindAsync(id);
            if (tbl_SincronizacionMaquinaOnLine == null)
            {
                return HttpNotFound();
            }
            return View(tbl_SincronizacionMaquinaOnLine);
        }

        // GET: SyncDevices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SyncDevices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,NumeroMaquina,RutaServidorDBDescarga")] Tbl_SincronizacionMaquinaOnLine tbl_SincronizacionMaquinaOnLine)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_SincronizacionMaquinaOnLine.Add(tbl_SincronizacionMaquinaOnLine);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tbl_SincronizacionMaquinaOnLine);
        }

        // GET: SyncDevices/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_SincronizacionMaquinaOnLine tbl_SincronizacionMaquinaOnLine = await db.Tbl_SincronizacionMaquinaOnLine.FindAsync(id);
            if (tbl_SincronizacionMaquinaOnLine == null)
            {
                return HttpNotFound();
            }
            return View(tbl_SincronizacionMaquinaOnLine);
        }

        // POST: SyncDevices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,NumeroMaquina,RutaServidorDBDescarga")] Tbl_SincronizacionMaquinaOnLine tbl_SincronizacionMaquinaOnLine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_SincronizacionMaquinaOnLine).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tbl_SincronizacionMaquinaOnLine);
        }

        // GET: SyncDevices/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_SincronizacionMaquinaOnLine tbl_SincronizacionMaquinaOnLine = await db.Tbl_SincronizacionMaquinaOnLine.FindAsync(id);
            if (tbl_SincronizacionMaquinaOnLine == null)
            {
                return HttpNotFound();
            }
            return View(tbl_SincronizacionMaquinaOnLine);
        }

        // POST: SyncDevices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Tbl_SincronizacionMaquinaOnLine tbl_SincronizacionMaquinaOnLine = await db.Tbl_SincronizacionMaquinaOnLine.FindAsync(id);
            db.Tbl_SincronizacionMaquinaOnLine.Remove(tbl_SincronizacionMaquinaOnLine);
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
