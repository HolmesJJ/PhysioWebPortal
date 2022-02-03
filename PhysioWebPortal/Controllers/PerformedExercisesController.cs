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
using System.Net.Http;
using System.IO;
using System.Diagnostics;

namespace PhysioWebPortal.Controllers
{
    [RoutePrefix("api/performedexercises")]
    [Authorize]
    public class PerformedExercisesController : ApiController
    {
        private PHYSIODBEntities db = new PHYSIODBEntities();

        private static readonly Expression<Func<PerformedExercis, PerformedExerciseDto>> AsPerformedExerciseDto =
            p => new PerformedExerciseDto
            {
                PerformExId = p.PerformExId,
                PEId = p.PEId,
                StartTime = p.StartTime,
                EndTime = p.EndTime,
                ExSetNo = p.ExSetNo,
                ExRepNo = p.ExRepNo,
                ExType = p.ExType,
                AvgAngle = p.AvgAngle,
                AvgHoldDuration = p.AvgHoldDuration,
                ExVisualFile = p.ExVisualFile,
                LastUpdated = p.LastUpdated,
                LastUpdatedBy = p.LastUpdatedBy,
                Score = p.Score,
                PatientId = p.PrescribedExercis.HospitalStay.PatientId
            };

        [Route("")]
        public IQueryable<PerformedExerciseDto> GetPerformedExercises()
        {
            return db.PerformedExercises.Include(p => p.PerformExId).Select(AsPerformedExerciseDto);
        }

        [Route("{Id}")]
        [ResponseType(typeof(PerformedExerciseDto))]
        public async Task<IHttpActionResult> GetPerformedExercise(int id)
        {
            PerformedExerciseDto performed = await db.PerformedExercises.Include(p => p.PerformExId)
                .Where(p => p.PerformExId == id)
                .Select(AsPerformedExerciseDto)
                .FirstOrDefaultAsync();
            if (performed == null)
            {
                return NotFound();
            }
            return Ok(performed);
        }
        

        //PUT: api/performedexercises/...
        [ResponseType(typeof(void))]
        [Route("{Id}")]
        public async Task<IHttpActionResult> PutPerformedExercise(Int32 id, PerformedExercis performed)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(id != performed.PerformExId)
            {
                return BadRequest();
            }

            db.Entry(performed).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerformedExerciseExists(id))
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

        //POST: api/performedexercises
        [ResponseType(typeof(PerformedExercis))]
        [Route("")]
        public async Task<IHttpActionResult> PostPerformedExercise(PerformedExercis performed)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.PerformedExercises.Add(performed);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                if(PerformedExerciseExists(performed.PerformExId))
                {
                    return Ok(e.InnerException.Message);
                }
                else
                {
                    throw;
                }
            }
            //return CreatedAtRoute("DefaultApi", new { id = performed.PerformExId }, performed);
            return Ok("success");
        }
        

        //DELETE: api/performedexercise/...
        [ResponseType(typeof(PerformedExercis))]
        [Route("{Id}")]
        public async Task<IHttpActionResult> DeletePerformedExercise(Int32 id)
        {
            PerformedExercis performed = await db.PerformedExercises.FindAsync(id);
            if(performed == null)
            {
                return NotFound();
            }

            db.PerformedExercises.Remove(performed);
            await db.SaveChangesAsync();

            return Ok(performed);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PerformedExerciseExists(Int32 id)
        {
            return db.PerformedExercises.Count(e => e.PerformExId == id) > 0;
        }


        //POST upload files
        //[Route("{Id}")]
        public HttpResponseMessage Post()
        {
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;

            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();

                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath("~/ZipFiles" + postedFile.FileName);
                    postedFile.SaveAs(filePath);

                    docfiles.Add(filePath);
                }

                result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return result;
        }
    }
}