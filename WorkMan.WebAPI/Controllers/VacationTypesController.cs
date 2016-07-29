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
    public class VacationTypesController : ApiController
    {
        private ModelWorkMan db = new ModelWorkMan();

        // GET: api/VacationTypes
        public IQueryable<VacationType> GetVacationTypes()
        {
            return db.VacationTypes;
        }

        // GET: api/VacationTypes/5
        [ResponseType(typeof(VacationType))]
        public async Task<IHttpActionResult> GetVacationType(int id)
        {
            VacationType vacationType = await db.VacationTypes.FindAsync(id);
            if (vacationType == null)
            {
                return NotFound();
            }

            return Ok(vacationType);
        }

        // PUT: api/VacationTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVacationType(int id, VacationType vacationType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vacationType.VacationTypeID)
            {
                return BadRequest();
            }

            db.Entry(vacationType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VacationTypeExists(id))
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

        // POST: api/VacationTypes
        [ResponseType(typeof(VacationType))]
        public async Task<IHttpActionResult> PostVacationType(VacationType vacationType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VacationTypes.Add(vacationType);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = vacationType.VacationTypeID }, vacationType);
        }

        // DELETE: api/VacationTypes/5
        [ResponseType(typeof(VacationType))]
        public async Task<IHttpActionResult> DeleteVacationType(int id)
        {
            VacationType vacationType = await db.VacationTypes.FindAsync(id);
            if (vacationType == null)
            {
                return NotFound();
            }

            db.VacationTypes.Remove(vacationType);
            await db.SaveChangesAsync();

            return Ok(vacationType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VacationTypeExists(int id)
        {
            return db.VacationTypes.Count(e => e.VacationTypeID == id) > 0;
        }
    }
}