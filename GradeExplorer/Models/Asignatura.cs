using GradeExplorer.Utils;
using System.Collections.Generic;

namespace GradeExplorer.Models
{
  public class Asignatura : INotifyBase
  {
    private int _id;
    public int Id
    {
      get => _id;
      set => SetField(ref _id, value);
    }

    private int _nombre;
    public int Nombre
    {
      get => _nombre;
      set => SetField(ref _nombre, value);
    }

    // Relaciones
    private Profesor _profesor;
    public Profesor Profesor
    {
      get => _profesor;
      set => SetField(ref _profesor, value);
    }

    private IList<Alumno> _alumnos;
    public IList<Alumno> Alumnos
    {
      get => _alumnos;
      set => SetField(ref _alumnos, value);
    }

    private IList<Ejercicio> _ejercicios;
    public IList<Ejercicio> Ejercicios
    {
      get => _ejercicios;
      set => SetField(ref _ejercicios, value);
    }

    /*
    private IList<Nota> _notas;
    public IList<Nota> Notas
    {
      get => _notas;
      set => SetField(ref _notas, value);
    }
    */
  }
}