using GradeExplorer.Utils;
using System.Collections.Generic;

namespace GradeExplorer.Models
{
  public class Asignatura : INotifyBase
  {
    private int _id;
    public virtual int Id
    {
      get => _id;
      set => SetField(ref _id, value);
    }

    private string _nombre;
    public virtual string Nombre
    {
      get => _nombre;
      set => SetField(ref _nombre, value);
    }

    // Relaciones
    private Profesor _profesor;
    public virtual Profesor Profesor
    {
      get => _profesor;
      set => SetField(ref _profesor, value);
    }

    private IList<Alumno> _alumnos;
    public virtual IList<Alumno> Alumnos
    {
      get => _alumnos;
      set => SetField(ref _alumnos, value);
    }

    private IList<Ejercicio> _ejercicios;
    public virtual IList<Ejercicio> Ejercicios
    {
      get => _ejercicios;
      set => SetField(ref _ejercicios, value);
    }

    public Asignatura()
    {
      _ejercicios = new List<Ejercicio>();
      _alumnos = new List<Alumno>();
    }
  }
}