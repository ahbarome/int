using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using INT.Service.DAL.Model;

namespace INT.Service.WebApp.Controllers
{
    public class DevicesController : Controller
    {
        private IntellisoftEntities db = new IntellisoftEntities();

        // GET: Devices
        public async Task<ActionResult> Index()
        {
            return View(await db.Tbl_MaquinaOnLine.ToListAsync());
        }

        // GET: Devices/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_MaquinaOnLine tbl_MaquinaOnLine = await db.Tbl_MaquinaOnLine.FindAsync(id);
            if (tbl_MaquinaOnLine == null)
            {
                return HttpNotFound();
            }
            return View(tbl_MaquinaOnLine);
        }

        // GET: Devices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Devices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "NumeroMaquina,NombreMaquina,TipoComunicacion,DireccionIP,Puerto,TipoDispositivo,RutaServidorDBDescarga")] Tbl_MaquinaOnLine tbl_MaquinaOnLine)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_MaquinaOnLine.Add(tbl_MaquinaOnLine);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tbl_MaquinaOnLine);
        }

        // GET: Devices/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_MaquinaOnLine tbl_MaquinaOnLine = await db.Tbl_MaquinaOnLine.FindAsync(id);
            if (tbl_MaquinaOnLine == null)
            {
                return HttpNotFound();
            }
            return View(tbl_MaquinaOnLine);
        }

        // POST: Devices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "NumeroMaquina,NombreMaquina,TipoComunicacion,DireccionIP,Puerto,TipoDispositivo,RutaServidorDBDescarga")] Tbl_MaquinaOnLine tbl_MaquinaOnLine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_MaquinaOnLine).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tbl_MaquinaOnLine);
        }

        // GET: Devices/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_MaquinaOnLine tbl_MaquinaOnLine = await db.Tbl_MaquinaOnLine.FindAsync(id);
            if (tbl_MaquinaOnLine == null)
            {
                return HttpNotFound();
            }
            return View(tbl_MaquinaOnLine);
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Tbl_MaquinaOnLine tbl_MaquinaOnLine = await db.Tbl_MaquinaOnLine.FindAsync(id);
            db.Tbl_MaquinaOnLine.Remove(tbl_MaquinaOnLine);
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
