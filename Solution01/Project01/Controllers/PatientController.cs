using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Project01.Models;

namespace Project01.Controllers
{
    [Route("api/patients")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly MyDbContext iContext;

        public PatientController(MyDbContext context)
        {
            iContext = context;
        }

        [HttpGet]
        public IActionResult GetPatients()
        {
            var res = iContext.Patient.ToList();
            return Ok(res);
        }

        [HttpDelete("delete/{index}")]
        public IActionResult DeletePatient(int index)
        {
            try
            {
                var patient = new Patient
                {
                    IdPatient = index
                };
                iContext.Patient.Attach(patient);
                iContext.Patient.Remove(patient);
                iContext.SaveChanges();
                return Ok($"Patient with ID({index}) has been deleted");
            }
            catch (SqlException ex)
            {
                return BadRequest($"Patient with ID({index}) does not exist.");
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}