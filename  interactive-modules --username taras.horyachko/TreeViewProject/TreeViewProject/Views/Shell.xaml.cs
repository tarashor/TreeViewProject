using System.Windows;


namespace TreeViewProject.Views
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : Window
    {
        private double previousWidth = 0;
        private double defaultWidth = 100;
        public Shell()
        {
            InitializeComponent();
        }

        private void NavigationPane_CollaspeClick(object sender, RoutedEventArgs e)
        {
            FrameworkElement pane = sender as FrameworkElement;
            if (pane != null)
            {
                previousWidth = pane.ActualWidth;
                pane.Width = pane.MinWidth;
            }
        }

        private void NavigationPane_ExpandClick(object sender, RoutedEventArgs e)
        {
            FrameworkElement pane = sender as FrameworkElement;
            if (pane != null)
            {
                if (previousWidth > pane.MinWidth)
                    pane.Width = previousWidth;
                else
                    pane.Width = defaultWidth;
            }
        }
    }
}
