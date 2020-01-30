using GradeExplorer.Models;
using GradeExplorer.Utils;
using NUnit.Framework;

namespace GradeExplorer.Tests
{
  /// <summary>
  /// Test para comprobar las funciones CRUD de la base de datos.
  /// EL PROBLEMA DE ESTOS TEST ES QUE LEEN LA BASE DE DATOS DESDE CACHÉ.
  /// CADA VEZ QUE SE QUIERAN EJECUTAR HAY QUE CERRAR Y ABRIR EL NUNIT.
  /// </summary>
  [TestFixture]
  public class TestNHibernateUtil
  {
    /// <summary>
    /// Test para añadir un Alumno a la base de datos
    /// </summary>
    [Test]
    public void TestAddAlumno()
    {
      using (var factory = NHibernateUtil.GetSessionFactory())
      {
        using (var session = factory.OpenSession())
        {
          using (var transaction = session.BeginTransaction())
          {
            Alumno a = new Alumno() { Nombre = "__TEST__", Apellido1 = "__APELLIDO1__", Apellido2 = "__APELLIDO2__" };
            session.Persist(a);
            transaction.Commit();
          }
        }
      }
    }

    /// <summary>
    /// Test para recuperar el objeto Alumno de la Base de Datos
    /// </summary>
    [Test]
    public void TestGetAlumno()
    {
      using (var factory = NHibernateUtil.GetSessionFactory())
      {
        using (var session = factory.OpenSession())
        {
          var query = session.CreateQuery("FROM Alumno a WHERE a.Nombre = :test");
          query.SetString("test", "__TEST__");

          Alumno a = query.UniqueResult() as Alumno;
          Assert.IsNotNull(a); // Si es null, el test falla.
        }
      }
    }

    /// <summary>
    /// Test para eliminar el objeto de la Base de Datos
    /// </summary>
    [Test]
    public void TestDeleteAlumno()
    {
      using (var factory = NHibernateUtil.GetSessionFactory())
      {
        using (var session = factory.OpenSession())
        {
          using (var transaction = session.BeginTransaction())
          {
            var query = session.CreateQuery("FROM Alumno a WHERE a.Nombre = :test");
            query.SetString("test", "__TEST__");
            Alumno a = query.UniqueResult() as Alumno;
            if (a != null)
            {
              session.Delete(a);
              transaction.Commit();
            }
          }
        }
      }
    }
  }
}
