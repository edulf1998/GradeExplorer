using GradeExplorer.Models;
using GradeExplorer.Utils;
using NUnit.Framework;
using System.Data.Entity.Migrations;
using System.Linq;

namespace GradeExplorer.Tests
{
  [TestFixture]
  public class SchoolContextTest
  {
    [Test]
    public void Test000AddAlumno()
    {
      using (var c = new SchoolContext())
      {
        Alumno a = new Alumno() { Nombre = "TEST_____", Apellido1 = "TEST" };
        c.Alumnos.Add(a);
        c.SaveChanges();
      }
    }

    [Test]
    public void Test001EditAlumno()
    {
      using (var c = new SchoolContext())
      {
        Alumno a = c.Alumnos.Where((al) => al.Nombre == "TEST_____").SingleOrDefault();
        Assert.NotNull(a);
        a.Apellido2 = "TEST";
        c.SaveChanges();
      }
    }

    [Test]
    public void Test002DeleteAlumno()
    {
      using (var c = new SchoolContext())
      {
        Alumno a = c.Alumnos.Where((al) => al.Nombre == "TEST_____").SingleOrDefault();
        Assert.NotNull(a);
        c.Alumnos.Remove(a);
        c.SaveChanges();
      }
    }
  }
}
