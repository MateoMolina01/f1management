using f1management.Persistence;
using System.Configuration;
using System.Data;
using System.Windows;

namespace f1management;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static Usuario UsuarioActual { get; set; }
}

