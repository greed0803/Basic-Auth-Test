using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Auth.Basic.Attribute;
using WebApplication1.Data;
using WebApplication1.Entity;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    [Route("hospitals")]
    [ApiController, BasicAuthorization]
    public class HospitalController : ControllerBase
    {
        private readonly WebApplication1Context _context;

        public HospitalController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: api/hospitals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalEntity>>> GetHospitalModel()
        {
            return await _context.HospitalModel.ToListAsync();
        }

        // GET: api/hospitals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalEntity>> GetHospitalModel(int id)
        {
            var hospitalModel = await _context.HospitalModel.FindAsync(id);

            if (hospitalModel == null)
            {
                return NotFound();
            }

            return hospitalModel;
        }

        // PUT: api/hospitals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalModel(int id, HospitalInput hospitalInput)
        {

            HospitalEntity hospitalEntity = new HospitalEntity
            {
                HospitalId = id,
                HospitalName = hospitalInput.HospitalName
            };

            _context.Entry(hospitalEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/hospitals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HospitalEntity>> PostHospitalModel(HospitalInput hospitalInput)
        {
            HospitalEntity hospitalEntity = new HospitalEntity
            {
                HospitalName = hospitalInput.HospitalName
            };

            _context.HospitalModel.Add(hospitalEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospitalModel", new { id = hospitalEntity.HospitalId }, hospitalEntity);
        }

        // DELETE: api/hospitals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHospitalModel(int id)
        {
            var hospitalModel = await _context.HospitalModel.FindAsync(id);
            if (hospitalModel == null)
            {
                return NotFound();
            }

            _context.HospitalModel.Remove(hospitalModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HospitalEntityExists(int id)
        {
            return _context.HospitalModel.Any(e => e.HospitalId == id);
        }
    }
}
