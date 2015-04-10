using System.Windows;
using TreeViewProject.Views;
using TreeViewProject.ViewModels;

namespace TreeViewProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            string filepath = "data.xml";
            
            ShellViewModel viewmodel = new ShellViewModel(filepath);
            viewmodel.RequestClose +=new System.EventHandler(viewmodel_RequestClose);

            Shell shell = new Shell();
            Application.Current.MainWindow = shell;
            shell.DataContext = viewmodel;
            shell.Show();
        }

        void viewmodel_RequestClose(object sender, System.EventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
    }
}
