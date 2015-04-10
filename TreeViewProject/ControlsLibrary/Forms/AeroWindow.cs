using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Shapes;
//using Microsoft.Windows.Controls.Ribbon;
using ControlsLibrary.Controls;
using ControlsLibrary.Helpers;

namespace ControlsLibrary.Forms
{
    /// <summary>
    /// Class that represents the extended window with specific glass effect.
    /// </summary>
    [TemplatePart(Name = PART_CloseButton, Type = typeof(Button))]
    [TemplatePart(Name = PART_MinimizeButton, Type = typeof(Button))]
    [TemplatePart(Name = PART_MaximizeButton, Type = typeof(ToggleButton))]
    [TemplatePart(Name = "PART_NResizer", Type = typeof(Path))]
    [TemplatePart(Name = "PART_SResizer", Type = typeof(Path))]
    [TemplatePart(Name = "PART_EResizer", Type = typeof(Path))]
    [TemplatePart(Name = "PART_WResizer", Type = typeof(Path))]
    [TemplatePart(Name = "PART_NWResizer", Type = typeof(Rectangle))]
    [TemplatePart(Name = "PART_NEResizer", Type = typeof(Rectangle))]
    [TemplatePart(Name = "PART_SWResizer", Type = typeof(Rectangle))]
    [TemplatePart(Name = "PART_SEResizer", Type = typeof(Rectangle))]
    [TemplatePart(Name = PART_TitleBar, Type = typeof(Border))]
    [TemplatePart(Name = PART_Username, Type = typeof(TextBlock))]
    [TemplatePart(Name = PART_UsernamePanel, Type = typeof(Panel))]
    //[TemplatePart(Name = PART_RibbonMenu, Type = typeof(Microsoft.Windows.Controls.Ribbon.Ribbon))]
    [TemplatePart(Name = PART_NavigationPane, Type = typeof(NavigationPane))]
    [TemplatePart(Name = PART_NavigationPlaceColumn, Type = typeof(ColumnDefinition))]
    [TemplatePart(Name = PART_NavigationSplitterColumn, Type = typeof(ColumnDefinition))]
    [TemplatePart(Name = PART_CustomHome, Type = typeof(Border))]
    [TemplatePart(Name = PART_splitNavPane, Type = typeof(GridSplitter))]
    public class AeroWindow : Window
    {
        #region PART_Names
            /// <summary>
            /// Represents the name of the close button in ControlTemplate of <see cref="CustomWindow"/>.
            /// </summary>
            public const string PART_CloseButton = "PART_CloseButton";

            /// <summary>
            /// Represents the name of the minimize button in ControlTemplate of <see cref="CustomWindow"/>.
            /// </summary>
            public const string PART_MinimizeButton = "PART_MinimizeButton";

            /// <summary>
            /// Represents the name of the maximize button in ControlTemplate of <see cref="CustomWindow"/>.
            /// </summary>
            public const string PART_MaximizeButton = "PART_MaximizeButton";

            /// <summary>
            /// Represents the name of the title bar in ControlTemplate of <see cref="CustomWindow"/>.
            /// </summary>
            public const string PART_TitleBar = "PART_TitleBar";

            /// <summary>
            /// Represents the name of the username <see cref="T:System.Windows.Controls.TextBlock"/> in ControlTemplate of <see cref="CustomWindow"/>.
            /// </summary>
            public const string PART_Username = "PART_Username";

            /// <summary>
            /// Represents the name of the username panel in ControlTemplate of <see cref="CustomWindow"/>.
            /// </summary>
            public const string PART_UsernamePanel = "PART_UsernamePanel";

            /// <summary>
            /// Represents the name of the ribbon menu in ControlTemplate of <see cref="CustomWindow"/>.
            /// </summary>
            public const string PART_RibbonMenu = "PART_RibbonMenu";

            /// <summary>
            /// Represents the name of the pearl menu in ControlTemplate of <see cref="CustomWindow"/>.
            /// </summary>
            public const string PART_PearlMenu = "PART_PearlMenu";

            /// <summary>
            /// Represents the name of the navigation pane in ControlTemplate of <see cref="CustomWindow"/>.
            /// </summary>
            public const string PART_NavigationPane = "PART_NavigationPane";

            /// <summary>
            /// Represents the name of the navigation place column in ControlTemplate of <see cref="CustomWindow"/>.
            /// </summary>
            public const string PART_NavigationPlaceColumn = "PART_NavigationPlaceColumn";

            /// <summary>
            /// Represents the name of the navigation splitter column in ControlTemplate of <see cref="CustomWindow"/>.
            /// </summary>
            public const string PART_NavigationSplitterColumn = "PART_NavigationSplitterColumn";

            /// <summary>
            /// Represents the name of the search breadcrumb place in ControlTemplate of <see cref="CustomWindow"/>.
            /// </summary>
            public const string PART_SearchBreadcrumbPlace = "PART_SearchBreadcrumbPlace";

            /// <summary>
            /// Represents the name of the status place in ControlTemplate of <see cref="CustomWindow"/>.
            /// </summary>
            public const string PART_StatusPlace = "PART_StatusPlace";

            /// <summary>
            /// Represents the name of the Custom home <see cref="T:System.Windows.Controls.Border"/> in ControlTemplate of <see cref="CustomWindow"/>.
            /// </summary>
            public const string PART_CustomHome = "PART_CustomHome";

            /// <summary>
            /// Represents the name of the Custom home button in ControlTemplate of <see cref="CustomWindow"/>.
            /// </summary>
            public const string PART_CustomHomeButton = "PART_CustomHomeButton";

            /// <summary>
            /// Represents the name of the settings button in ControlTemplate of <see cref="CustomWindow"/>.
            /// </summary>
            public const string PART_Settings = "PART_Settings";

            /// <summary>
            /// Represents the name of the help button in ControlTemplate of <see cref="CustomWindow"/>.
            /// </summary>
            public const string PART_Help = "PART_Help";

            /// <summary>
            /// Represents the name of the help notificator in ControlTemplate of <see cref="CustomWindow"/>.
            /// </summary>
            public const string PART_HelpNotificator = "PART_HelpNotificator";

            /// <summary>
            /// Represents the name of the split navigation pane in ControlTemplate of <see cref="CustomWindow"/>.
            /// </summary>
            public const string PART_splitNavPane = "PART_splitNavPane";

    #endregion

#region Fields
            /// <summary>
            /// This field represents CustomWindow Collapsed Navigation Width.
            /// </summary>
            public static double CustomWindowCollapsedNavigationWidth = 32;

            /// <summary>
            /// This field represents interoperability Helper.
            /// </summary>
            private WindowInteropHelper _interopHelper;

            /// <summary>
            /// This field represents maximize Button.
            /// </summary>
            private ToggleButton maximizeButton;

            /// <summary>
            /// This field represents ribbonMenu.
            /// </summary>
            //private Ribbon ribbonMenu;
        
            /// <summary>
            /// This field represents Settings Button.
            /// </summary>
            protected Button SettingsButton;

            /*/// <summary>
            /// This field represents CustomHelp Button.
            /// </summary>
            protected CustomSplitButton CustomHelpButton;
        */
            /// <summary>
            /// This field represents ribbonContextualGroups.
            /// </summary>
            //private ObservableCollection<RibbonContextualTabGroup> ribbonContextualGroups;

#endregion
            /*/// <summary>
            /// Gets the ribbon contextual groups.
            /// </summary>
            /// <value>
            /// The ribbon contextual groups.
            /// </value>
            public ObservableCollection<RibbonContextualTabGroup> RibbonContextualGroups
            {
                get
                {
                    if (ribbonContextualGroups == null)
                    {
                        ribbonContextualGroups = new ObservableCollection<RibbonContextualTabGroup>();
                    }
                    return ribbonContextualGroups;
                }
            }*/

            /// <summary>
            /// The field that defines a CustomHomeVisibility dependency property.
            /// </summary>
            public static DependencyProperty CustomHomeVisibilityProperty =
                DependencyProperty.Register("CustomHomeVisibility", typeof(Visibility),
                typeof(AeroWindow), new FrameworkPropertyMetadata(null));


            /// <summary>
            /// Gets or sets the settings visibility.
            /// </summary>
            /// <value>
            /// The visibility.
            /// </value>
            public Visibility SettingsVisibility
            {
                get { return (Visibility)GetValue(SettingsVisibilityProperty); }
                set { SetValue(SettingsVisibilityProperty, value); }
            }

            /// <summary>
            /// The field that defines a SettingsVisibility dependency property.
            /// </summary>
            public static readonly DependencyProperty SettingsVisibilityProperty =
                DependencyProperty.Register("SettingsVisibility", typeof(Visibility), typeof(AeroWindow), new UIPropertyMetadata(Visibility.Collapsed));


            /// <summary>
            /// Initializes static members of the <see cref="CustomWindow"/> class.
            /// </summary>
            static AeroWindow()
            {
                DefaultStyleKeyProperty.OverrideMetadata(typeof(AeroWindow),
                                                         new FrameworkPropertyMetadata(
                                                            typeof(AeroWindow)));


            }

            /// <summary>
            /// Initializes a new instance of the <see cref="CustomWindow"/> class.
            /// </summary>
            public AeroWindow()
            {
                if (DesignerProperties.GetIsInDesignMode(this))
                {
                }
                FlowDirection = CultureInfo.CurrentCulture.TextInfo.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
            }

            /// <summary>
            /// When overridden in a derived class, is invoked whenever application code or internal processes call <see cref="M:System.Windows.FrameworkElement.ApplyTemplate"/>.
            /// </summary>
            public override void OnApplyTemplate()
            {
                base.OnApplyTemplate();

                _interopHelper = new WindowInteropHelper(this);
                AttachToVisualTree();
            }

            /// <summary>
            /// Setups the root background.
            /// </summary>
            private void SetupRootBackground()
            {
                Border rootBorder = GetChildControl<Border>("PART_RootBorder");
                if (rootBorder != null)
                    rootBorder.Background = Brushes.Transparent;//IsGlassEnabled() ? Brushes.Transparent : FindResource(Custom.Common.ThemePack.ApplicationSkinResources.WindowBackgroundBrushKey) as Brush;
            }

            /// <summary>
            /// Attaches to visual tree.
            /// </summary>
            private void AttachToVisualTree()
            {
                
                SetupRootBackground();

                // Close Button
                Button closeButton = GetChildControl<Button>(PART_CloseButton);
                if (closeButton != null)
                {
                    closeButton.Click += OnCloseButtonClick;
                }

                // Minimize Button
                Button minimizeButton = GetChildControl<Button>(PART_MinimizeButton);
                if (minimizeButton != null)
                {
                    minimizeButton.Click += OnMinimizeButtonClick;
                }

                // Maximize Button
                maximizeButton = GetChildControl<ToggleButton>(PART_MaximizeButton);
                if (maximizeButton != null)
                {
                    maximizeButton.Checked += MaximinizeButton_Checked;
                    maximizeButton.Unchecked += MaximinizeButton_Unchecked;

                    if (this.WindowState == WindowState.Maximized)
                    {
                        maximizeButton.IsChecked = true;
                    }
                }

                // Ribbon Menu
                //ribbonMenu = GetChildControl<Microsoft.Windows.Controls.Ribbon.Ribbon>(PART_RibbonMenu);

                //CustomHelpButton = GetChildControl<CustomSplitButton>(PART_Help);

                // Title Bar
                Border titleBar = GetChildControl<Border>(PART_TitleBar);
                if (titleBar != null)
                {
                    titleBar.MouseLeftButtonDown += OnTitleBarMouseDown;
                    titleBar.Background = new SolidColorBrush(Color.FromArgb((byte)1, (byte)0, (byte)0, (byte)0));
                }

                this.SourceInitialized += new EventHandler(MainWindow_SourceInitialized);
            }

            /// <summary>
            /// Handles the SourceInitialized event of the MainWindow control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
            private void MainWindow_SourceInitialized(object sender, EventArgs e)
            {
                System.IntPtr handle = (new System.Windows.Interop.WindowInteropHelper(this)).Handle;
                System.Windows.Interop.HwndSource.FromHwnd(handle).AddHook(new System.Windows.Interop.HwndSourceHook(MonitorResize.WindowProc));
                System.Windows.Interop.HwndSource.FromHwnd(handle).AddHook(new System.Windows.Interop.HwndSourceHook(WindowProc));

                maximizeButton.IsChecked = (this.WindowState == WindowState.Maximized ? true : false);

                //var am = ribbonMenu.ApplicationMenu;
                //if (am == null)
                //{
                //    throw new Exception("Application menu not initialized.");
                //}

                //ExtendGlass(this, new Thickness(-1));
                ExtendGlass(this, GlassWindowClientThickness);
            }

            /// <summary>
            /// This field represents WM_DWMCOMPOSITIONCHANGED message.
            /// </summary>
            private const int WM_DWMCOMPOSITIONCHANGED = 0x031E;

            /// <summary>
            /// This field represents GlassWindow Client Thickness.
            /// </summary>
            private Thickness GlassWindowClientThickness = new Thickness(8, 53, 8, 8);

            /// <summary>
            /// Hadles window messages.
            /// </summary>
            /// <param name="hwnd">The Handle.</param>
            /// <param name="msg">The Message.</param>
            /// <param name="wParam">The wparam.</param>
            /// <param name="lParam">The lparam.</param>
            /// <param name="handled">If set to <c>true</c> if message is handled.</param>
            /// <returns>The result value.</returns>
            public System.IntPtr WindowProc(
                        System.IntPtr hwnd,
                        int msg,
                        System.IntPtr wParam,
                        System.IntPtr lParam,
                        ref bool handled)
            {
                if (msg == WM_DWMCOMPOSITIONCHANGED)
                {
                    SetupRootBackground();
                    ExtendGlass(this, GlassWindowClientThickness);
                    handled = true;
                }
                return IntPtr.Zero;
            }

            /// <summary>
            /// Handles the Unchecked event of the MaximinizeButton control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
            private void MaximinizeButton_Unchecked(object sender, RoutedEventArgs e)
            {
                this.WindowState = WindowState.Normal;
            }

            /// <summary>
            /// Handles the Checked event of the MaximinizeButton control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
            private void MaximinizeButton_Checked(object sender, RoutedEventArgs e)
            {
                this.WindowState = WindowState.Maximized;
            }

            /// <summary>
            /// Called when mouse down event title bar .
            /// </summary>
            /// <param name="sender">The sender.</param>
            /// <param name="e">The <see cref="System.Windows.Input.MouseButtonEventArgs"/> instance containing the event data.</param>
            private void OnTitleBarMouseDown(object sender, MouseButtonEventArgs e)
            {
                if (ResizeMode != ResizeMode.NoResize && e.ClickCount == 2)
                {
                    if (maximizeButton != null)
                        maximizeButton.IsChecked = !maximizeButton.IsChecked;

                    return;
                }
                this.DragMove();
            }

            /// <summary>
            /// Gets the child control.
            /// </summary>
            /// <typeparam name="T">Type of the control.</typeparam>
            /// <param name="ctrlName">Name of the control.</param>
            /// <returns>
            /// The child control.
            /// </returns>
            protected T GetChildControl<T>(string ctrlName) where T : DependencyObject
            {
                T ctrl = GetTemplateChild(ctrlName) as T;
                return ctrl;
            }

            /// <summary>
            /// Moves the window.
            /// </summary>
            /// <param name="rect">The rectangle.</param>
            protected void MoveWindow(Rect rect)
            {
                MoveWindow(_interopHelper.Handle, (int)rect.Left,
                           (int)rect.Top, (int)rect.Width, (int)rect.Height, false);
            }

            /// <summary>
            /// Called when close button is clicked.
            /// </summary>
            /// <param name="sender">The sender.</param>
            /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
            private void OnCloseButtonClick(object sender, RoutedEventArgs e)
            {
                Close();
            }

            /// <summary>
            /// Handles the Completed event of the CloseAnimation control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
            private void CloseAnimation_Completed(object sender, EventArgs e)
            {
                this.Close();
            }

            /// <summary>
            /// Called when minimize button is clicked.
            /// </summary>
            /// <param name="sender">The sender.</param>
            /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
            private void OnMinimizeButtonClick(object sender, RoutedEventArgs e)
            {
                WindowState = WindowState.Minimized;
            }


            /// <summary>
            /// Gets the ribbon menu.
            /// </summary>
            /// <value>
            /// The ribbon menu.
            /// </value>
            //protected Ribbon RibbonMenu { get { return ribbonMenu; } }


            #region P/Invoke and Helper Method

            /// <summary>
            /// Represents sizing action.
            /// </summary>
            public enum SizingAction
            {
                /// <summary>
                /// This field represents North direction.
                /// </summary>
                North = 3,

                /// <summary>
                /// This field represents South direction.
                /// </summary>
                South = 6,

                /// <summary>
                /// This field represents East direction.
                /// </summary>
                East = 2,

                /// <summary>
                /// This field represents West direction.
                /// </summary>
                West = 1,

                /// <summary>
                /// This field represents NorthEast direction.
                /// </summary>
                NorthEast = 5,

                /// <summary>
                /// This field represents NorthWest direction.
                /// </summary>
                NorthWest = 4,

                /// <summary>
                /// This field represents SouthEast direction.
                /// </summary>
                SouthEast = 8,

                /// <summary>
                /// This field represents SouthWest direction.
                /// </summary>
                SouthWest = 7
            }

            /// <summary>
            /// This field represents SC_SIZE.
            /// </summary>
            private const int SC_SIZE = 0xF000;

            /// <summary>
            /// This field represents WM_SYSCOMMAND.
            /// </summary>
            private const int WM_SYSCOMMAND = 0x112;

            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam,
                                                     IntPtr lParam);

            [DllImport("user32")]
            private static extern Boolean MoveWindow(
                IntPtr hWnd,
                Int32 x, Int32 y,
                Int32 nWidth, Int32 nHeight, Boolean bRepaint);

            /// <summary>
            /// Implements sizing with mouse.
            /// </summary>
            /// <param name="handle">The handle.</param>
            /// <param name="sizingAction">The sizing action.</param>
            private void DragSize(IntPtr handle, SizingAction sizingAction)
            {
                if ((Mouse.LeftButton == MouseButtonState.Pressed) && (WindowState == WindowState.Normal))
                {
                    SendMessage(handle, WM_SYSCOMMAND, (IntPtr)(SC_SIZE + sizingAction), IntPtr.Zero);
                    SendMessage(handle, 514, IntPtr.Zero, IntPtr.Zero);
                }
            }

            #endregion

            #region Glass Window

            /// <summary>
            /// This structure represents margins.
            /// </summary>
            [StructLayout(LayoutKind.Sequential)]
            struct MARGINS
            {
                /// <summary>
                /// This field represents Left Width.
                /// </summary>
                public int cxLeftWidth;

                /// <summary>
                /// This field represents Right Width.
                /// </summary>
                public int cxRightWidth;

                /// <summary>
                /// This field represents Top Height.
                /// </summary>
                public int cyTopHeight;

                /// <summary>
                /// This field represents Bottom Height.
                /// </summary>
                public int cyBottomHeight;
            }

            [DllImport("dwmapi.dll")]
            static extern int
               DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

            [DllImport("dwmapi.dll")]
            extern static int DwmIsCompositionEnabled(ref int en);

            /// <summary>
            /// Extends the glass area into the client area of the window.
            /// </summary>
            /// <param name="window">The window.</param>
            /// <param name="thikness">The thikness.</param>
            public static void ExtendGlass(Window window, Thickness thikness)
            {
                try
                {
                    int isGlassEnabled = 0;
                    DwmIsCompositionEnabled(ref isGlassEnabled);
                    if (Environment.OSVersion.Version.Major > 5 && isGlassEnabled > 0)
                    {
                        // Get the window handle
                        WindowInteropHelper helper = new WindowInteropHelper(window);
                        HwndSource mainWindowSrc = (HwndSource)HwndSource.
                            FromHwnd(helper.Handle);
                        mainWindowSrc.CompositionTarget.BackgroundColor =
                            Colors.Transparent;

                        // Get the dpi of the screen
                        System.Drawing.Graphics desktop =
                           System.Drawing.Graphics.FromHwnd(mainWindowSrc.Handle);
                        float dpiX = desktop.DpiX / 96;
                        float dpiY = desktop.DpiY / 96;

                        // Set Margins
                        MARGINS margins = new MARGINS();
                        margins.cxLeftWidth = (int)(thikness.Left * dpiX);
                        margins.cxRightWidth = (int)(thikness.Right * dpiX);
                        margins.cyBottomHeight = (int)(thikness.Bottom * dpiY);
                        margins.cyTopHeight = (int)(thikness.Top * dpiY);

                        window.Background = Brushes.Transparent;

                        int hr = DwmExtendFrameIntoClientArea(mainWindowSrc.Handle,
                                    ref margins);
                    }
                    else
                    {
                        window.Background = SystemColors.WindowBrush;
                    }
                }
                catch (DllNotFoundException)
                {

                }
            }

            /// <summary>
            /// Determines whether glass mode is enabled.
            /// </summary>
            /// <returns>
            ///   <c>true</c> if glass mode is enabled; otherwise, <c>false</c>.
            /// </returns>
            public static bool IsGlassEnabled()
            {
                try
                {
                    int isGlassEnabled = 0;
                    DwmIsCompositionEnabled(ref isGlassEnabled);
                    return (Environment.OSVersion.Version.Major > 5 && isGlassEnabled > 0);
                }
                catch
                {
                    return false;
                }

            }

            #endregion
    }
}
