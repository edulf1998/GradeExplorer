using GradeExplorer.Models;
using GradeExplorer.Utils;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace GradeExplorer.ViewModels.PagesVM
{
  public class AlumnosPageVM : INotifyBase
  {
    private ObservableCollection<Alumno> _listaAlumnos;
    public ObservableCollection<Alumno> ListaAlumnos
    {
      get => _listaAlumnos;
      set => SetField(ref _listaAlumnos, value);
    }

    private bool isLoading = false;

    public AlumnosPageVM()
    {
      _listaAlumnos = new ObservableCollection<Alumno>();
      Task.Factory.StartNew(() => ObtenerAlumnos());
    }

    private void ObtenerAlumnos()
    {
      isLoading = true;
      using (var sessionFactory = NHibernateUtil.GetSessionFactory())
      {
        using (var session = sessionFactory.OpenSession())
        {
          var alumnos = session.CreateQuery("from Alumno a").List<Alumno>();
          foreach(Alumno a in alumnos)
          {
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
              _listaAlumnos.Add(a);
            }), DispatcherPriority.Background);
          }
        }
      }
      isLoading = false;
    }
  }
}
