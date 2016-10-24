using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using INT.Service.DAL.Model;

namespace INT.Service.WebApp.Controllers
{
    public class DevicesSensorsController : Controller
    {
        private IntellisoftEntities db = new IntellisoftEntities();

        // GET: DevicesSensors
        public async Task<ActionResult> Index()
        {
            return View(await db.Tbl_SensorMaquinaOnline.ToListAsync());
        }

        // GET: DevicesSensors/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_SensorMaquinaOnline tbl_SensorMaquinaOnline = await db.Tbl_SensorMaquinaOnline.FindAsync(id);
            if (tbl_SensorMaquinaOnline == null)
            {
                return HttpNotFound();
            }
            return View(tbl_SensorMaquinaOnline);
        }

        // GET: DevicesSensors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DevicesSensors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nombre")] Tbl_SensorMaquinaOnline tbl_SensorMaquinaOnline)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_SensorMaquinaOnline.Add(tbl_SensorMaquinaOnline);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tbl_SensorMaquinaOnline);
        }

        // GET: DevicesSensors/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_SensorMaquinaOnline tbl_SensorMaquinaOnline = await db.Tbl_SensorMaquinaOnline.FindAsync(id);
            if (tbl_SensorMaquinaOnline == null)
            {
                return HttpNotFound();
            }
            return View(tbl_SensorMaquinaOnline);
        }

        // POST: DevicesSensors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nombre")] Tbl_SensorMaquinaOnline tbl_SensorMaquinaOnline)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_SensorMaquinaOnline).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tbl_SensorMaquinaOnline);
        }

        // GET: DevicesSensors/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_SensorMaquinaOnline tbl_SensorMaquinaOnline = await db.Tbl_SensorMaquinaOnline.FindAsync(id);
            if (tbl_SensorMaquinaOnline == null)
            {
                return HttpNotFound();
            }
            return View(tbl_SensorMaquinaOnline);
        }

        // POST: DevicesSensors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Tbl_SensorMaquinaOnline tbl_SensorMaquinaOnline = await db.Tbl_SensorMaquinaOnline.FindAsync(id);
            db.Tbl_SensorMaquinaOnline.Remove(tbl_SensorMaquinaOnline);
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
