using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class Inscripcion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InscripcionID { get; set; }
        public int EstudianteID { get; set; }
        public int CursoID { get; set; }
        public DateTime FechaInscripcion { get; set; }

        public virtual Estudiante ?Estudiante { get; set; }
        public virtual Curso ?Curso { get; set; }
    }
}
