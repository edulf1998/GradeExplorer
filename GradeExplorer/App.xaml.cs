using GradeExplorer.Views;
using System.Windows;

namespace GradeExplorer
{
  public partial class App : Application
  {
    /// <summary>
    /// En este método podemos controlar los argumentos que se pasan al programa
    /// </summary>
    /// <param name="sender">El objeto donde se origina el evento</param>
    /// <param name="e">Aquí están contenidos los argumentos de inicio del programa</param>
    private void InicioAplicacion(object sender, StartupEventArgs e)
    {
      string[] args = e.Args;

      VentanaPrincipal ventana = new VentanaPrincipal();
      ventana.WindowState = WindowState.Normal;

      ventana.Show();
    }
  }
}
