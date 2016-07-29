using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WorkMan.Core;

namespace WorkMan.WebAPI.Controllers
{
    public class VacationsController : ApiController
    {
        private ModelWorkMan db = new ModelWorkMan();

        // GET: api/Vacations
        public IQueryable<Vacation> GetVacations()
        {
            return db.Vacations;
        }

        // GET: api/Vacations/5
        [ResponseType(typeof(Vacation))]
        public async Task<IHttpActionResult> GetVacation(int id)
        {
            Vacation vacation = await db.Vacations.FindAsync(id);
            if (vacation == null)
            {
                return NotFound();
            }

            return Ok(vacation);
        }

        // PUT: api/Vacations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVacation(int id, Vacation vacation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vacation.VacationID)
            {
                return BadRequest();
            }

            db.Entry(vacation).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VacationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Vacations
        [ResponseType(typeof(Vacation))]
        public async Task<IHttpActionResult> PostVacation(Vacation vacation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vacations.Add(vacation);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = vacation.VacationID }, vacation);
        }

        // DELETE: api/Vacations/5
        [ResponseType(typeof(Vacation))]
        public async Task<IHttpActionResult> DeleteVacation(int id)
        {
            Vacation vacation = await db.Vacations.FindAsync(id);
            if (vacation == null)
            {
                return NotFound();
            }

            db.Vacations.Remove(vacation);
            await db.SaveChangesAsync();

            return Ok(vacation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VacationExists(int id)
        {
            return db.Vacations.Count(e => e.VacationID == id) > 0;
        }
    }
}