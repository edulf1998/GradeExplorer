using GradeExplorer.Models;
using GradeExplorer.Utils;

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

    public RelayCommand ConfirmCommand { get; set; }

    public VentanaPersonalVM()
    {
      _profesor = new Profesor();
      ConfirmCommand = new RelayCommand((a) => Guardar());
    }

    public VentanaPersonalVM(Profesor a)
    {
      _profesor = CloneMachine<Profesor>.Clone(a);
      ConfirmCommand = new RelayCommand((p) => Guardar());
    }

    private void Guardar()
    {
    }
  }
}
