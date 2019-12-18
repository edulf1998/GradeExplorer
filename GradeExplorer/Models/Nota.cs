using GradeExplorer.Utils;

namespace GradeExplorer.Models
{
  public class Nota : INotifyBase
  {
    private float _puntuacion;
    public float Puntuacion
    {
      get => _puntuacion;
      set => SetField(ref _puntuacion, value);
    }

    // Relaciones
    private Alumno _alumno;
    public Alumno Alumno
    {
      get => _alumno;
      set => SetField(ref _alumno, value);
    }

    private Ejercicio _ejercicio;
    public Ejercicio Ejercicio
    {
      get => _ejercicio;
      set => SetField(ref _ejercicio, value);
    }
  }
}
