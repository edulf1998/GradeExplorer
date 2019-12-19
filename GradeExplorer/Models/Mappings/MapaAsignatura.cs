using FluentNHibernate.Mapping;

namespace GradeExplorer.Models.Mappings
{
  public class MapaAsignatura : ClassMap<Asignatura>
  {
    public MapaAsignatura()
    {
      Table("Asignatura");
      Id(a => a.Id);
      Map(a => a.Nombre);

      References(a => a.Profesor)
        .Cascade
        .All();  // Una asignatura tiene un profesor

      HasManyToMany(a => a.Alumnos)
        .Table("MatriculaAsignatura")
        .Cascade
        .All(); // Una asignatura tiene muchos alumnos

      HasMany(a => a.Ejercicios)
        .Cascade
        .All(); // Una asignatura tiene muchos ejercicios
    }
  }
}
