using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyectomvc.Models
{
    [Table("t_personas")]
    public class Formulario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Por favor ingrese Nombre")]
        [Display(Name="Nombre")]
        [Column("Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Por favor ingrese Apellido")]
        [Display(Name="Apellido")]
        [Column("Apellido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Por favor ingrese Distrito")]
        [Display(Name="Distrito")]
        [Column("Distrito")]
        public string Distrito { get; set; }

        [Required(ErrorMessage = "Por favor ingrese Banco")]
        [Display(Name="Banco")]
        [Column("Banco")]
        public string Banco { get; set; }

        [Required(ErrorMessage = "Por favor ingrese Edad")]
        [Display(Name="Edad")]
        [Column("Edad")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "Por favor ingrese Genero")]
        [Display(Name="Genero")]
        [Column("Genero")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "Por favor ingrese Autor")]
        [Display(Name="Autor")]
        [Column("Autor")]
        public string Autor { get; set; }
        
        [NotMapped]
        public string Respuesta { get; set; }
    }
}
