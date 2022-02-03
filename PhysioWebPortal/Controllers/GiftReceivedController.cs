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
using PhysioWebPortal;
using System.Linq.Expressions;
using PhysioWebPortal.DTO;

namespace PhysioWebPortal.Controllers
{
    [Authorize]
    [RoutePrefix("api/giftreceived")]
    public class GiftReceivedController : ApiController
    {
        private PHYSIODBEntities db = new PHYSIODBEntities();

        private static readonly Expression<Func<GiftReceived, GiftReceivedDto>> AsGiftReceivedDto =
            g => new GiftReceivedDto
            {
                GiftReceivedId = g.GiftReceivedId,
                StayId = g.StayId,
                GiftTypeId = g.GiftTypeId,
                ReceivedDateTime = g.ReceivedDateTime,
                GivenById = g.GivenById
            };

        [Route("")]
        public IQueryable<GiftReceivedDto> GetGiftReceiveds()
        {
            return db.GiftReceiveds.Include(g => g.GiftReceivedId).Select(AsGiftReceivedDto);
        }

        [Route("{Id}")]
        [ResponseType(typeof(GiftReceivedDto))]
        public async Task<IHttpActionResult> GetGiftReceived(int id)
        {
            GiftReceivedDto received = await db.GiftReceiveds.Include(g => g.GiftReceivedId)
                .Where(g => g.GiftReceivedId == id)
                .Select(AsGiftReceivedDto)
                .FirstOrDefaultAsync();
            if (received == null)
            {
                return NotFound();
            }
            return Ok(received);
        }

        ////GET: api/giftreceived
        //public IQueryable<GiftReceived> GetGiftReceiveds()
        //{
        //    var receieved = db.GiftReceiveds;
        //    return receieved;
        //}

        ////GET: api/giftreceived/...
        //[ResponseType(typeof(GiftReceived))]
        //public async Task<IHttpActionResult> GetGiftReceived(Int32 id)
        //{
        //    GiftReceived received = await db.GiftReceiveds.FindAsync(id);
        //    if(received == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(received);
        //}

        //PUT: api/giftreceived/...
        [ResponseType(typeof(void))]
        [Route("{Id}")]
        public async Task<IHttpActionResult> PutGiftReceived(Int32 id, GiftReceived received)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id != received.GiftReceivedId)
            {
                return BadRequest();
            }
            db.Entry(received).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!GiftReceivedExists(id))
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

        //POST: api/giftreceived/...
        [ResponseType(typeof(GiftReceived))]
        [Route("")]
        public async Task<IHttpActionResult> PostGiftReceived(GiftReceived received)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.GiftReceiveds.Add(received);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if(GiftReceivedExists(received.GiftReceivedId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            //return CreatedAtRoute("DefaultApi", new { id = received.GiftReceivedId }, received);
            return Ok("Success");
        }

        //DELETE: api/giftreceived
        [ResponseType(typeof(GiftReceived))]
        [Route("{Id}")]
        public async Task<IHttpActionResult> DeleteGiftReceived(Int32 id)
        {
            GiftReceived received = await db.GiftReceiveds.FindAsync(id);
            if(received == null)
            {
                return NotFound();
            }
            db.GiftReceiveds.Remove(received);
            await db.SaveChangesAsync();

            return Ok(received);
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GiftReceivedExists(Int32 id)
        {
            return db.GiftReceiveds.Count(e => e.GiftReceivedId == id) > 0;
        }
    }
}