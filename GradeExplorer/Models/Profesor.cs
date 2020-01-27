using GradeExplorer.Utils;
using System.Collections.Generic;

namespace GradeExplorer.Models
{
  /// <summary>
  /// Clase de modelo asociada a la tabla "Profesor" 
  /// de la base de datos.
  /// </summary>
  public class Profesor : ModelBase
  {
    /// <summary>
    /// ID único de cada Profesor
    /// </summary>
    private int _id;
    public virtual int Id
    {
      get => _id;
      set => SetField(ref _id, value);
    }

    /// <summary>
    /// Nombre del Profesor
    /// </summary>
    private string _nombre;
    public virtual string Nombre
    {
      get => _nombre;
      set => SetField(ref _nombre, value);
    }

    /// <summary>
    /// Primer apellido del Profesor
    /// </summary>
    private string _apellido1;
    public virtual string Apellido1
    {
      get => _apellido1;
      set => SetField(ref _apellido1, value);
    }

    /// <summary>
    /// Segundo apellido del Profesor
    /// </summary>
    private string _apellido2;
    public virtual string Apellido2
    {
      get => _apellido2;
      set => SetField(ref _apellido2, value);
    }

    // Relaciones

    /// <summary>
    /// Listado de Asignaturas que el profesor imparte
    /// </summary>
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
