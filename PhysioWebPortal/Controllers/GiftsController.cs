using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Linq.Expressions;
using PhysioWebPortal.DTO;

namespace PhysioWebPortal.Controllers
{
    [RoutePrefix("api/gifts")]
    [Authorize]
    public class GiftsController : ApiController
    {
        private PHYSIODBEntities db = new PHYSIODBEntities();

        private static readonly Expression<Func<Gift, GiftDto>> AsGiftDto =
            g => new GiftDto
            {
                GiftTypeId = g.GiftTypeId,
                Description = g.Description
            };

        [Route("")]
        public IQueryable<GiftDto> GetGifts()
        {
            return db.Gifts.Include(g => g.GiftTypeId).Select(AsGiftDto);
        }

        [Route("{Id}")]
        [ResponseType(typeof(GiftDto))]
        public async Task<IHttpActionResult> GetGift(int id)
        {
            GiftDto gift = await db.Gifts.Include(g => g.GiftTypeId)
                .Where(g => g.GiftTypeId == id)
                .Select(AsGiftDto)
                .FirstOrDefaultAsync();
            if (gift == null)
            {
                return NotFound();
            }
            return Ok(gift);
        }


        ////GET: api/gifts
        //public IQueryable<Gift> GetGifts()
        //{
        //    var gifts = db.Gifts;
        //    return gifts;
        //}

        ////GET: api/gifts/...
        //[ResponseType(typeof(Gift))]
        //public async Task<IHttpActionResult> GetGift(Int32 id)
        //{
        //    Gift gift = await db.Gifts.FindAsync(id);
        //    if (gift == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(gift);
        //}

        //PUT: api/gifts/...
        [ResponseType(typeof(void))]
        [Route("{Id}")]
        public async Task<IHttpActionResult> PutGift(Int32 id, Gift gift)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id != gift.GiftTypeId)
            {
                return BadRequest();
            }
            db.Entry(gift).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!GiftExists(id))
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

        //POST: api/gifts/...
        [Route("")]
        [ResponseType(typeof(Gift))]
        public async Task<IHttpActionResult> PostGift(Gift gift)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Gifts.Add(gift);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GiftExists(gift.GiftTypeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            //await db.SaveChangesAsync();

            //var dto = new GiftDto()
            //{
            //    GiftTypeId = gift.GiftTypeId,
            //    Description = gift.Description
            //};

            return CreatedAtRoute("DefaultApi", new { id = gift.GiftTypeId }, gift);
        }

        //DELETE: api/gifts/...
        [Route("{Id}")]
        [ResponseType(typeof(GiftDto))]
        public async Task<IHttpActionResult>DeleteGift(Int32 id)
        {
            Gift gift = await db.Gifts.FindAsync(id);
            if(gift == null)
            {
                return NotFound();
            }
            db.Gifts.Remove(gift);
            await db.SaveChangesAsync();

            return Ok(gift);
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GiftExists(Int32 id)
        {
            return db.Gifts.Count(e => e.GiftTypeId == id) > 0;
        }
    }
}