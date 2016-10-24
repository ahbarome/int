using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using INT.Service.DAL.Model;

namespace INT.Service.WebApp.Controllers
{
    public class LoadTracesController : Controller
    {
        private IntellisoftEntities db = new IntellisoftEntities();

        // GET: LoadTraces
        public async Task<ActionResult> Index()
        {
            return View(await db.LoadTrace.ToListAsync());
        }

        // GET: LoadTraces/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoadTrace loadTrace = await db.LoadTrace.FindAsync(id);
            if (loadTrace == null)
            {
                return HttpNotFound();
            }
            return View(loadTrace);
        }

        // GET: LoadTraces/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoadTraces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,IpAddress,LastLoadDate,ServerName")] LoadTrace loadTrace)
        {
            if (ModelState.IsValid)
            {
                db.LoadTrace.Add(loadTrace);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(loadTrace);
        }

        // GET: LoadTraces/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoadTrace loadTrace = await db.LoadTrace.FindAsync(id);
            if (loadTrace == null)
            {
                return HttpNotFound();
            }
            return View(loadTrace);
        }

        // POST: LoadTraces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,IpAddress,LastLoadDate,ServerName")] LoadTrace loadTrace)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loadTrace).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(loadTrace);
        }

        // GET: LoadTraces/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoadTrace loadTrace = await db.LoadTrace.FindAsync(id);
            if (loadTrace == null)
            {
                return HttpNotFound();
            }
            return View(loadTrace);
        }

        // POST: LoadTraces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LoadTrace loadTrace = await db.LoadTrace.FindAsync(id);
            db.LoadTrace.Remove(loadTrace);
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
