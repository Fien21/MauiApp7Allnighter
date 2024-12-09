namespace MauiApp7Allnighter
{
    public partial class App : Application
    {
        public static StudentRepository StudentRepo { get; private set; }

        public App(StudentRepository repo)
        {
            InitializeComponent();
            StudentRepo = repo;
            MainPage = new AppShell();
        }
    }
}
