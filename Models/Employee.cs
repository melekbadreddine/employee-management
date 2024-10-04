using System;
using System.ComponentModel.DataAnnotations;

namespace VotreNamespace.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom est requis")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Le département est requis")]
        public string Departement { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Le salaire doit être positif")]
        public int Salary { get; set; }
    }
}