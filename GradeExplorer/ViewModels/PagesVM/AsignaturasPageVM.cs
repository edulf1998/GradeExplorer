using GradeExplorer.Models;
using GradeExplorer.Utils;
using System;
using System.Collections.ObjectModel;
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
        foreach (Asignatura a in c.Asignatura)
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

    }

    private void AddAsignatura()
    {

    }
  }
}
