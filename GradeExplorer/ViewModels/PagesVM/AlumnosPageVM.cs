using GradeExplorer.Models;
using GradeExplorer.Utils;
using GradeExplorer.Views.Windows;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
      ventana.ShowDialog();

      // Vaciar lista y volver a obtener los datos
      _listaAlumnos.Clear();
      Task.Factory.StartNew(() => ObtenerAlumnos());
    }

    private void EditAlumno()
    {
      var ventana = new VentanaAlumnos(AlumnoSeleccionado);
      ventana.ShowDialog();

      // Vaciar lista y volver a obtener los datos
      _listaAlumnos.Clear();
      Task.Factory.StartNew(() => ObtenerAlumnos());
    }

    private void DeleteAlumno()
    {
      MessageBoxResult dialogResult = MessageBox.Show("¡Esta operación no se puede deshacer!", "¿Borrar alumno?", MessageBoxButton.YesNo);
      if (dialogResult == MessageBoxResult.Yes)
      {
        using (var c = new SchoolContext())
        {
          c.Entry(AlumnoSeleccionado).State = EntityState.Deleted;
          c.SaveChanges();
        }

        // Vaciar lista y volver a obtener los datos
        _listaAlumnos.Clear();
        Task.Factory.StartNew(() => ObtenerAlumnos());
      }
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
      using (var c = new SchoolContext())
      {
        foreach (Alumno a in c.Alumnos)
        {
          Application.Current.Dispatcher.BeginInvoke(new Action(() =>
          {
            ListaAlumnos.Add(a);
          }), DispatcherPriority.Background);
        }
      }
      IsLoading = false;
    }
  }
}
