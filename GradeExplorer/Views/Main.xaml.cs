using GradeExplorer.Models;
using GradeExplorer.Utils;
using GradeExplorer.ViewModels;
using System.Windows;

namespace GradeExplorer.Views
{
  /// <summary>
  /// Lógica de interacción para VentanaPrincipal.xaml
  /// </summary>
  public partial class Main : Window
  {
    public Main()
    {
      InitializeComponent();
      DataContext = new NMainViewModel();
    }
  }
}
