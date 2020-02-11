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

    private int _id;
    /// <summary>
    /// ID único de cada Alumno
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id
    {
      get => _id;
      set => SetField(ref _id, value);
    }


    private string _nombre;
    /// <summary>
    /// Nombre del Alumno.
    /// </summary>
    [Column("Nombre")]
    public string Nombre
    {
      get => _nombre;
      set => SetField(ref _nombre, value);
    }

    private string _apellido1;
    /// <summary>
    /// Primer apellido del Alumno.
    /// </summary>
    [Column("Apellido1")]
    public string Apellido1
    {
      get => _apellido1;
      set => SetField(ref _apellido1, value);
    }

    private string _apellido2;
    /// <summary>
    /// Segundo apellido del Alumno.
    /// </summary>
    [Column("Apellido2")]
    public string Apellido2
    {
      get => _apellido2;
      set => SetField(ref _apellido2, value);
    }

    // Relaciones

    private IList<Asignatura> _asignaturas;
    /// <summary>
    /// Listado de Asignaturas que cursa el Alumno.
    /// </summary>
    [InverseProperty("Alumnos")]
    public virtual IList<Asignatura> Asignaturas
    {
      get => _asignaturas;
      set => SetField(ref _asignaturas, value);
    }

    private IList<Nota> _notas;
    /// <summary>
    /// Notas asociadas a este Alumno.
    /// </summary>
    [InverseProperty("Alumno")]
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
