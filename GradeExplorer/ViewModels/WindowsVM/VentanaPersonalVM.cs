using GradeExplorer.Models;
using GradeExplorer.Utils;
using System.Data.Entity;
using System.Windows;

namespace GradeExplorer.ViewModels.WindowsVM
{
  public class VentanaPersonalVM : ModelBase
  {
    private Profesor _profesor;
    public Profesor Profesor
    {
      get => _profesor;
      set => SetField(ref _profesor, value);
    }

    private Window w { get; set; }
    public RelayCommand ConfirmCommand { get; set; }
    private bool modificando = false;

    public VentanaPersonalVM(Window w)
    {
      _profesor = new Profesor();
      this.w = w;
      ConfirmCommand = new RelayCommand((a) => Guardar());
    }

    public VentanaPersonalVM(Profesor a, Window w)
    {
      _profesor = CloneMachine<Profesor>.Clone(a);
      modificando = true;
      this.w = w;
      ConfirmCommand = new RelayCommand((p) => Guardar());
    }

    private void Guardar()
    {
      using (var c = new SchoolContext())
      {
        if (!modificando)
        {
          c.Profesores.Add(Profesor);
        }
        else
        {
          c.Entry(Profesor).State = EntityState.Modified;
        }
        c.SaveChanges();
      }
      w.Close();
    }
  }
}
