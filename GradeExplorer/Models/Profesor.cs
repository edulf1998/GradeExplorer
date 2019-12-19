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

    private string _nombre;
    public virtual string Nombre
    {
      get => _nombre;
      set => SetField(ref _nombre, value);
    }

    private string _apellido1;
    public virtual string Apellido1
    {
      get => _apellido1;
      set => SetField(ref _apellido1, value);
    }

    private string _apellido2;
    public virtual string Apellido2
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
