using GradeExplorer.Models;
using GradeExplorer.Utils;
using GradeExplorer.ViewModels;
using MahApps.Metro.Controls;
using System.Windows;

namespace GradeExplorer.Views
{
  /// <summary>
  /// Lógica de interacción para VentanaPrincipal.xaml
  /// </summary>
  public partial class VentanaPrincipal : MetroWindow
  {
    public VentanaPrincipal()
    {
      InitializeComponent();
      DataContext = new VentanaPrincipalViewModel();
    }
  }
}
