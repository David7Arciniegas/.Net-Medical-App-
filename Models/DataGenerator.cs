using System;  
using System.Collections.Generic;  
  
namespace TestApplication.Models  
{  
    public static class DataGenerator  
    {  
        private static readonly Random _random = new Random();  
        private static readonly List<string> _doctorNames = new List<string>  
        {  
            "Dr. John Smith",  
            "Dr. Jane Doe",  
            "Dr. William Brown",  
            "Dr. Emily Johnson"  
        };  
  
        private static readonly List<string> _clinicNames = new List<string>  
        {  
            "City Clinic",  
            "Health Center",  
            "Family Clinic",  
            "Medical Group"  
        };  
  
        private static readonly List<string> _cities = new List<string>  
        {  
            "New York",  
            "Los Angeles",  
            "Chicago",  
            "Houston",  
            "Berlin"  
        };  
  
        public static DoctorSearchViewModel GenerateDoctorSearchViewModel()  
        {  
            return new DoctorSearchViewModel  
            {  
                DoctorOrClinicName = GenerateDoctorOrClinicName(),  
                City = GenerateCity()  
            };  
        }  
  
        private static string GenerateDoctorOrClinicName()  
        {  
            int type = _random.Next(2);  
            if (type == 0)  
            {  
                return _doctorNames[_random.Next(_doctorNames.Count)];  
            }  
            else  
            {  
                return _clinicNames[_random.Next(_clinicNames.Count)];  
            }  
        }  
  
        private static string GenerateCity()  
        {  
            return _cities[_random.Next(_cities.Count)];  
        }  
    }  
}  
