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
    [RoutePrefix("api/patientcaregivers")]
    public class PatientCaregiversController : ApiController
    {
        private PHYSIODBEntities db = new PHYSIODBEntities();

        private static readonly Expression<Func<PatientCaregiver, PatientCaregiverDto>> AsPatientCaregiverDto =
            p => new PatientCaregiverDto
            {
                PatientId = p.PatientId,
                CaregiverId = p.CaregiverId,
                LastUpdated = p.LastUpdated,
                LastUpdatedBy = p.LastUpdatedBy
            };

        [Route("")]
        public IQueryable<PatientCaregiverDto> GetPatientCaregivers()
        {
            return db.PatientCaregivers.Include(p => p.CaregiverId).Select(AsPatientCaregiverDto);
        }

        [Route("{Id}")]
        [ResponseType(typeof(PatientCaregiverDto))]
        public async Task<IHttpActionResult> GetPatientCaregiver(string id)
        {
            PatientCaregiverDto caregiver = await db.PatientCaregivers.Include(p => p.CaregiverId)
                .Where(p => p.CaregiverId == id)
                .Select(AsPatientCaregiverDto)
                .FirstOrDefaultAsync();
            if (caregiver == null)
            {
                return NotFound();
            }
            return Ok(caregiver);
        }

        ////GET: /api/patientcaregivers
        //public IQueryable<PatientCaregiver> GetPatientCaregivers()
        //{
        //    var caregivers = db.PatientCaregivers;

        //    return caregivers;
        //}

        ////GET: /api/patientcaregivers/...
        //[ResponseType(typeof(PatientCaregiver))]
        //public async Task<IHttpActionResult> GetPatientCaregiver(string id)
        //{
        //    PatientCaregiver caregiver = await db.PatientCaregivers.FindAsync(id);
        //    if (caregiver == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(caregiver);
        //}

        //PUT: /api/patientcaregivers/...
        [ResponseType(typeof(void))]
        [Route("{Id}")]
        public async Task<IHttpActionResult> PutPatientCaregiver(string id, PatientCaregiver caregiver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != caregiver.CaregiverId)
            {
                return BadRequest();
            }

            db.Entry(caregiver).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientCaregiverExists(id))
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

        //POST: api/patientcaregivers
        [ResponseType(typeof(PatientCaregiver))]
        [Route("")]
        public async Task<IHttpActionResult> PostPatientCaregiver(PatientCaregiver caregiver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PatientCaregivers.Add(caregiver);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PatientCaregiverExists(caregiver.CaregiverId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = caregiver.CaregiverId }, caregiver);
        }

        //DELETE: api/patientcaregivers/...
        [ResponseType(typeof(PatientCaregiver))]
        [Route("{Id}")]
        public async Task<IHttpActionResult> DeletePatientCaregiver(string id)
        {
            PatientCaregiver caregiver = await db.PatientCaregivers.FindAsync(id);
            if (caregiver == null)
            {
                return NotFound();
            }

            db.PatientCaregivers.Remove(caregiver);
            await db.SaveChangesAsync();

            return Ok(caregiver);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatientCaregiverExists(string id)
        {
            return db.PatientCaregivers.Count(e => e.PatientId == id) > 0;
        }
    }
}