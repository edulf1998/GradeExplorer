using GradeExplorer.Utils;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradeExplorer.Models
{
  /// <summary>
  /// Clase de modelo asociada a la tabla "Nota" 
  /// de la base de datos. Representa una entidad debil, por lo que 
  /// no posee identificadores únicos.
  /// </summary>
  [Table("Notas")]
  public class Nota : ModelBase
  {
    private int _id;
    /// <summary>
    /// Id de la Nota
    /// </summary>
    [Key]
    public int Id
    {
      get => _id;
      set => SetField(ref _id, value);
    }

    private float _puntuacion;
    /// <summary>
    /// Puntuación obtenida por el Alumno que ha realizado el Ejercicio.
    /// </summary>
    [Column("Puntuacion")]
    public float Puntuacion
    {
      get => _puntuacion;
      set => SetField(ref _puntuacion, value);
    }

    // Relaciones

    /// <summary>
    /// Alumno autor del ejercicio
    /// </summary>
    private Alumno _alumno;
    [InverseProperty("Notas")]
    public virtual Alumno Alumno
    {
      get => _alumno;
      set => SetField(ref _alumno, value);
    }

    private Ejercicio _ejercicio;
    /// <summary>
    /// Ejercicio al que esta nota está asociada.
    /// </summary>
    [InverseProperty("Notas")]
    public virtual Ejercicio Ejercicio
    {
      get => _ejercicio;
      set => SetField(ref _ejercicio, value);
    }

    // Debe sobreescribir Equals y GetHashCode
    public override bool Equals(object obj)
    {
      return obj is Nota nota &&
             EqualityComparer<Alumno>.Default.Equals(Alumno, nota.Alumno) &&
             EqualityComparer<Ejercicio>.Default.Equals(Ejercicio, nota.Ejercicio);
    }

    public override int GetHashCode()
    {
      var hashCode = -211400617;
      hashCode = hashCode * -1521134295 + EqualityComparer<Alumno>.Default.GetHashCode(Alumno);
      hashCode = hashCode * -1521134295 + EqualityComparer<Ejercicio>.Default.GetHashCode(Ejercicio);
      return hashCode;
    }
  }
}
