using GradeExplorer.Models;
using GradeExplorer.Utils;
using System;
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
            Alumno a = new Alumno() { Nombre = "Pedro", Apellido1 = "Pérez", Apellido2 = "Fernández" };

            Asignatura aS = new Asignatura() { Nombre = "LENGUA CASTELLANA Y LITERATURA" };
            aS.Alumnos.Add(a);

            Ejercicio e = new Ejercicio() { Descripcion = "Examen 1ª Evaluación - Lengua", FechaLimite = DateTime.UtcNow, Asignatura = aS };

            session.SaveOrUpdate(a);
            session.SaveOrUpdate(aS);
            session.SaveOrUpdate(e);

            transaction.Commit();
          }
        }
      }
    }
  }
}
