using GradeExplorer.ViewModels.PagesVM;
using System.Windows.Controls;

namespace GradeExplorer.Views.Pages
{
  /// <summary>
  /// Lógica de interacción para AsignaturasPage.xaml
  /// </summary>
  public partial class AsignaturasPage : Page
  {
    public AsignaturasPage()
    {
      InitializeComponent();
      DataContext = new AsignaturasPageVM();
    }
  }
}
