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
    [RoutePrefix("api/hospitalstay")]
    public class HospitalStayController : ApiController
    {
        private PHYSIODBEntities db = new PHYSIODBEntities();

        private static readonly Expression<Func<HospitalStay, HospitalStayDto>> AsHosptialStayDto =
            p => new HospitalStayDto
            {
                StayId = p.StayId,
                PatientId = p.PatientId,
                PhysiotherapistId = p.PhysiotherapistId,
                StartDate = p.StartDate,
                Pose = p.Pose,
                EndDate = p.EndDate,
                LastUpdated = p.LastUpdated,
                LastUpdatedBy = p.LastUpdatedBy,
                Remarks = p.Remarks
            };

        [Route("")]
        public IQueryable<HospitalStayDto> GetHospitalStays()
        {
            return db.HospitalStays.Include(p => p.StayId).Select(AsHosptialStayDto);
        }

        [Route("{Id}")]
        [ResponseType(typeof(HospitalStayDto))]
        public async Task<IHttpActionResult> GetHospitalStay(int id)
        {
            HospitalStayDto stay = await db.HospitalStays.Include(p => p.StayId)
                .Where(p => p.StayId == id)
                .Select(AsHosptialStayDto)
                .FirstOrDefaultAsync();
            if (stay == null)
            {
                return NotFound();
            }
            return Ok(stay);
        }

        [Route("{id}/performed")]
        [ResponseType(typeof(PerformedExerciseDto))]
        public async Task<IHttpActionResult> GetPerformedExercises(int id)
        {
            var performed = (from a in db.HospitalStays.Include(a => id)
                              join b in db.PrescribedExercises
                              on a.StayId equals b.StayId
                              join c in db.PerformedExercises
                              on b.PEId equals c.PEId
                              join d in db.Patients
                              on a.PatientId equals d.Id
                              join e in db.Exercises
                              on b.ExId equals e.ExId
                              where a.StayId == id
                              select new PerformedExerciseDto
                              {
                                  AvgAngle = c.AvgAngle,
                                  AvgHoldDuration = c.AvgHoldDuration,
                                  EndTime = c.EndTime,
                                  ExId = b.ExId,
                                  PatientId = a.PatientId,
                                  ExRepNo = c.ExRepNo,
                                  ExSetNo = c.ExSetNo,
                                  ExVisualFile = c.ExVisualFile,
                                  LastUpdated = c.LastUpdated,
                                  LastUpdatedBy = c.LastUpdatedBy,
                                  PerformExId = c.PerformExId,
                                  PEId = c.PEId,
                                  StartTime = c.StartTime,
                                  ExType = c.ExType,
                                  Score = c.Score,
                                  PatientCodeName = d.PatientCodeName,
                                  StayId = a.StayId,
                                  ExTimePerDay = b.ExTimePerDay,
                                  ExName = e.ExName
                              }).ToList();

            if (performed == null)
            {
                return NotFound();
            }
            return Ok(performed);
        }

        [Route("{id}/performed/{peId}")]
        [ResponseType(typeof(PerformedExerciseDto))]
        public async Task<IHttpActionResult> GetPEIDandStayId(int id, int peId)
        {
            var performed = (from a in db.HospitalStays.Include(a => id)
                             join b in db.PrescribedExercises
                             on a.StayId equals b.StayId
                             join c in db.PerformedExercises
                             on b.PEId equals c.PEId
                             join d in db.Patients
                             on a.PatientId equals d.Id
                             join e in db.Exercises
                             on b.ExId equals e.ExId
                             where a.StayId == id && b.PEId == peId
                             select new PerformedExerciseDto
                             {
                                 AvgAngle = c.AvgAngle,
                                 AvgHoldDuration = c.AvgHoldDuration,
                                 EndTime = c.EndTime,
                                 ExId = b.ExId,
                                 PatientId = a.PatientId,
                                 ExRepNo = c.ExRepNo,
                                 ExSetNo = c.ExSetNo,
                                 ExVisualFile = c.ExVisualFile,
                                 LastUpdated = c.LastUpdated,
                                 LastUpdatedBy = c.LastUpdatedBy,
                                 PerformExId = c.PerformExId,
                                 PEId = c.PEId,
                                 StartTime = c.StartTime,
                                 ExType = c.ExType,
                                 Score = c.Score,
                                 PatientCodeName = d.PatientCodeName,
                                 StayId = a.StayId,
                                 ExTimePerDay = e.ExTimePerDay,
                                 ExName = e.ExName
                             }).ToList();

            if (performed == null)
            {
                return NotFound();
            }
            return Ok(performed);
        }

        [Route("{id}/prescribed")]
        [ResponseType(typeof(PrescribedExerciseDto))]
        public async Task<IHttpActionResult> GetPrescribedExericses(int id)
        {
            var prescribed =  (from a in db.HospitalStays.Include(a => id)
                                    join b in db.PrescribedExercises
                                    on a.StayId equals b.StayId
                                    join c in db.ExerciseVideos
                                    on b.ExId equals c.ExId
                                    join d in db.Exercises
                                    on b.ExId equals d.ExId
                                    where a.StayId == id
                                    select new PrescribedExerciseDto
                                    {
                                        ExRepNo = b.ExRepNo,
                                        ExSetNo = b.ExSetNo,
                                        ExTimePerDay = b.ExTimePerDay,
                                        StayId = b.StayId,
                                        AssignedDate = b.AssignedDate,
                                        EndDate = b.EndDate,
                                        ExId = b.ExId,
                                        PEId = b.PEId,
                                        LastUpdated = b.LastUpdated,
                                        LastUpdatedBy = b.LastUpdatedBy,
                                        VThumbnail = c.VThumbnail,
                                        ExName = d.ExName

                                    }).ToList();

            if (prescribed == null)
            {
                return NotFound();
            }
            return Ok(prescribed);
        }

        [Route("{id}/gifts")]
        [ResponseType(typeof(PrescribedExerciseDto))]
        public async Task<IHttpActionResult> GetGifts(int id)
        {
            var gifts = (from a in db.HospitalStays.Include(a => id)
                              join b in db.GiftReceiveds
                              on a.StayId equals b.StayId
                              join c in db.Gifts
                              on b.GiftTypeId equals c.GiftTypeId
                              where a.StayId == id
                              select new GiftDto
                              {
                                  GiftTypeId = c.GiftTypeId

                              }).ToList();

            if (gifts == null)
            {
                return NotFound();
            }
            return Ok(gifts);
        }

        ////GET: api/HospitalStay
        //public IQueryable<HospitalStay> GetHospitalStays()
        //{
        //    var stays = db.HospitalStays;
        //    return stays;
        //}

        ////GET: api/HospitalStay/...
        //[ResponseType(typeof(HospitalStay))]
        //public async Task<IHttpActionResult> GetHospitalStay(Int32 id)
        //{
        //    HospitalStay stay = await db.HospitalStays.FindAsync(id);
        //    if(stay == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(stay);
        //}

        //PUT: api/HospitalStay/...
        [ResponseType(typeof(void))]
        [Route("{Id}")]
        public async Task<IHttpActionResult> PutHospitalStay(Int32 id, HospitalStay stay)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id != stay.StayId)
            {
                return BadRequest();
            }

            db.Entry(stay).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!HospitalStayExists(id))
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

        //POST: api/HospitalStay/
        [ResponseType(typeof(HospitalStay))]
        [Route("")]
        public async Task<IHttpActionResult> PostHospitalStay(HospitalStay stay)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.HospitalStays.Add(stay);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HospitalStayExists(stay.StayId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("DefaultApi", new { id = stay.StayId }, stay);
        }

        //DELETE: api/HospitalStay/...
        [ResponseType(typeof(HospitalStay))]
        [Route("{Id}")]
        public async Task<IHttpActionResult> DeleteHospitalStay(Int32 id)
        {
            HospitalStay stay = await db.HospitalStays.FindAsync(id);
            if(stay == null)
            {
                return NotFound();
            }
            db.HospitalStays.Remove(stay);
            await db.SaveChangesAsync();

            return Ok(stay);
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HospitalStayExists(Int32 id)
        {
            return db.HospitalStays.Count(e => e.StayId == id) > 0;
        }
    }
}