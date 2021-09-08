﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.ViewModel
{
    public class RegisterVM
    {
        //private const string Pattern = @"^(?=.[A-Z])(?=.[a-z])(?=.*[0-9])$";
        [Required]
        public string NIK { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public enum Gender
        {
            Male,
            Female
        }
        [Required]
        public Gender gender { get; set; }
        public int Salary { get; set; }
        [Required]
        public string Email { get; set; }
        //[PasswordPropertyText]
        [Required]
        //[RegularExpression(Pattern, ErrorMessage = "Masukkan Password yang Benar")]
        //[StringLength(16, ErrorMessage = "Password Minimal 5 hingga 16 karakter", MinimumLength = 5)]
        public string Password { get; set; }
        public string Degree { get; set; }
        public string GPA { get; set; }
    }
}
