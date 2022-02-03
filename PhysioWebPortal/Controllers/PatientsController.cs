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
using System.Web;
using System.Linq.Expressions;
using PhysioWebPortal.DTO;

namespace PhysioWebPortal.Controllers
{
    [Authorize]
    [RoutePrefix("api/patients")]
    public class PatientsController : ApiController
    {
        private PHYSIODBEntities db = new PHYSIODBEntities();

        private static readonly Expression<Func<Patient, PatientDto>> AsPatientDto =
            p => new PatientDto
            {
                Id = p.Id,
                PatientCodeName = p.PatientCodeName,
                Remarks = p.Remarks,
                LastUpdated = p.LastUpdated,
                PreferredLanguage = p.PreferredLanguage,
                LastUpdatedBy = p.LastUpdatedBy
            };
        
        [Route("")]
        public IQueryable<PatientDto> GetPatients()
        {
            return db.Patients.Include(p => p.Id).Select(AsPatientDto);
        }

        [Route("{Id}")]
        [ResponseType(typeof(PatientDto))]
        public async Task<IHttpActionResult> GetPatient(string id)
        {
            PatientDto patient = await db.Patients.Include(p => p.Id)
                .Where(p => p.Id == id)
                .Select(AsPatientDto)
                .FirstOrDefaultAsync();
            if(patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }


        [Route("{id}/hospitalstay")]
        [ResponseType(typeof(HospitalStayDto))]
        public async Task<IHttpActionResult> GetStayId(string id)
        {
            var stayid =  (from a in db.Patients.Include(a => id)
                                join b in db.HospitalStays
                                on a.Id equals b.PatientId
                                where a.Id == id
                                select new HospitalStayDto
                                {
                                    StayId = b.StayId,
                                    PatientId = b.PatientId,
                                    EndDate = b.EndDate,
                                    LastUpdated = b.LastUpdated,
                                    LastUpdatedBy = b.LastUpdatedBy,
                                    PhysiotherapistId = b.PhysiotherapistId,
                                    Pose = b.Pose,
                                    Remarks = b.Remarks,
                                    StartDate = b.StartDate,

                                }).ToList();

            if(stayid == null)
            {
                return NotFound();
            }
            return Ok(stayid);
        }


        //Get Prescribed Exercises based on Patient's ID
        [Route("{Id}/{hosId}/prescribed")]
        [ResponseType(typeof(PrescribedExerciseDto))]
        public async Task<IHttpActionResult> GetPrescribedExercises(string id, int hosId)
        {
            var exercise =  (from b in db.Patients.Include(b => id)
                                  join a in db.HospitalStays
                                  on b.Id equals a.PatientId
                                  join c in db.PrescribedExercises
                                  on a.StayId equals c.StayId
                                  join d in db.Exercises
                                  on c.ExId equals d.ExId
                                  join e in db.ExerciseVideos
                                  on d.ExId equals e.ExId
                                  where b.Id == id && a.StayId == hosId
                                  select new PrescribedExerciseDto
                                  {
                                      Id = b.Id,
                                      PEId = c.PEId,
                                      StayId = a.StayId,
                                      ExId = c.ExId,
                                      AssignedDate = c.AssignedDate,
                                      EndDate = c.EndDate,
                                      ExRepNo = c.ExRepNo,
                                      ExSetNo = c.ExSetNo,
                                      ExTimePerDay = c.ExTimePerDay,
                                      LastUpdated = c.LastUpdated,
                                      LastUpdatedBy = c.LastUpdatedBy,
                                      ExName = d.ExName,
                                      VThumbnail = e.VThumbnail,
                                      //ExType = d.ExType
                                  }).ToList();

            if(exercise == null)
            {
                return NotFound();
            }
            return Ok(exercise);
        }

        [Route("{Id}/performed")]
        [ResponseType(typeof(PerformedExerciseDto))]
        public async Task<IHttpActionResult> GetPerformedExercise(string id)
        {
            var performed =  (from b in db.Patients.Include(b => id)
                                  join a in db.HospitalStays
                                  on b.Id equals a.PatientId
                                  join c in db.PrescribedExercises
                                  on a.StayId equals c.StayId
                                  join d in db.PerformedExercises
                                  on c.PEId equals d.PEId
                                  join e in db.Exercises
                                  on c.ExId equals e.ExId
                                  where b.Id == id
                                  select new PerformedExerciseDto
                                  {
                                      PerformExId = d.PerformExId,
                                      ExName = e.ExName,
                                      PEId = d.PEId,
                                      EndTime = d.EndTime,
                                      AvgHoldDuration = d.AvgHoldDuration,
                                      AvgAngle = d.AvgAngle,
                                      ExRepNo = d.ExRepNo,
                                      ExSetNo = d.ExSetNo,
                                      ExType = d.ExType,
                                      ExVisualFile = d.ExVisualFile,
                                      LastUpdated = d.LastUpdated,
                                      LastUpdatedBy = d.LastUpdatedBy,
                                      Score = d.Score,
                                      StartTime = d.StartTime,
                                      ExId = e.ExId,
                                      ExTimePerDay = e.ExTimePerDay,
                                      PatientCodeName = b.PatientCodeName,
                                      PatientId = b.Id

                                  }).ToList();

            if (performed == null)
            {
                return NotFound();
            }
            return Ok(performed);
        }

        [Route("{Id}/gift")]
        [ResponseType(typeof(GiftDto))]
        public async Task<IHttpActionResult> GetGift(string id)
        {
            var gift = (from b in db.Patients.Include(b => id)
                             join a in db.HospitalStays
                             on b.Id equals a.PatientId
                             join c in db.GiftReceiveds
                             on a.StayId equals c.StayId
                             join d in db.Gifts
                             on c.GiftTypeId equals d.GiftTypeId
                             where b.Id == id
                             select new GiftDto
                             {
                                 GiftTypeId = d.GiftTypeId

                             }).ToList();

            if (gift == null)
            {
                return NotFound();
            }
            return Ok(gift);
        }

        [Route("{Id}/exercise")]
        [ResponseType(typeof(ExerciseDto))]
        public async Task<IHttpActionResult> GetExercisesByID(string id)
        {
            var exercise = await (from b in db.Patients.Include(b => id)
                                  join a in db.HospitalStays
                                  on b.Id equals a.PatientId
                                  join c in db.PrescribedExercises
                                  on a.StayId equals c.StayId
                                  join d in db.Exercises
                                  on c.ExId equals d.ExId
                                  where b.Id == id
                                  select new ExerciseDto
                                  {
                                      ExId = d.ExId,
                                      ExAngleLyingPose = d.ExAngleLyingPose,
                                      ExAngleMeasureType = d.ExAngleMeasureType,
                                      ExAngleStandingPose = d.ExAngleStandingPose,
                                      ExDescription = d.ExDescription,
                                      ExHoldDuration = d.ExHoldDuration,
                                      ExName = d.ExName,
                                      ExNameMalay = d.ExNameMalay,
                                      ExNameMandarin = d.ExNameMandarin,
                                      ExNameTamil = d.ExNameTamil,
                                      ExRepNo = d.ExRepNo,
                                      ExSetNo = d.ExSetNo,
                                      ExTimePerDay = d.ExTimePerDay,
                                      ExerciseVideos = d.ExerciseVideos,
                                      LastUpdated = d.LastUpdated,
                                      LastUpdatedBy = d.LastUpdatedBy

                                  }).FirstOrDefaultAsync();
            if (exercise == null)
            {
                return NotFound();
            }
            return Ok(exercise);
        }

        ////GET: api/Patients
        //public IQueryable<Patient> GetPatients()
        //{

            //    var patients = db.Patients;

            //    return patients;
            //}

            //// GET: api/Patients/...
            //[ResponseType(typeof(Patient))]
            //public async Task<IHttpActionResult> GetPatient(string id)
            //{
            //    Patient patient = await db.Patients.FindAsync(id);
            //    if (patient == null)
            //    {
            //        return NotFound();
            //    }

            //    return Ok(patient);
            //}


            // PUT: api/Patients/...
        [ResponseType(typeof(void))]
        [Route("{Id}")]
        public async Task<IHttpActionResult> PutPatient(string id, Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patient.Id)
            {
                return BadRequest();
            }

            db.Entry(patient).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(id))
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
        
        // POST: api/Patients
        [ResponseType(typeof(Patient))]
        [Route("")]
        public async Task<IHttpActionResult> PostPatient(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Patients.Add(patient);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PatientExists(patient.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = patient.Id }, patient);
        }

        // DELETE: api/Patients/...
        [Route("{Id}")]
        [ResponseType(typeof(Patient))]
        public async Task<IHttpActionResult> DeletePatient(string id)
        {
            Patient patient = await db.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            db.Patients.Remove(patient);
            await db.SaveChangesAsync();

            return Ok(patient);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatientExists(string id)
        {
            return db.Patients.Count(e => e.Id == id) > 0;
        }
    }
}