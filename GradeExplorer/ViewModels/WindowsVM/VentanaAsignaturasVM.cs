using GradeExplorer.Models;
using GradeExplorer.Utils;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace GradeExplorer.ViewModels.WindowsVM
{
  public class VentanaAsignaturasVM : ModelBase
  {
    private Window w { get; set; }

    private Asignatura _asignatura;
    public Asignatura Asignatura
    {
      get => _asignatura;
      set => SetField(ref _asignatura, value);
    }

    private ObservableCollection<Profesor> _profesores;
    public ObservableCollection<Profesor> Profesores
    {
      get => _profesores;
      set => SetField(ref _profesores, value);
    }

    private Profesor _profesor;
    public Profesor Profesor
    {
      get => _profesor;
      set => SetField(ref _profesor, value);
    }

    private bool modificando = false;

    public RelayCommand ConfirmCommand { get; set; }

    public VentanaAsignaturasVM(Window w)
    {
      this.w = w;
      Asignatura = new Asignatura();
      ConfirmCommand = new RelayCommand((a) => Guardar());
      _profesores = new ObservableCollection<Profesor>();
      Task.Factory.StartNew(() => ObtenerProfesores());
    }

    public VentanaAsignaturasVM(Asignatura a, Window w)
    {
      this.w = w;
      Asignatura = a;
      Profesor = Asignatura.Profesor != null ? Asignatura.Profesor : null;
      modificando = true;
      ConfirmCommand = new RelayCommand((p) => Guardar());
      _profesores = new ObservableCollection<Profesor>();
      Task.Factory.StartNew(() => ObtenerProfesores());
    }

    private void ObtenerProfesores()
    {
      using (var c = new SchoolContext())
      {
        Profesor = c.Profesores.First();
        foreach (Profesor p in c.Profesores)
        {
          Application.Current.Dispatcher.BeginInvoke(new Action(() =>
          {
            Profesores.Add(p);
          }), DispatcherPriority.Background);
        }
      }
    }


    private void Guardar()
    {

    }
  }
}
