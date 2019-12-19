using GradeExplorer.Models;
using GradeExplorer.Utils;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GradeExplorer.ViewModels
{
  public class VentanaPrincipalViewModel
  {
    public ObservableCollection<Alumno> ListaAlumnos { get; set; }
    public Alumno AlumnoSeleccionado { get; set; }

    public VentanaPrincipalViewModel()
    {
      ListaAlumnos = new ObservableCollection<Alumno>();
      ObtenerAlumnos();
    }

    private void ObtenerAlumnos()
    {
      using (var sessionFactory = NHibernateUtil.GetSessionFactory())
      {
        using (var session = sessionFactory.OpenSession())
        {
          List<Alumno> alumnos = session.Query<Alumno>().ToList();
          foreach (Alumno a in alumnos)
          {
            ListaAlumnos.Add(a);
          }
        }
      }
    }
  }
}
