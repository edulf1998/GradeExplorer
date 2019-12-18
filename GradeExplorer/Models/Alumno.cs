using GradeExplorer.Utils;
using System.Collections.Generic;

namespace GradeExplorer.Models
{
  public class Alumno : INotifyBase
  {
    private int _id;
    public int Id
    {
      get => _id;
      set => SetField(ref _id, value);
    }

    public string _nombre;
    public string Nombre
    {
      get => _nombre;
      set => SetField(ref _nombre, value);
    }

    public string _apellido1;
    public string Apellido1
    {
      get => _apellido1;
      set => SetField(ref _apellido1, value);
    }

    public string _apellido2;
    public string Apellido2
    {
      get => _apellido2;
      set => SetField(ref _apellido2, value);
    }

    // Relaciones
    private IList<Asignatura> _asignaturas;
    public IList<Asignatura> Asignaturas
    {
      get => _asignaturas;
      set => SetField(ref _asignaturas, value);
    }

    private IList<Nota> _notas;
    public IList<Nota> Notas
    {
      get => _notas;
      set => SetField(ref _notas, value);
    }
  }
}
