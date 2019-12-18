using FluentNHibernate.Mapping;

namespace GradeExplorer.Models.Mappings
{
  class MapaEjercicio : ClassMap<Ejercicio>
  {
    public MapaEjercicio()
    {
      Id(e => e.Id);
      Map(e => e.FechaLimite);
      References(e => e.Asignatura);
    }
  }
}
