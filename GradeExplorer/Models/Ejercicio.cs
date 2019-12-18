using System;

namespace GradeExplorer.Models
{
  public class Ejercicio
  {
    public int Id { get; set; }
    public Asignatura Asignatura { get; set; }
    public DateTime FechaLimite { get; set; }
  }
}
