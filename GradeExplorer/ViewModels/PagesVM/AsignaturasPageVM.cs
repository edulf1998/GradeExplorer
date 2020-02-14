using GradeExplorer.Models;
using GradeExplorer.Utils;
using GradeExplorer.Views.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace GradeExplorer.ViewModels.PagesVM
{
  public class AsignaturasPageVM : ModelBase
  {
    private ObservableCollection<Asignatura> _asignaturas;
    public ObservableCollection<Asignatura> ListaAsignaturas
    {
      get => _asignaturas;
      set => SetField(ref _asignaturas, value);
    }

    private bool _isLoading = true;
    public bool IsLoading
    {
      get => _isLoading;
      set => SetField(ref _isLoading, value);
    }

    public Asignatura AsignaturaSeleccionada { get; set; }

    public RelayCommand AddCommand { get; set; }
    public RelayCommand EditCommand { get; set; }
    public RelayCommand DeleteCommand { get; set; }

    public AsignaturasPageVM()
    {
      _asignaturas = new ObservableCollection<Asignatura>();
      AddCommand = new RelayCommand((a) => AddAsignatura());
      EditCommand = new RelayCommand((a) => EditAsignatura(), (a) => CanEditAsignatura());
      DeleteCommand = new RelayCommand((a) => DeleteAsignatura(), (a) => CanDeleteAsignatura());

      Task.Factory.StartNew(() => ObtenerAsignaturas());
    }

    private void ObtenerAsignaturas()
    {
      IsLoading = true;
      using (var c = new SchoolContext())
      {
        var _asignaturas = c.Asignaturas.Include((a) => a.Profesor).Include((a) => a.Alumnos).ToList();
        foreach (Asignatura a in _asignaturas)
        {
          Application.Current.Dispatcher.BeginInvoke(new Action(() =>
          {
            ListaAsignaturas.Add(a);
          }), DispatcherPriority.Background);
        }
      }
      IsLoading = false;
    }

    private void DeleteAsignatura()
    {
      MessageBoxResult dialogResult = MessageBox.Show("¡Esta operación no se puede deshacer!", "¿Borrar alumno?", MessageBoxButton.YesNo);
      if (dialogResult == MessageBoxResult.Yes)
      {
        using (var c = new SchoolContext())
        {
          c.Entry(AsignaturaSeleccionada).State = EntityState.Deleted;
          c.SaveChanges();
        }

        // Vaciar lista y volver a obtener los datos
        _asignaturas.Clear();
        Task.Factory.StartNew(() => ObtenerAsignaturas());
      }
    }

    private bool CanEditAsignatura()
    {
      return AsignaturaSeleccionada != null;
    }

    private bool CanDeleteAsignatura()
    {
      return AsignaturaSeleccionada != null;
    }

    private void EditAsignatura()
    {
      var ventana = new VentanaAsignaturas(AsignaturaSeleccionada);
      ventana.ShowDialog();

      // Vaciar lista y volver a obtener los datos
      _asignaturas.Clear();
      Task.Factory.StartNew(() => ObtenerAsignaturas());
    }

    private void AddAsignatura()
    {
      var ventana = new VentanaAsignaturas();
      ventana.ShowDialog();

      // Vaciar lista y volver a obtener los datos
      _asignaturas.Clear();
      Task.Factory.StartNew(() => ObtenerAsignaturas());
    }
  }
}
