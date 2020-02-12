using GradeExplorer.Utils;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradeExplorer.Models
{
  /// <summary>
  /// Clase de modelo asociada a la tabla "Profesor" 
  /// de la base de datos.
  /// </summary>
  [Table("Profesores")]
  public class Profesor : ModelBase
  {
    private int _id;
    /// <summary>
    /// ID único de cada Profesor
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public virtual int Id
    {
      get => _id;
      set => SetField(ref _id, value);
    }

    private string _nombre;
    /// <summary>
    /// Nombre del Profesor
    /// </summary>
    [Column("Nombre")]
    public virtual string Nombre
    {
      get => _nombre;
      set => SetField(ref _nombre, value);
    }

    private string _apellido1;
    /// <summary>
    /// Primer apellido del Profesor
    /// </summary>
    [Column("Apellido1")]
    public virtual string Apellido1
    {
      get => _apellido1;
      set => SetField(ref _apellido1, value);
    }

    private string _apellido2;
    /// <summary>
    /// Segundo apellido del Profesor
    /// </summary>
    [Column("Apellido2")]
    public virtual string Apellido2
    {
      get => _apellido2;
      set => SetField(ref _apellido2, value);
    }

    // Relaciones

    private IList<Asignatura> _asignaturas;
    /// <summary>
    /// Listado de Asignaturas que el profesor imparte
    /// </summary>
    [InverseProperty("Profesor")]
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
