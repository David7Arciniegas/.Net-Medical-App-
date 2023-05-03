using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors; 
using TestApplication.Models;

namespace TestApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorSearchApiController : ControllerBase
    {
        // Exacmple of static view and generators
        private static readonly List<DoctorSearchResult> _doctorsAndClinics = new List<DoctorSearchResult>
        {
            new DoctorSearchResult { Name = "Dr. John Smith", City = "New York" },
            new DoctorSearchResult { Name = "Clinic ABC", City = "Los Angeles" },
            // Agrega más doctores y clínicas aquí
        };

        [HttpGet]
        [EnableCors("AllowAllOrigins")] // Add this line
        public ActionResult<IEnumerable<DoctorSearchResult>> Search(string doctorOrClinicName, string city)
        {
            var results = _doctorsAndClinics
                .Where(d => (string.IsNullOrEmpty(doctorOrClinicName) || d.Name.Contains(doctorOrClinicName))
                         && (string.IsNullOrEmpty(city) || d.City.Contains(city)))
                .ToList();

            return Ok(results);
        }
    }
}
