using System.Collections.Generic;
using System.Windows;

namespace GradeExplorer.ViewModels
{
  public class NMainViewModel
  {
    public List<string> Pages = new List<string> { "Inicio", "Alumnos", "Personal", "Asignaturas", "Puntuaciones" };
    public string PageElegida { get; set; }

    public NMainViewModel()
    {

    }

    private void NavegarAPage(object sender, RoutedEventArgs e)
    {
      switch (PageElegida)
      {
        case "Inicio": break;
        case "Alumnos": break;
        case "Personal": break;
        case "Asignaturas": break;
        case "Puntuaciones": break;
      }
    }
  }
}
