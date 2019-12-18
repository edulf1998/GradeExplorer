using System.Collections.Generic;

namespace GradeExplorer.Models
{
  public class Profesor
  {
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido1 { get; set; }
    public string Apellido2 { get; set; }

    public IList<Asignatura> Asignaturas { get; set; }
  }
}
