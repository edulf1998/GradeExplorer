using GradeExplorer.Models;
using GradeExplorer.Utils;
using GradeExplorer.ViewModels;
using System.Windows;

namespace GradeExplorer.Views
{
  /// <summary>
  /// Lógica de interacción para VentanaPrincipal.xaml
  /// </summary>
  public partial class VentanaPrincipal : Window
  {
    public VentanaPrincipal()
    {
      InitializeComponent();
      DataContext = new VentanaPrincipalViewModel();
    }
  }
}
