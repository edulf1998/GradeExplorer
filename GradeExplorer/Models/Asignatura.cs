using System.Collections.Generic;

namespace GradeExplorer.Models
{
  public class Asignatura
  {
    public int Id { get; set; }
    public string Nombre { get; set; }
    public Profesor Profesor { get; set; }
    public IList<Ejercicio> Ejercicios { get; set; }
  }
}
