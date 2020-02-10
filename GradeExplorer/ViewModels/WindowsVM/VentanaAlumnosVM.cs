using GradeExplorer.Models;
using GradeExplorer.Utils;

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

    public RelayCommand ConfirmCommand { get; set; }

    public VentanaAlumnosVM()
    {
      _alumno = new Alumno();
      ConfirmCommand = new RelayCommand((a) => Guardar());
    }

    public VentanaAlumnosVM(Alumno a)
    {
      _alumno = CloneMachine<Alumno>.Clone(a);
      ConfirmCommand = new RelayCommand((p) => Guardar());
    }

    private void Guardar()
    {
    }
  }
}
