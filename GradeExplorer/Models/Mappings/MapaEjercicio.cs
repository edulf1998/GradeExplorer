using FluentNHibernate.Mapping;

namespace GradeExplorer.Models.Mappings
{
  public class MapaEjercicio : ClassMap<Ejercicio>
  {
    public MapaEjercicio()
    {
      Table("Ejercicio");
      Id(e => e.Id);
      Map(e => e.Descripcion);
      Map(e => e.FechaLimite);

      HasMany(e => e.Notas)
        .Cascade
        .All(); // Un ejercicio tiene muchas notas
    }
  }
}
