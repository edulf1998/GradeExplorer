using FluentNHibernate.Mapping;

namespace GradeExplorer.Models.Mappings
{
  public class MapaProfesor : ClassMap<Profesor>
  {
    public MapaProfesor()
    {
      Table("Profesor");
      Id(p => p.Id);
      Map(p => p.Nombre);
      Map(p => p.Apellido1);
      Map(p => p.Apellido2);

      HasMany(p => p.Asignaturas)
        .Cascade
        .All(); // Un profesor imparte muchas asignaturas
    }
  }
}
