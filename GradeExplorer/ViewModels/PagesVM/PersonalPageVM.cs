using GradeExplorer.Models;
using GradeExplorer.Utils;
using System;
using System.Collections.ObjectModel;
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
      
    }

    private void EditProfesor()
    {

    }

    private void DeleteProfesor()
    {

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
      using (var session = NHibernateUtil.GetSessionFactory().OpenSession())
      {
        var profesores = session.CreateQuery("from Profesor p").List<Profesor>();
        foreach (Profesor p in profesores)
        {
          Application.Current.Dispatcher.BeginInvoke(new Action(() =>
          {
            _profesores.Add(p);
          }), DispatcherPriority.Background);
        }
      }
      IsLoading = false;
    }
  }
}
