using GradeExplorer.Utils;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace GradeExplorer.ViewModels
{
  public class MainVM : INotifyBase
  {
    private List<string> _pagesMenu;
    public List<string> PagesMenu
    {
      get => _pagesMenu;
      set => SetField(ref _pagesMenu, value);
    }

    private int _pageElegida;
    public int PageElegida
    {
      get => _pageElegida;
      set => SetField(ref _pageElegida, value);
    }

    private List<Uri> _pages;
    public List<Uri> Pages 
    { 
      get => _pages; 
      set => SetField(ref _pages, value);
    }

    private Uri _uriActual;
    public Uri UriActual 
    {
      get => _uriActual;
      set => SetField(ref _uriActual, value);
    }

    public MainVM()
    {
      _pagesMenu = new List<string> { "Inicio", "Alumnos", "Personal", "Asignaturas", "Puntuaciones" };
      _pages = new List<Uri>
      {
        new Uri("Pages/InicioPage.xaml", UriKind.Relative),
        new Uri("Pages/AlumnosPage.xaml", UriKind.Relative),
        new Uri("Pages/PersonalPage.xaml", UriKind.Relative),
        new Uri("Pages/AsignaturasPage.xaml", UriKind.Relative),
        new Uri("Pages/PuntuacionesPage.xaml", UriKind.Relative),
      };
      _pageElegida = 0;
    }

    private void NavegarAPage(object sender, RoutedEventArgs e)
    {

    }
  }
}
