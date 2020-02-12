using GradeExplorer.Models;
using GradeExplorer.Utils;
using System.Data.Entity;
using System.Windows;

namespace GradeExplorer.ViewModels.WindowsVM
{
  public class VentanaAlumnosVM : ModelBase
  {
    private Alumno _alumno;
    public Alumno Alumno
    {
      get => _alumno;
      set => SetField(ref _alumno, value);
    }

    private Window w { get; set; }
    private bool modificando = false;

    public RelayCommand ConfirmCommand { get; set; }

    public VentanaAlumnosVM(Window w)
    {
      _alumno = new Alumno();
      this.w = w;
      ConfirmCommand = new RelayCommand((a) => Guardar());
    }

    public VentanaAlumnosVM(Alumno a, Window w)
    {
      _alumno = CloneMachine<Alumno>.Clone(a);
      this.w = w;
      modificando = true;
      ConfirmCommand = new RelayCommand((p) => Guardar());
    }

    private void Guardar()
    {
      using (var c = new SchoolContext())
      {
        if (!modificando)
        {
          c.Alumnos.Add(Alumno);
        }
        else
        {
          c.Entry(Alumno).State = EntityState.Modified;
        }
        c.SaveChanges();
      }
      w.Close();
    }
  }
}
