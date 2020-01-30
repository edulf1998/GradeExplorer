using GradeExplorer.ViewModels.PagesVM;
using System.Windows.Controls;

namespace GradeExplorer.Views.Pages
{
  /// <summary>
  /// Lógica de interacción para PersonalPage.xaml
  /// </summary>
  public partial class PersonalPage : Page
  {
    public PersonalPage()
    {
      InitializeComponent();
      DataContext = new PersonalPageVM();
    }
  }
}
