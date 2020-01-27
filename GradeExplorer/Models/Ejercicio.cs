using GradeExplorer.Utils;
using System;
using System.Collections.Generic;

namespace GradeExplorer.Models
{
  /// <summary>
  /// Clase de modelo asociada a la tabla "Ejercicio" 
  /// de la base de datos.
  /// </summary>
  public class Ejercicio : ModelBase
  {
    /// <summary>
    /// ID único del Ejercicio
    /// </summary>
    private int _id;
    public virtual int Id
    {
      get => _id;
      set => SetField(ref _id, value);
    }

    /// <summary>
    /// Descripción del Ejercicio.
    /// </summary>
    private string _descripcion;
    public virtual string Descripcion
    {
      get => _descripcion;
      set => SetField(ref _descripcion, value);
    }

    /// <summary>
    /// Fecha límite de entrega del Ejercicio.
    /// </summary>
    private DateTime _fechaLimite;
    public virtual DateTime FechaLimite
    {
      get => _fechaLimite;
      set => SetField(ref _fechaLimite, value);
    }

    // Relaciones

    /// <summary>
    /// Asignatura asociada al Ejercicio.
    /// </summary>
    private Asignatura _asignatura;
    public virtual Asignatura Asignatura
    {
      get => _asignatura;
      set => SetField(ref _asignatura, value);
    }

    /// <summary>
    /// Listado de Notas que los Alumnos han obtenido para este Ejercicio.
    /// </summary>
    private IList<Nota> _notas;
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
