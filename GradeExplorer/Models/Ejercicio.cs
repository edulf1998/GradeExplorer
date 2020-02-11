using GradeExplorer.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradeExplorer.Models
{
  /// <summary>
  /// Clase de modelo asociada a la tabla "Ejercicio" 
  /// de la base de datos.
  /// </summary>
  public class Ejercicio : ModelBase
  {
    private int _id;
    /// <summary>
    /// ID único del Ejercicio
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public virtual int Id
    {
      get => _id;
      set => SetField(ref _id, value);
    }

    private string _descripcion;
    /// <summary>
    /// Descripción del Ejercicio.
    /// </summary>
    [Column("Desc")]
    public virtual string Descripcion
    {
      get => _descripcion;
      set => SetField(ref _descripcion, value);
    }

    private DateTime _fechaLimite;
    /// <summary>
    /// Fecha límite de entrega del Ejercicio.
    /// </summary>
    [Column("Fecha")]
    public virtual DateTime FechaLimite
    {
      get => _fechaLimite;
      set => SetField(ref _fechaLimite, value);
    }

    // Relaciones

    private Asignatura _asignatura;
    /// <summary>
    /// Asignatura asociada al Ejercicio.
    /// </summary>
    [InverseProperty("Ejercicios")]
    public virtual Asignatura Asignatura
    {
      get => _asignatura;
      set => SetField(ref _asignatura, value);
    }

    private IList<Nota> _notas;
    /// <summary>
    /// Listado de Notas que los Alumnos han obtenido para este Ejercicio.
    /// </summary>
    [InverseProperty("Ejercicio")]
    public virtual IList<Nota> Notas
    {
      get => _notas;
      set => SetField(ref _notas, value);
    }

    public Ejercicio()
    {
      _notas = new List<Nota>();
    }
  }
}
