using GradeExplorer.Models;
using GradeExplorer.Utils;
using GradeExplorer.Views.Windows;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace GradeExplorer.ViewModels.PagesVM
{
  public class AlumnosPageVM : ModelBase
  {
    private ObservableCollection<Alumno> _listaAlumnos;
    public ObservableCollection<Alumno> ListaAlumnos
    {
      get => _listaAlumnos;
      set => SetField(ref _listaAlumnos, value);
    }

    private bool _isLoading = true;
    public bool IsLoading
    {
      get => _isLoading;
      set => SetField(ref _isLoading, value);
    }

    public Alumno AlumnoSeleccionado { get; set; }

    public RelayCommand AddCommand { get; set; }
    public RelayCommand EditCommand { get; set; }
    public RelayCommand DeleteCommand { get; set; }

    public AlumnosPageVM()
    {
      _listaAlumnos = new ObservableCollection<Alumno>();
      Task.Factory.StartNew(() => ObtenerAlumnos());

      AddCommand = new RelayCommand((a) => AddAlumno());
      EditCommand = new RelayCommand((a) => EditAlumno(), (a) => CanEditAlumno());
      DeleteCommand = new RelayCommand((a) => DeleteAlumno(), (a) => CanDeleteAlumno());
    }

    private void AddAlumno()
    {
      var ventana = new VentanaAlumnos();
      ventana.Show();
    }

    private void EditAlumno()
    {
      var ventana = new VentanaAlumnos(AlumnoSeleccionado);
      ventana.Show();
    }

    private void DeleteAlumno()
    {

    }

    private bool CanEditAlumno()
    {
      return (AlumnoSeleccionado != null);
    }

    private bool CanDeleteAlumno()
    {
      return (AlumnoSeleccionado != null);
    }

    private void ObtenerAlumnos()
    {
      IsLoading = true;
      using (var sessionFactory = NHibernateUtil.GetSessionFactory())
      {
        using (var session = sessionFactory.OpenSession())
        {
          var alumnos = session.CreateQuery("from Alumno a").List<Alumno>();
          foreach (Alumno a in alumnos)
          {
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
              _listaAlumnos.Add(a);
            }), DispatcherPriority.Background);
          }
        }
      }
      IsLoading = false;
    }
  }
}
