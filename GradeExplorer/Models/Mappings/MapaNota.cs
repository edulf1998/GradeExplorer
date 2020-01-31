using FluentNHibernate.Mapping;

namespace GradeExplorer.Models.Mappings
{
  public class MapaNota : ClassMap<Nota>
  {
    public MapaNota()
    {
      Table("NotaEjercicio");

      CompositeId()
      .KeyReference(n => n.Alumno)
      .KeyReference(n => n.Ejercicio); // La clave primaria es compuesta, y relaciona un Ejercicio con un Alumno

      Map(n => n.Puntuacion);

      // Además de ser clave primaria, las dos propiedades son, asimismo, referencias
      References(n => n.Alumno)
        .Cascade
        .All();

      References(n => n.Ejercicio)
        .Cascade
        .All();
    }
  }
}
