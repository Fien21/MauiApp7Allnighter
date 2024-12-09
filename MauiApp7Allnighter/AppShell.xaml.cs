namespace MauiApp7Allnighter
{
    public partial class App : Application
    {
        // Property to access the injected StudentRepository
        public static StudentRepository StudentRepo { get; private set; }

        public App()
        {
            InitializeComponent();
            // Access StudentRepo here after DI setup
            StudentRepo = DependencyService.Get<StudentRepository>();
            MainPage = new AppShell();  // Set AppShell as the main page for navigation
        }
    }
}
