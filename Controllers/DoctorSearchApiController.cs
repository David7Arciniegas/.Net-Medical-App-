using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using TestApplication.Models;

namespace TestApplication.Controllers
{
    [ApiController] // Marks the class as an API controller
    [Route("api/[controller]")] // Defines the route for the controller
    public class DoctorSearchApiController : ControllerBase
    {
        // Example of a static list of doctors and clinics
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

            // Add more doctors and clinics here
        };

        [HttpGet] // Specifies that this method handles HTTP GET requests
        [EnableCors("AllowAllOrigins")] // Enables Cross-Origin Resource Sharing (CORS)
        public ActionResult<IEnumerable<DoctorSearchResult>> Search(string doctorOrClinicName, string city)
        {
            // Filters the list of doctors and clinics based on the provided parameters
            var results = _doctorsAndClinics
                .Where(d => (string.IsNullOrEmpty(doctorOrClinicName) || d.Name.Contains(doctorOrClinicName))
                         && (string.IsNullOrEmpty(city) || d.City.Contains(city)))
                .ToList();

            return Ok(results); // Returns a 200 OK response with the filtered results
        }
    }
}
