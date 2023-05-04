using System.Collections.Generic; // import namespace for List<>
using System.Linq; // import namespace for LINQ extensions
using Microsoft.AspNetCore.Mvc; // import namespace for MVC framework
using Microsoft.AspNetCore.Cors; // import namespace for CORS
using TestApplication.Models; // import namespace for DoctorSearchResult model

namespace TestApplication.Controllers
{
    [ApiController] // attribute to indicate that this controller is an API controller
    [Route("api/[controller]")] // attribute to set the route for this controller to 'api/DoctorSearchApi'
    public class DoctorSearchApiController : ControllerBase
    {
        // create a static list of DoctorSearchResult objects with pre-defined data
        private static readonly List<DoctorSearchResult> _doctorsAndClinics = new List<DoctorSearchResult>
        {
            new DoctorSearchResult { Name = "Dr. John Smith", City = "New York" },
            new DoctorSearchResult { Name = "Clinic ABC", City = "Los Angeles" },
            new DoctorSearchResult { Name = "Dr. Jane Doe", City = "San Francisco" },
            new DoctorSearchResult { Name = "Healthy Living Clinic", City = "Boston" },
            new DoctorSearchResult { Name = "Family Care Physicians", City = "Houston" },
            new DoctorSearchResult { Name = "Dr. Smith's Office", City = "New York" },
            new DoctorSearchResult { Name = "Heart Health Clinic", City = "Chicago" },
            new DoctorSearchResult { Name = "Allergy & Asthma Center", City = "Houston" },
            new DoctorSearchResult { Name = "Dental Care Associates", City = "Los Angeles" },
            new DoctorSearchResult { Name = "Orthopedic Associates", City = "Seattle" }
        };

        // HTTP GET action with optional parameters for doctor or clinic name and city
        [HttpGet]
        [EnableCors("AllowAllOrigins")] // attribute to allow CORS for any origin
        public ActionResult<IEnumerable<DoctorSearchResult>> Search(string doctorOrClinicName = "", string city = "")
        {
            // filter the list of doctors and clinics based on the provided parameters
            var results = _doctorsAndClinics
                .Where(d => (string.IsNullOrEmpty(doctorOrClinicName) || d.Name.ToLower().Contains(doctorOrClinicName.ToLower()))
                         && (string.IsNullOrEmpty(city) || d.City.ToLower().Contains(city.ToLower())))
                .ToList();

            // return an HTTP OK response with the filtered list of doctors and clinics as the content
            return Ok(results);
        }
    }
}
