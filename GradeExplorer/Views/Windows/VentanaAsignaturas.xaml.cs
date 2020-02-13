using GradeExplorer.Models;
using GradeExplorer.ViewModels.WindowsVM;
using System.Windows;

namespace GradeExplorer.Views.Windows
{
  /// <summary>
  /// Lógica de interacción para VentanaAsignaturas.xaml
  /// </summary>
  public partial class VentanaAsignaturas : Window
  {
    public VentanaAsignaturas()
    {
      InitializeComponent();
      DataContext = new VentanaAsignaturasVM(this);
    }

    public VentanaAsignaturas(Asignatura a)
    {
      InitializeComponent();
      DataContext = new VentanaAsignaturasVM(a, this);
    }
  }
}
