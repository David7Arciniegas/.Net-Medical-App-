// Controllers/SearchController.cs  
  
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
                    .Where(d => (string.IsNullOrEmpty(model.DoctorOrClinicName) || d.Name.Contains(model.DoctorOrClinicName))  
                             && (string.IsNullOrEmpty(model.City) || d.City.Contains(model.City)))  
                    .ToList();  
            }  
  
            return View("Index", model);  
        }  
    }  
}  
