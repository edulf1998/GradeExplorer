using FluentNHibernate.Mapping;

namespace GradeExplorer.Models.Mappings
{
  public class MapaAlumno : ClassMap<Alumno>
  {
    public MapaAlumno()
    {
      Table("Alumno");
      Id(a => a.Id);
      Map(a => a.Nombre);
      Map(a => a.Apellido1);
      Map(a => a.Apellido2);

      HasManyToMany(a => a.Asignaturas).Table("MatriculaAsignatura");
    }
  }
}
