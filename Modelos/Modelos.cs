using System.ComponentModel.DataAnnotations;

namespace WebApplicationRazor.Modelos
{
    public class Curso
    {
        /// <summary>
        /// [key] es el decorador que le indica a EF que esta propiedad es de tipo 
        /// llave primaria y autoincrementable
        /// [required] Le indica a EF que es una propiedad requerida
        /// [display] Le Indica a EF que es una propiedad en la cual el texto entre comillas se mostrara
        /// en el html
        /// </summary>
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre del Curso")]
        public string NombreCurso { get; set; } = "";
        [Display(Name = "Cantidad de Clases")]
        public int CantidadClases { get; set; }
        public int Precio { get; set; }
        [Display(Name = "Fecha de Creación")]
        public DateTime FechaCreacion { get; set; }
    }

}
