using System.ComponentModel.DataAnnotations;

namespace RKTechnologyTask.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public DateTime DOB { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public List<string> HobbiesList { get; set; }
        public string Gender { get; set; }

    }
}
