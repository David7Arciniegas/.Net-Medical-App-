using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TestApplication.Models;

namespace TestApplication.Controllers
{
    public class SearchController : Controller
    {
        // Ejemplo de lista estática de doctores y clínicas
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
            // Agrega más doctores y clínicas aquí
        };

        public IActionResult Index()
        {
            return View(new DoctorSearchViewModel());
        }

        [HttpPost]
        public IActionResult Search(DoctorSearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Results = _doctorsAndClinics
                    .Where(d => (string.IsNullOrEmpty(model.DoctorOrClinicName) || d.Name.ToLower().Contains(model.DoctorOrClinicName.ToLower()))
                             && (string.IsNullOrEmpty(model.City) || d.City.ToLower().Contains(model.City.ToLower())))
                    .ToList();
            }

            return View("Index", model);
        }
    }
}
