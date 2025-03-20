using System.ComponentModel.DataAnnotations;

namespace PruebaImagineApps.Models
{
    public class SolicitudRecurso
    {
        [Required]
        [DataType(DataType.Text)]
        public string NombreSolicitante { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Departamento { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string TipoRecurso { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime FechaRequerimiento { get; set; }
    }
}
