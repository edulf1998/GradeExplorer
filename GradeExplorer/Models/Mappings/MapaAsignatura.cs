using FluentNHibernate.Mapping;

namespace GradeExplorer.Models.Mappings
{
  class MapaAsignatura : ClassMap<Asignatura>
  {
    public MapaAsignatura()
    {
      Id(a => a.Id);
      Map(a => a.Nombre);
      HasOne(a => a.Profesor);
    }
  }
}
