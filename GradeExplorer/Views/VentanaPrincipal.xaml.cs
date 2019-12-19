using GradeExplorer.Models;
using GradeExplorer.Utils;
using System.Windows;

namespace GradeExplorer.Views
{
  /// <summary>
  /// Lógica de interacción para VentanaPrincipal.xaml
  /// </summary>
  public partial class VentanaPrincipal : Window
  {
    public VentanaPrincipal()
    {
      InitializeComponent();

      using (var sessionFactory = NHibernateUtil.GetSessionFactory())
      {
        using (var session = sessionFactory.OpenSession())
        {
          using (var transaction = session.BeginTransaction())
          {
            Alumno a1 = new Alumno() { Nombre = "Pedro", Apellido1 = "Pérez", Apellido2 = "Sáez" };
            Alumno a2 = new Alumno() { Nombre = "Marcos", Apellido1 = "Pousa", Apellido2 = "Martínez" };
            Alumno a3 = new Alumno() { Nombre = "Ezequiel", Apellido1 = "Céspedes", Apellido2 = "Pozo" };
            Alumno a4 = new Alumno() { Nombre = "Max", Apellido1 = "Alcabú", Apellido2 = "Gisbert" };

            Profesor p1 = new Profesor() { Nombre = "Lucas", Apellido1 = "García", Apellido2 = "Mina" };
            Profesor p2 = new Profesor() { Nombre = "Evangelina", Apellido1 = "Sánchez", Apellido2 = "Sarmiento" };
            Profesor p3 = new Profesor() { Nombre = "Miguel", Apellido1 = "Escribano", Apellido2 = "Murillo" };

            Asignatura aS1 = new Asignatura() { Nombre = "Lengua Castellana y Literatura", Profesor = p1 };
            aS1.Alumnos.Add(a1);
            aS1.Alumnos.Add(a3);
            aS1.Alumnos.Add(a4);

            Asignatura aS4 = new Asignatura() { Nombre = "Latín", Profesor = p1 };
            aS4.Alumnos.Add(a2);
            aS4.Alumnos.Add(a3);

            Asignatura aS5 = new Asignatura() { Nombre = "Griego", Profesor = p1 };
            aS5.Alumnos.Add(a1);
            aS5.Alumnos.Add(a2);
            aS5.Alumnos.Add(a3);

            Asignatura aS2 = new Asignatura() { Nombre = "Inglés", Profesor = p2 };
            aS2.Alumnos.Add(a1);
            aS2.Alumnos.Add(a2);
            aS2.Alumnos.Add(a3);
            aS2.Alumnos.Add(a4);

            Asignatura aS3 = new Asignatura() { Nombre = "Historia de España", Profesor = p3 };
            aS3.Alumnos.Add(a1);
            aS3.Alumnos.Add(a2);
            aS3.Alumnos.Add(a3);
            aS3.Alumnos.Add(a4);

            session.SaveOrUpdate(a1);
            session.SaveOrUpdate(a2);
            session.SaveOrUpdate(a3);
            session.SaveOrUpdate(a4);

            session.SaveOrUpdate(p1);
            session.SaveOrUpdate(p2);
            session.SaveOrUpdate(p3);

            session.SaveOrUpdate(aS1);
            session.SaveOrUpdate(aS2);
            session.SaveOrUpdate(aS3);
            session.SaveOrUpdate(aS4);
            session.SaveOrUpdate(aS5);

            transaction.Commit();
          }
        }
      }
    }
  }
}
