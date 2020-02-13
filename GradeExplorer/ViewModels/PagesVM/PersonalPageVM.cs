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
  public class PersonalPageVM : ModelBase
  {
    private ObservableCollection<Profesor> _profesores;
    public ObservableCollection<Profesor> Profesores
    {
      get => _profesores;
      set => SetField(ref _profesores, value);
    }

    private bool _isLoading = true;
    public bool IsLoading
    {
      get => _isLoading;
      set => SetField(ref _isLoading, value);
    }

    public Profesor ProfesorSeleccionado { get; set; }

    public RelayCommand AddCommand { get; set; }
    public RelayCommand EditCommand { get; set; }
    public RelayCommand DeleteCommand { get; set; }

    public PersonalPageVM()
    {
      Task.Factory.StartNew(() => ObtenerPersonal());
      _profesores = new ObservableCollection<Profesor>();

      AddCommand = new RelayCommand((a) => AddProfesor());
      EditCommand = new RelayCommand((a) => EditProfesor(), (a) => CanEdit());
      DeleteCommand = new RelayCommand((a) => DeleteProfesor(), (a) => CanDelete());
    }

    private void AddProfesor()
    {
      var ventana = new VentanaPersonal();
      ventana.ShowDialog();

      // Vaciar lista y volver a obtener los datos
      _profesores.Clear();
      Task.Factory.StartNew(() => ObtenerPersonal());
    }

    private void EditProfesor()
    {
      var ventana = new VentanaPersonal(ProfesorSeleccionado);
      ventana.ShowDialog();

      // Vaciar lista y volver a obtener los datos
      _profesores.Clear();
      Task.Factory.StartNew(() => ObtenerPersonal());
    }

    private void DeleteProfesor()
    {
      MessageBoxResult dialogResult = MessageBox.Show("¡Esta operación no se puede deshacer!", "¿Borrar alumno?", MessageBoxButton.YesNo);
      if (dialogResult == MessageBoxResult.Yes)
      {
        using (var c = new SchoolContext())
        {
          c.Entry(ProfesorSeleccionado).State = EntityState.Deleted;
          c.SaveChanges();
        }

        // Vaciar lista y volver a obtener los datos
        _profesores.Clear();
        Task.Factory.StartNew(() => ObtenerPersonal());
      }
    }

    private bool CanEdit()
    {
      return ProfesorSeleccionado != null;
    }

    private bool CanDelete()
    {
      return ProfesorSeleccionado != null;
    }

    private void ObtenerPersonal()
    {
      IsLoading = true;
      using (var c = new SchoolContext())
      {
        foreach (Profesor p in c.Profesores)
        {
          Application.Current.Dispatcher.BeginInvoke(new Action(() =>
          {
            Profesores.Add(p);
          }), DispatcherPriority.Background);
        }
      }
      IsLoading = false;
    }
  }
}
