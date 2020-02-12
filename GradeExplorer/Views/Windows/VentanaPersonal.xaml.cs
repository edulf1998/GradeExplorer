using GradeExplorer.Models;
using GradeExplorer.ViewModels.WindowsVM;
using System.Windows;

namespace GradeExplorer.Views.Windows
{
  /// <summary>
  /// Lógica de interacción para VentanaPersonal.xaml
  /// </summary>
  public partial class VentanaPersonal : Window
  {
    public VentanaPersonal()
    {
      InitializeComponent();
      DataContext = new VentanaPersonalVM(this);
    }

    public VentanaPersonal(Profesor p)
    {
      InitializeComponent();
      DataContext = new VentanaPersonalVM(p, this);
    }
  }
}
