using GradeExplorer.Utils;
using System.Collections.Generic;

namespace GradeExplorer.Models
{
  public class Profesor : INotifyBase
  {
    private int _id;
    public virtual int Id
    {
      get => _id;
      set => SetField(ref _id, value);
    }

    private int _nombre;
    public virtual int Nombre
    {
      get => _nombre;
      set => SetField(ref _nombre, value);
    }

    private int _apellido1;
    public virtual int Apellido1
    {
      get => _apellido1;
      set => SetField(ref _apellido1, value);
    }

    private int _apellido2;
    public virtual int Apellido2
    {
      get => _apellido2;
      set => SetField(ref _apellido2, value);
    }

    // Relaciones
    private IList<Asignatura> _asignaturas;
    public virtual IList<Asignatura> Asignaturas
    {
      get => _asignaturas;
      set => SetField(ref _asignaturas, value);
    }

    public Profesor()
    {
      _asignaturas = new List<Asignatura>();
    }
  }
}
