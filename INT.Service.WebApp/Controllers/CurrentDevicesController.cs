using INT.Service.DAL.Model;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace INT.Service.WebApp.Controllers
{
    public class CurrentDevicesController : Controller
    {
        private IntellisoftEntities db = new IntellisoftEntities();

        // GET: CurrentDevices
        public async Task<ActionResult> Index()
        {
            return View(await db.CurrentDevice.ToListAsync());
        }

        // GET: CurrentDevices/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrentDevice currentDevice = await db.CurrentDevice.FindAsync(id);
            if (currentDevice == null)
            {
                return HttpNotFound();
            }
            return View(currentDevice);
        }

        // GET: CurrentDevices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CurrentDevices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FromIpAddress,ToDataBase,SyncId")] CurrentDevice currentDevice)
        {
            if (ModelState.IsValid)
            {
                db.CurrentDevice.Add(currentDevice);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(currentDevice);
        }

        // GET: CurrentDevices/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrentDevice currentDevice = await db.CurrentDevice.FindAsync(id);
            if (currentDevice == null)
            {
                return HttpNotFound();
            }
            return View(currentDevice);
        }

        // POST: CurrentDevices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FromIpAddress,ToDataBase,SyncId")] CurrentDevice currentDevice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(currentDevice).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(currentDevice);
        }

        // GET: CurrentDevices/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrentDevice currentDevice = await db.CurrentDevice.FindAsync(id);
            if (currentDevice == null)
            {
                return HttpNotFound();
            }
            return View(currentDevice);
        }

        // POST: CurrentDevices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            CurrentDevice currentDevice = await db.CurrentDevice.FindAsync(id);
            db.CurrentDevice.Remove(currentDevice);
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
