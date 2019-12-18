using FluentNHibernate.Mapping;

namespace GradeExplorer.Models.Mappings
{
  class MapaAlumno : ClassMap<Alumno>
  {
    public MapaAlumno()
    {
      Id(x => x.Id);
      Map(x => x.Nombre).Length(50).Not.Nullable();
      Map(x => x.Apellido1).Length(50).Not.Nullable();
      Map(x => x.Apellido2).Length(50).Not.Nullable();
      HasMany(x => x.Asignaturas).Table("MatriculaAlumno");
    }
  }
}