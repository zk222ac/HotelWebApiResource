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
using HotelWebApiResource.Models;

namespace HotelWebApiResource.Controllers
{
    public class VdistinctRoomNoesController : ApiController
    {
        private HotelContext db = new HotelContext();

        // GET: api/VdistinctRoomNoes
        public IQueryable<VdistinctRoomNo> GetVdistinctRoomNoes()
        {
            return db.VdistinctRoomNoes;
        }

        // GET: api/VdistinctRoomNoes/5
        [ResponseType(typeof(VdistinctRoomNo))]
        public async Task<IHttpActionResult> GetVdistinctRoomNo(int id)
        {
            VdistinctRoomNo vdistinctRoomNo = await db.VdistinctRoomNoes.FindAsync(id);
            if (vdistinctRoomNo == null)
            {
                return NotFound();
            }

            return Ok(vdistinctRoomNo);
        }

        // PUT: api/VdistinctRoomNoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVdistinctRoomNo(int id, VdistinctRoomNo vdistinctRoomNo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vdistinctRoomNo.RoomNo)
            {
                return BadRequest();
            }

            db.Entry(vdistinctRoomNo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VdistinctRoomNoExists(id))
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

        // POST: api/VdistinctRoomNoes
        [ResponseType(typeof(VdistinctRoomNo))]
        public async Task<IHttpActionResult> PostVdistinctRoomNo(VdistinctRoomNo vdistinctRoomNo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VdistinctRoomNoes.Add(vdistinctRoomNo);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VdistinctRoomNoExists(vdistinctRoomNo.RoomNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vdistinctRoomNo.RoomNo }, vdistinctRoomNo);
        }

        // DELETE: api/VdistinctRoomNoes/5
        [ResponseType(typeof(VdistinctRoomNo))]
        public async Task<IHttpActionResult> DeleteVdistinctRoomNo(int id)
        {
            VdistinctRoomNo vdistinctRoomNo = await db.VdistinctRoomNoes.FindAsync(id);
            if (vdistinctRoomNo == null)
            {
                return NotFound();
            }

            db.VdistinctRoomNoes.Remove(vdistinctRoomNo);
            await db.SaveChangesAsync();

            return Ok(vdistinctRoomNo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VdistinctRoomNoExists(int id)
        {
            return db.VdistinctRoomNoes.Count(e => e.RoomNo == id) > 0;
        }
    }
}