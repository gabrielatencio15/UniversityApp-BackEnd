using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace UniversityApp_BackEnd.Models
{
    public class Students
    {
        [Key]
        public int idStudent { get; set; }

        [Required]
        public int idIdentificationType { get; set; }

        [Required]
        public string identificationID { get; set; }

        [Required]
        public string nameStudent { get; set; }

        public string secondNameStudent { get; set; }

        [Required]
        public string lastNameStudent { get; set; }

        public string secondLastNameStudent { get; set; }

        [Required]
        public int genderStudent { get; set; }

        [Required]
        public DateTime birthDate { get; set; }

        public Boolean activeStudent { get; set; }

    }

}
