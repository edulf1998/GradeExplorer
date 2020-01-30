using GradeExplorer.ViewModels.PagesVM;
using System.Windows.Controls;

namespace GradeExplorer.Views.Pages
{
  /// <summary>
  /// Lógica de interacción para PuntuacionesPage.xaml
  /// </summary>
  public partial class PuntuacionesPage : Page
  {
    public PuntuacionesPage()
    {
      InitializeComponent();
      DataContext = new PuntuacionesPageVM();
    }
  }
}
