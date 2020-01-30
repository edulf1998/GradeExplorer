using GradeExplorer.ViewModels;
using ModernWpf.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace GradeExplorer.Views
{
  public partial class Main : Window
  {
    private List<ObjetoMenu> _pagesMenu;
    public List<ObjetoMenu> PagesMenu
    {
      get => _pagesMenu;
      set => _pagesMenu = value;
    }

    private int _pageElegida = 0;
    public int PageElegida
    {
      get => _pageElegida;
      set => CambiarIndice(value);
    }

    private void CambiarIndice(int value)
    {
      _pageElegida = value;
      Navegar();
    }

    public Main()
    {
      InitializeComponent();
      _pagesMenu = new List<ObjetoMenu>
      {
        new ObjetoMenu() { Icono = Symbol.Home, Texto = "Inicio" },
        new ObjetoMenu() { Icono = Symbol.People, Texto = "Alumnos" },
        new ObjetoMenu() { Icono = Symbol.Contact, Texto="Personal" },
        new ObjetoMenu() { Icono = Symbol.PreviewLink, Texto="Asignaturas" },
        new ObjetoMenu() { Icono = Symbol.Mail, Texto="Puntuaciones" }
      };

      DataContext = new MainVM(); // Asigno el DataContext principal

      // Indico que el DataContext de los elementos relacionados con la navegación deben ser esta clase
      ListaPages.DataContext = this;
      FramePrincipal.DataContext = this;
    }

    private void Navegar()
    {
      ObjetoMenu seleccionado = _pagesMenu.ElementAt(_pageElegida);
      switch (seleccionado.Texto)
      {
        case "Inicio":
          FramePrincipal.Source = new Uri("./Pages/InicioPage.xaml", UriKind.Relative);
          break;
        case "Alumnos":
          FramePrincipal.Source = new Uri("./Pages/AlumnosPage.xaml", UriKind.Relative);
          break;
        case "Personal":
          FramePrincipal.Source = new Uri("./Pages/PersonalPage.xaml", UriKind.Relative);
          break;
        case "Asignaturas":
          FramePrincipal.Source = new Uri("./Pages/AsignaturasPage.xaml", UriKind.Relative);
          break;
        case "Puntuaciones":
          FramePrincipal.Source = new Uri("./Pages/PuntuacionesPage.xaml", UriKind.Relative);
          break;
      }
    }

    public class ObjetoMenu
    {
      public Symbol Icono { get; set; }
      public string Texto { get; set; }
    }
  }
}
