using APPLOGIN.Data;
using APPLOGIN.Pages;

namespace APPLOGIN;

public partial class App : Application
{

    static SQLiteData _bancoDados;

    public static SQLiteData BancoDados
    {
        get
        {
            if (_bancoDados == null)
            {
                _bancoDados =
                    new SQLiteData(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Dados.db"));
                    
            }
            return _bancoDados;
        }
    }

    public static UsuarioData Usuario { get; set; }
   public App()
   {
       InitializeComponent();

       MainPage = new NavigationPage( new LoginUsuarioPage());
   }
}

