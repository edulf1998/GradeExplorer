using GradeExplorer.Models;
using MySql.Data.EntityFramework;
using System;
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

    public static void VaciarBaseDatos()
    {
      using (var context = new SchoolContext())
      {
        context.Database.Delete();
        context.Database.CreateIfNotExists();
      }
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

        List<Asignatura> _asignaturas = new List<Asignatura>
        {
          new Asignatura() { Nombre = "Lengua Castellana y Literatura" },
          new Asignatura() { Nombre = "Inglés" },
          new Asignatura() { Nombre = "Latín" },
        };

        List<Profesor> _profesores = new List<Profesor>
        {
          new Profesor() { Nombre = "Charles", Apellido1 = "Xavier"},
          new Profesor() { Nombre = "Profesor", Apellido1 = "Oak"},
        };

        context.Alumnos.AddRange(_alumnos);
        context.Asignatura.AddRange(_asignaturas);
        context.Profesores.AddRange(_profesores);

        context.SaveChanges();
      }
    }
  }
}
