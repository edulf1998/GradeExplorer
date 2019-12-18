using GradeExplorer.Utils;
using System.Collections.Generic;

namespace GradeExplorer.Models
{
  public class Profesor : INotifyBase
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

    private int _apellido1;
    public int Apellido1
    {
      get => _apellido1;
      set => SetField(ref _apellido1, value);
    }

    private int _apellido2;
    public int Apellido2
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

    public Profesor()
    {
    }

    public Profesor(int id)
    {
      _id = id;
    }
  }
}
