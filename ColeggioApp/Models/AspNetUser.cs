using ColegioApp.Datos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

#nullable disable

namespace ColegioApp.Models
{
    public partial class AspNetUser

    {
     

        public AspNetUser()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaim>();
            AspNetUserLogins = new HashSet<AspNetUserLogin>();
            AspNetUserRoles = new HashSet<AspNetUserRole>();
            AspNetUserTokens = new HashSet<AspNetUserToken>();
            Estudiantes = new HashSet<Estudiante>();
            Profesors = new HashSet<Profesor>();
        }

        [Key]
        public string Id { get; set; }
        public string UserName { get; set; }
         public string NormalizedUserName { get; set; }

        [Required(ErrorMessage = "Email Obligatorio")]
        [EmailAddress]
        [Remote(action: "ComprobarEmail", controller: "Registro")]
        public string Email { get; set; }
         public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }

        [Required(ErrorMessage = "Contraseña Obligatoria")]
        [Display(Name = " Contraseña")]
        [DataType(DataType.Password)]
         public string PasswordHash { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Repetir Contraseña")]
        [Compare("PasswordHash", ErrorMessage = "No coinciden los campos de la contraseña")]
        public string PasswordValidar { get; set; }
         public string SecurityStamp { get; set; }
         public string ConcurrencyStamp { get; set; }
         public string PhoneNumber { get; set; }
         public bool PhoneNumberConfirmed { get; set; }
         public bool TwoFactorEnabled { get; set; }
         public DateTimeOffset? LockoutEnd { get; set; }
         public bool LockoutEnabled { get; set; }
         public int AccessFailedCount { get; set; }
        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public int Edad { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public int Identificacion { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [NotMapped]
        public string Especialidad { get; set; }

        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
        public virtual ICollection<Profesor> Profesors { get; set; }


       
    }
}
