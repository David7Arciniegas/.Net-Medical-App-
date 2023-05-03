using System.Collections.Generic;  
  
namespace TestApplication.Models  
{  
    public class DoctorSearchViewModel  
    {  
        public string? DoctorOrClinicName { get; set; }  
        public string? City { get; set; }  
        public List<DoctorSearchResult>? Results { get; set; }  
    }  
}  

namespace TestApplication.Models  
{  
    public class DoctorSearchResult  
    {  
        public string Name { get; set; }  
        public string City { get; set; }  
    }  
}  