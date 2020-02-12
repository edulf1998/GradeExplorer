using GradeExplorer.Models;
using GradeExplorer.ViewModels.WindowsVM;
using System.Windows;

namespace GradeExplorer.Views.Windows
{
  /// <summary>
  /// Lógica de interacción para VentanaAlumnos.xaml
  /// </summary>
  public partial class VentanaAlumnos : Window
  {
    public VentanaAlumnos()
    {
      InitializeComponent();
      DataContext = new VentanaAlumnosVM(this);
    }

    public VentanaAlumnos(Alumno a)
    {
      InitializeComponent();
      DataContext = new VentanaAlumnosVM(a, this);
    }
  }
}
