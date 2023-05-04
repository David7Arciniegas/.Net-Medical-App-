using System.Collections.Generic;

namespace TestApplication.Models  
{  
    public class DoctorSearchViewModel  
    {  
        public string? DoctorOrClinicName { get; set; }  
        public string? City { get; set; }  
        public List<DoctorSearchResult>? Results { get; set; } = new List<DoctorSearchResult>();  
    }  
}

namespace TestApplication.Models  
{  
    public class DoctorSearchResult  
    {  
        public string Name { get; set; } = string.Empty;  
        public string City { get; set; } = string.Empty;  
    }  
}
