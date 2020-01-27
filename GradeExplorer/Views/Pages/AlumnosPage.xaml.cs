using GradeExplorer.ViewModels.PagesVM;
using System.Windows.Controls;

namespace GradeExplorer.Views.Pages
{
  /// <summary>
  /// Lógica de interacción para AlumnosPage.xaml
  /// </summary>
  public partial class AlumnosPage : Page
  {
    public AlumnosPage()
    {
      InitializeComponent();
      DataContext = new AlumnosPageVM();
      DialogoAlumno.DataContext = this;
      DialogoAlumno.Content = StackDialogo;
    }
  }
}
