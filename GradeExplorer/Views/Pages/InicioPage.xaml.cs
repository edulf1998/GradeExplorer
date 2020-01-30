using GradeExplorer.Utils;
using System.Windows.Controls;

namespace GradeExplorer.Views.Pages
{
  /// <summary>
  /// Lógica de interacción para InicioPage.xaml
  /// </summary>
  public partial class InicioPage : Page
  {
    public InicioPage()
    {
      InitializeComponent();
    }

    private void CargarDatosEjemplo(object sender, System.Windows.RoutedEventArgs e)
    {
      NHibernateUtil.InsertarDatosDemo();
    }

    private void VaciarBaseDatos(object sender, System.Windows.RoutedEventArgs e)
    {
      NHibernateUtil.DeleteDb();
    }
  }
}
