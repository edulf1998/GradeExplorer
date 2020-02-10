using GradeExplorer.Models;
using MySql.Data.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;

namespace GradeExplorer.Utils
{
  [DbConfigurationType(typeof(MySqlEFConfiguration))]
  public class SchoolContext : DbContext
  {
    public DbSet<Alumno> Alumnos { get; set; }
    public DbSet<Profesor> Profesores { get; set; }
    public DbSet<Asignatura> Asignatura { get; set; }
    public DbSet<Ejercicio> Ejercicios { get; set; }
    public DbSet<Nota> Notas { get; set; }

    public SchoolContext() : base("name = SchoolContext")
    {
    }

    public static void InsertarDatosDemo()
    {
      using (var context = new SchoolContext())
      {
        List<Alumno> _alumnos = new List<Alumno> {
          new Alumno() { Nombre = "Peter", Apellido1 = "Parker", Apellido2 = "Parker" },
          new Alumno() { Nombre = "Pedro", Apellido1 = "Pérez", Apellido2 = "Fernández" },
          new Alumno() { Nombre = "Marco", Apellido1 = "de la Rosa", Apellido2 = "Martínez" },
        };

        context.Alumnos.AddRange(_alumnos);
        context.SaveChanges();
      }
    }
  }
}
