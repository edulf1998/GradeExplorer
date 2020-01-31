using GradeExplorer.Models;
using GradeExplorer.Utils;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace GradeExplorer.ViewModels.PagesVM
{
  public class PuntuacionesPageVM : ModelBase
  {
    private ObservableCollection<Alumno> _alumnos;
    public ObservableCollection<Alumno> Alumnos
    {
      get => _alumnos;
      set => SetField(ref _alumnos, value);
    }
    private bool _isLoading = true;
    public bool IsLoading
    {
      get => _isLoading;
      set => SetField(ref _isLoading, value);
    }

    private Alumno _alumnoSeleccionado;
    public Alumno AlumnoSeleccionado
    {
      get => _alumnoSeleccionado;
      set => SetField(ref _alumnoSeleccionado, value);
    }

    private ObservableCollection<Nota> _notas;
    public ObservableCollection<Nota> Notas
    {
      get => _notas;
      set => SetField(ref _notas, value);
    }

    public Nota NotaSeleccionada { get; set; }

    //private RelayCommand AddCommand { get; set; }
    //private RelayCommand EditCommand { get; set; }
    //private RelayCommand DeleteCommand { get; set; }

    public PuntuacionesPageVM()
    {
      _alumnos = new ObservableCollection<Alumno>();

      //AddCommand = new RelayCommand((a) => AddNota());
      //EditCommand = new RelayCommand((a) => EditNota(), (a) => CanEditNota());
      //DeleteCommand = new RelayCommand((a) => DeleteNota(), (a) => CanDeleteNota());

      Task.Factory.StartNew(() => ObtenerAlumnosNotas());
    }

    private void AddNota()
    {

    }

    private bool CanEditNota()
    {
      return NotaSeleccionada != null;
    }

    private bool CanDeleteNota()
    {
      return NotaSeleccionada != null;
    }

    private void EditNota()
    {

    }

    private void DeleteNota()
    {

    }

    private void ObtenerAlumnosNotas()
    {
      IsLoading = true;
      using (var session = NHibernateUtil.GetSessionFactory().OpenSession())
      {
        var alumnos = session.QueryOver<Alumno>().List();
        foreach (Alumno a in alumnos)
        {
          Application.Current.Dispatcher.BeginInvoke(new Action(() =>
          {
            _alumnos.Add(a);
          }), DispatcherPriority.Background);
        }
      }
      IsLoading = false;
    }
  }
}
