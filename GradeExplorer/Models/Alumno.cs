using GradeExplorer.Utils;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradeExplorer.Models
{
  /// <summary>
  /// Clase de modelo asociada a la tabla "Alumno" 
  /// de la base de datos.
  /// </summary>
  [Table("Alumnos")]
  public class Alumno : ModelBase
  {
    /// <summary>
    /// ID único de cada Alumno
    /// </summary>
    private int _id;

    [Key]
    public int Id
    {
      get => _id;
      set => SetField(ref _id, value);
    }

    /// <summary>
    /// Nombre del Alumno.
    /// </summary>
    private string _nombre;

    [Column("Nombre")]
    public string Nombre
    {
      get => _nombre;
      set => SetField(ref _nombre, value);
    }

    /// <summary>
    /// Primer apellido del Alumno.
    /// </summary>
    private string _apellido1;

    [Column("Apellido1")]
    public string Apellido1
    {
      get => _apellido1;
      set => SetField(ref _apellido1, value);
    }

    /// <summary>
    /// Segundo apellido del Alumno.
    /// </summary>
    private string _apellido2;

    [Column("Apellido2")]
    public string Apellido2
    {
      get => _apellido2;
      set => SetField(ref _apellido2, value);
    }

    // Relaciones

    /// <summary>
    /// Listado de Asignaturas que cursa el Alumno.
    /// </summary>
    private IList<Asignatura> _asignaturas;
    public virtual IList<Asignatura> Asignaturas
    {
      get => _asignaturas;
      set => SetField(ref _asignaturas, value);
    }

    /// <summary>
    /// Notas asociadas a este Alumno.
    /// </summary>
    private IList<Nota> _notas;
    public virtual IList<Nota> Notas
    {
      get => _notas;
      set => SetField(ref _notas, value);
    }

    public Alumno()
    {
      _notas = new List<Nota>();
      _asignaturas = new List<Asignatura>();
    }
  }
}
