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
    [RoutePrefix("api/exercises")]
    public class ExercisesController : ApiController
    {
        private PHYSIODBEntities db = new PHYSIODBEntities();

        private static readonly Expression<Func<Exercis, ExerciseDto>> AsExerciseDto =
            p => new ExerciseDto
            {
                ExId = p.ExId,
                ExAngleLyingPose = p.ExAngleLyingPose,
                ExAngleMeasureType = p.ExAngleMeasureType,
                ExAngleStandingPose = p.ExAngleStandingPose,
                ExDescription = p.ExDescription,
                ExHoldDuration = p.ExHoldDuration,
                ExName = p.ExName,
                ExNameMalay = p.ExNameMalay,
                ExNameMandarin = p.ExNameMandarin,
                ExNameTamil = p.ExNameTamil,
                ExRepNo = p.ExRepNo,
                ExSetNo = p.ExSetNo,
                ExTimePerDay = p.ExTimePerDay,
                //ExType = p.ExType,
                LastUpdated = p.LastUpdated,
                LastUpdatedBy = p.LastUpdatedBy
            };

        [Route("")]
        public IQueryable<ExerciseDto> GetExercises()
        {
            return db.Exercises.Include(p => p.ExId).Select(AsExerciseDto);
        }

        [Route("{Id}")]
        [ResponseType(typeof(ExerciseDto))]
        public async Task<IHttpActionResult> GetExercise(int id)
        {
            ExerciseDto exercise = await db.Exercises.Include(p => p.ExId)
                .Where(p => p.ExId == id)
                .Select(AsExerciseDto)
                .FirstOrDefaultAsync();
            if (exercise == null)
            {
                return NotFound();
            }
            return Ok(exercise);
        }

        [Route("{Id}/videos")]
        [ResponseType(typeof(ExerciseVideoDto))]
        public async Task<IHttpActionResult> GetVideosFromExercise(int id)
        {
            var video = await (from b in db.Exercises.Include(b => id)
                                  join a in db.ExerciseVideos
                                  on b.ExId equals a.ExId
                                  where b.ExId == id
                                  select new ExerciseVideoDto
                                  {
                                      VId = a.VId,
                                      ExId = a.ExId,
                                      LastUpdated = a.LastUpdated,
                                      LastUpdatedBy = a.LastUpdatedBy,
                                      VFileEnglish = a.VFileEnglish,
                                      VFileMalay = a.VFileMalay,
                                      VFileMandarin = a.VFileMandarin,
                                      VFileTamil = a.VFileTamil,
                                      VThumbnail = a.VThumbnail

                                  }).FirstOrDefaultAsync();

            if (video == null)
            {
                return NotFound();
            }
            return Ok(video);
        }

        ////GET: /api/exercises
        //public IQueryable<Exercis> GetExercises()
        //{
        //    var exercises = db.Exercises;

        //    return exercises;
        //}

        //[AllowAnonymous]
        ////GET: /api/exercises/...
        //[ResponseType(typeof(Exercis))]
        //public async Task<IHttpActionResult> GetExercise(Int32 id)
        //{
        //    Exercis exercise = await db.Exercises.FindAsync(id);
        //    if (exercise == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(exercise);
        //}

        //PUT: /api/exercises/...
        [ResponseType(typeof(void))]
        [Route("{Id}")]
        public async Task<IHttpActionResult> PutExercise(Int32 id, Exercis exercise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exercise.ExId)
            {
                return BadRequest();
            }

            db.Entry(exercise).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseExists(id))
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
        
        //POST: api/exercises
        [ResponseType(typeof(Exercis))]
        [Route("")]
        public async Task<IHttpActionResult> PostExercise(Exercis exercise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Exercises.Add(exercise);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ExerciseExists(exercise.ExId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = exercise.ExId }, exercise);
        }
        
        //DELETE: api/exercises/...
        [ResponseType(typeof(Exercis))]
        [Route("{Id}")]
        public async Task<IHttpActionResult> DeleteExercise(Int32 id)
        {
            Exercis exercise = await db.Exercises.FindAsync(id);
            if (exercise == null)
            {
                return NotFound();
            }

            db.Exercises.Remove(exercise);
            await db.SaveChangesAsync();

            return Ok(exercise);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExerciseExists(Int32 id)
        {
            return db.Exercises.Count(e => e.ExId == id) > 0;
        }
    }
}