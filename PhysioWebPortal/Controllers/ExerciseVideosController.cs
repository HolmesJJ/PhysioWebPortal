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
    [Authorize]
    [RoutePrefix("api/exercisevideos")]
    public class ExerciseVideosController : ApiController
    {
        private PHYSIODBEntities db = new PHYSIODBEntities();

        private static readonly Expression<Func<ExerciseVideo, ExerciseVideoDto>> AsExerciseVideoDto =
            p => new ExerciseVideoDto
            {
                VId = p.VId,
                ExId = p.ExId,
                LastUpdated = p.LastUpdated,
                LastUpdatedBy = p.LastUpdatedBy,
                VFileEnglish = p.VFileEnglish,
                VFileMalay = p.VFileMalay,
                VFileMandarin = p.VFileMandarin,
                VFileTamil = p.VFileTamil,
                VThumbnail = p.VThumbnail
            };

        [Route("")]
        public IQueryable<ExerciseVideoDto> GetExerciseVideos()
        {
            return db.ExerciseVideos.Include(p => p.VId).Select(AsExerciseVideoDto);
        }

        [Route("{Id}")]
        [ResponseType(typeof(ExerciseVideoDto))]
        public async Task<IHttpActionResult> GetExerciseVideo(int id)
        {
            ExerciseVideoDto video = await db.ExerciseVideos.Include(p => p.VId)
                .Where(p => p.VId == id)
                .Select(AsExerciseVideoDto)
                .FirstOrDefaultAsync();
            if (video == null)
            {
                return NotFound();
            }
            return Ok(video);
        }

        

        //PUT: api/ExerciseVideos/...
        [ResponseType(typeof(void))]
        [Route("{Id}")]
        public async Task<IHttpActionResult> PutExerciseVideo(Int32 id, ExerciseVideo video)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id != video.VId)
            {
                return BadRequest();
            }
            db.Entry(video).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseVideoExists(id))
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
        
        //POST: api/ExerciseVideos
        [ResponseType(typeof(ExerciseVideo))]
        [Route("")]
        public async Task<IHttpActionResult> PostExerciseVideo(ExerciseVideo video)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.ExerciseVideos.Add(video);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if(ExerciseVideoExists(video.VId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("DefaultApi", new { id = video.VId }, video);
        }
        
        //DELETE: api/ExerciseVideos/...
        [ResponseType(typeof(ExerciseVideo))]
        [Route("{Id}")]
        public async Task<IHttpActionResult> DeleteExerciseVideo(Int32 id)
        {
            ExerciseVideo video = await db.ExerciseVideos.FindAsync(id);
            if(video == null)
            {
                return NotFound();
            }
            db.ExerciseVideos.Remove(video);
            await db.SaveChangesAsync();

            return Ok(video);
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExerciseVideoExists(Int32 id)
        {
            return db.ExerciseVideos.Count(e => e.VId == id) > 0;
        }
    }
}