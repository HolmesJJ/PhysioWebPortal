using PhysioWebPortal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using PhysioWebPortal.DTO;

namespace PhysioWebPortal.Controllers
{
    [Authorize]
    [RoutePrefix("api/prescribedexercises")]
    public class PrescribedExercisesController : ApiController
    {
        private PHYSIODBEntities db = new PHYSIODBEntities();

        private static readonly Expression<Func<PrescribedExercis, PrescribedExerciseDto>> AsPrescribedDto =
            p => new PrescribedExerciseDto
            {
                PEId = p.PEId,
                ExId = p.ExId,
                AssignedDate = p.AssignedDate,
                EndDate = p.EndDate,
                ExSetNo = p.ExSetNo,
                ExRepNo = p.ExRepNo,
                ExTimePerDay = p.ExTimePerDay,
                StayId = p.StayId,
                LastUpdated = p.LastUpdated,
                LastUpdatedBy = p.LastUpdatedBy

            };

        [Route("")]
        public IQueryable<PrescribedExerciseDto> GetPrescribedExercises()
        {
            return db.PrescribedExercises.Include(p => p.PEId).Select(AsPrescribedDto);
        }

        [Route("{Id}")]
        [ResponseType(typeof(PrescribedExerciseDto))]
        public async Task<IHttpActionResult> GetPrescribedExercise(int id)
        {
            PrescribedExerciseDto prescribed = await db.PrescribedExercises.Include(p => p.PEId)
                .Where(p => p.PEId == id)
                .Select(AsPrescribedDto)
                .FirstOrDefaultAsync();
            if (prescribed == null)
            {
                return NotFound();
            }
            return Ok(prescribed);
        }

        [Route("{Id}/exercise")]
        [ResponseType(typeof(ExerciseDto))]
        public async Task<IHttpActionResult> GetExericseFromPrescribed(int id)
        {
            var exercise = await (from b in db.PrescribedExercises.Include(b => id)
                                  join a in db.Exercises
                                  on b.ExId equals a.ExId
                                  where b.PEId == id
                                  select new ExerciseDto
                                  {
                                      ExId = a.ExId,
                                      ExAngleLyingPose = a.ExAngleLyingPose,
                                      ExAngleMeasureType = a.ExAngleMeasureType,
                                      ExAngleStandingPose = a.ExAngleStandingPose,
                                      ExDescription = a.ExDescription,
                                      ExHoldDuration = a.ExHoldDuration,
                                      ExName = a.ExName,
                                      ExNameMalay = a.ExNameMalay,
                                      ExNameMandarin = a.ExNameMandarin,
                                      ExNameTamil = a.ExNameTamil,
                                      ExRepNo = a.ExRepNo,
                                      ExSetNo = a.ExSetNo,
                                      ExTimePerDay = a.ExTimePerDay,
                                      LastUpdated = a.LastUpdated,
                                      LastUpdatedBy = a.LastUpdatedBy

                                  }).FirstOrDefaultAsync();

            if (exercise == null)
            {
                return NotFound();
            }
            return Ok(exercise);
        }

        ////GET: api/PrescribedExercises
        //public IQueryable<PrescribedExercis> GetPrescribedExercises()
        //{
        //    var prescribeds = db.PrescribedExercises;

        //    return prescribeds;
        //}

        ////GET: api/PrescribedExercises/...
        //[ResponseType(typeof(PrescribedExercis))]
        //public async Task<IHttpActionResult> GetPrescribedExercise(Int32 id)
        //{
        //    PrescribedExercis prescribed = await db.PrescribedExercises.FindAsync(id);
        //    if (prescribed == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(prescribed);
        //}

        //PUT: api/PrescribedExercises/...
        [ResponseType(typeof(void))]
        [Route("{Id}")]
        public async Task<IHttpActionResult> PutPrescribedExericse(Int32 id, PrescribedExercis prescribed)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id != prescribed.PEId)
            {
                return BadRequest();
            }

            db.Entry(prescribed).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrescribedExerciseExists(id))
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

        //POST: api/PrescribedExercises
        [ResponseType(typeof(PrescribedExercis))]
        [Route("")]
        public async Task<IHttpActionResult> PostPrescribedExericse(PrescribedExercis prescribed)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.PrescribedExercises.Add(prescribed);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if(PrescribedExerciseExists(prescribed.PEId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            //return CreatedAtRoute("DefaultApi", new { id = prescribed.PEId }, prescribed);
            return Ok("Success");
        }

        //DELETE: api/PrescribedExercises/...
        [Route("{Id}")]
        public async Task<IHttpActionResult> DeletePrescribedExericse(Int32 id)
        {
            PrescribedExercis prescribed = await db.PrescribedExercises.FindAsync(id);
            if(prescribed == null)
            {
                return NotFound();
            }

            db.PrescribedExercises.Remove(prescribed);
            await db.SaveChangesAsync();

            return Ok(prescribed);
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PrescribedExerciseExists(Int32 id)
        {
            return db.PrescribedExercises.Count(e => e.PEId == id) > 0;
        }
    }
}