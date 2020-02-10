using GradeExplorer.Utils;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradeExplorer.Models
{
  /// <summary>
  /// Clase de modelo asociada a la tabla "Asignatura" 
  /// de la base de datos.
  /// </summary>
  [Table("Asignaturas")]
  public class Asignatura : ModelBase
  {

    private int _id;
    /// <summary>
    /// ID único de la Asignatura.
    /// </summary>
    [Key]
    public int Id
    {
      get => _id;
      set => SetField(ref _id, value);
    }

    private string _nombre;

    /// <summary>
    /// Nombre de la Asignatura.
    /// </summary>
    public virtual string Nombre
    {
      get => _nombre;
      set => SetField(ref _nombre, value);
    }

    // Relaciones

    private Profesor _profesor;

    /// <summary>
    /// Profesor que imparte esta Asignatura
    /// </summary>
    public virtual Profesor Profesor
    {
      get => _profesor;
      set => SetField(ref _profesor, value);
    }

    private IList<Alumno> _alumnos;
    /// <summary>
    /// Listado de Alumnos que cursan esta Asignatura
    /// </summary>
    public virtual IList<Alumno> Alumnos
    {
      get => _alumnos;
      set => SetField(ref _alumnos, value);
    }

    private IList<Ejercicio> _ejercicios;
    /// <summary>
    /// Listado de Ejercicios propuestos para esta Asignatura.
    /// </summary>
    public virtual IList<Ejercicio> Ejercicios
    {
      get => _ejercicios;
      set => SetField(ref _ejercicios, value);
    }
    
    /// <summary>
    /// Constructor por defecto.
    /// </summary>
    public Asignatura()
    {
      _ejercicios = new List<Ejercicio>();
      _alumnos = new List<Alumno>();
    }
  }
}