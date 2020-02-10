using GradeExplorer.Utils;
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

      Main ventana = new Main();
      ventana.WindowState = WindowState.Normal;
      double screenWidth = SystemParameters.PrimaryScreenWidth;
      double screenHeight = SystemParameters.PrimaryScreenHeight;
      double windowWidth = ventana.Width;
      double windowHeight = ventana.Height;
      ventana.Left = (screenWidth / 2) - (windowWidth / 2);
      ventana.Top = (screenHeight / 2) - (windowHeight / 2);

      // Crear base de datos si no existe, ya que la usaremos de aqui en adelante
      using (SchoolContext c = new SchoolContext())
      {
        c.Database.CreateIfNotExists();
      }

      ventana.Show();
    }
  }
}
