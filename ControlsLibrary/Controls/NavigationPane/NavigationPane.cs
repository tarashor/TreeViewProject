using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace ControlsLibrary.Controls
{

    /// <summary>
    /// Class that represent Custom.Windows.Controls.NavigationPane.
    /// </summary>
    [StyleTypedProperty(Property = "ItemContainerStyle", StyleTargetType = typeof(NavigationPaneItem))]
    [TemplatePart(Name = PART_ToggleViewButton, Type = typeof(ToggleButton))]
    [TemplatePart(Name = PART_SideBarButton, Type = typeof(ToggleButton))]
    [TemplatePart(Name = PART_QuickPopup, Type = typeof(Popup))]
    [TemplatePart(Name = PART_HeaderPanel, Type = typeof(StackPanel))]
    [TemplatePart(Name = PART_SelectedContentHost, Type = typeof(ContentPresenter))]
    [TemplatePart(Name = PART_HGridSplitter, Type = typeof(GridSplitter))]
    [TemplatePart(Name = PART_ContentPanel, Type = typeof(Grid))]
    [TemplatePart(Name = PART_OverflowPanel, Type = typeof(ListBox))]
    [TemplatePart(Name = PART_OverflowBorder, Type = typeof(ListBox))]
    [TemplatePart(Name = PART_SettingsButton, Type = typeof(Button))]
    [TemplatePart(Name = PART_MoreItemsButton, Type = typeof(ToggleButton))]
    [ToolboxItem(true), DesignTimeVisible(true)]
    public class NavigationPane : System.Windows.Controls.TabControl, IDisposable
    {

        #region Declarations

        // TemplatePart's key used inside the resource dictionary
        
        /// <summary>
        /// Represent child control's name in ControlTemplate of <seealso cref="NavigationPane"/> .
        /// </summary>
        private const string PART_ToggleViewButton = "PART_ToggleViewButton";
        
        /// <summary>
        /// Represent child control's name in ControlTemplate of <seealso cref="NavigationPane"/> .
        /// </summary>
        private const string PART_SideBarButton = "PART_SideBarButton";
        
        /// <summary>
        /// Represent child control's name in ControlTemplate of <seealso cref="NavigationPane"/> .
        /// </summary>
        private const string PART_QuickPopup = "PART_QuickPopup";
        
        /// <summary>
        /// Represent child control's name in ControlTemplate of <seealso cref="NavigationPane"/> .
        /// </summary>
        private const string PART_SelectedContentHost = "PART_SelectedContentHost";
        
        /// <summary>
        /// Represent child control's name in ControlTemplate of <seealso cref="NavigationPane"/> .
        /// </summary>
        private const string PART_HeaderPanel = "PART_HeaderPanel";
        
        /// <summary>
        /// Represent child control's name in ControlTemplate of <seealso cref="NavigationPane"/> .
        /// </summary>
        private const string PART_HGridSplitter = "PART_HGridSplitter";
        
        /// <summary>
        /// Represent child control's name in ControlTemplate of <seealso cref="NavigationPane"/> .
        /// </summary>
        private const string PART_ContentPanel = "ContentPanel";
        
        /// <summary>
        /// Represent child control's name in ControlTemplate of <seealso cref="NavigationPane"/> .
        /// </summary>
        private const string PART_OverflowPanel = "PART_OverflowPanel";
        
        /// <summary>
        /// Represent child control's name in ControlTemplate of <seealso cref="NavigationPane"/> .
        /// </summary>
        private const string PART_OverflowBorder = "PART_OverflowBorder";
        
        /// <summary>
        /// Represent child control's name in ControlTemplate of <seealso cref="NavigationPane"/> .
        /// </summary>
        private const string PART_SettingsButton = "PART_SettingsButton";
        
        /// <summary>
        /// Represent child control's name in ControlTemplate of <seealso cref="NavigationPane"/> .
        /// </summary>
        private const string PART_RootPanel = "PART_RootPanel";
        
        /// <summary>
        /// Represent child control's name in ControlTemplate of <seealso cref="NavigationPane"/> .
        /// </summary>
        private const string PART_MoreItemsButton = "PART_MoreItemsButton";

        //constants for arranging navigation items

        /// <summary>
        /// This field represents expected Navavigation Item Height.
        /// </summary>
        private const int expNavItemHeight = 32;
        
        /// <summary>
        /// This field represents minimal Navavigation Item Width.
        /// </summary>
        private const int minNavItemWidth = 25;

        // Controls which are used througout the class
        /// <summary>
        /// This field represents root Panel.
        /// </summary>
        private Grid rootPanel;
        
        /// <summary>
        /// This field represents toggle View.
        /// </summary>
        private ToggleButton toggleView;
        
        /// <summary>
        /// This field represents content Panel.
        /// </summary>
        private Grid contentPanel;
        
        /// <summary>
        /// This field represents header Panel.
        /// </summary>
        private StackPanel headerPanel;
        
        /// <summary>
        /// This field represents splitter.
        /// </summary>
        private GridSplitter splitter;
        
        /// <summary>
        /// This field represents overflow Bar.
        /// </summary>
        private ListBox overflowBar;
        
        /// <summary>
        /// This field represents overflow Border.
        /// </summary>
        private Border overflowBorder;
        
        /// <summary>
        /// This field represents settings Button.
        /// </summary>
        private Button settingsButton;
        
        /// <summary>
        /// This field represents sidebar Button.
        /// </summary>
        private ToggleButton sidebarButton;
        
        /// <summary>
        /// This field represents moreItems Button.
        /// </summary>
        private ToggleButton moreItemsButton;

        /// <summary>
        /// This field represents desiredExpItems.
        /// </summary>
        private int? desiredExpItems = null;
        
        /// <summary>
        /// This field represents byPassSelectedChanged.
        /// </summary>
        private bool byPassSelectedChanged = false;
        
        /// <summary>
        /// This field represents byPassToggle.
        /// </summary>
        private bool byPassToggle = false;

        /// <summary>
        /// Handles the collapse event of the <c>NavigationPane</c> .
        /// </summary>
        public event RoutedEventHandler CollaspeClick;

        /// <summary>
        /// Handles the expand event of the <c>NavigationPane</c> .
        /// </summary>
        public event RoutedEventHandler ExpandClick;

        /// <summary>
        /// Handles the setting command event of the <c>NavigationPane</c> .
        /// </summary>
        public static readonly RoutedEvent SettingsCommandEvent;

        /// <summary>
        /// Identifies the Custom.Windows.Controls.NavigationPane.HeaderProperty property.
        /// </summary>
        public static DependencyProperty HeaderProperty = DependencyProperty.Register("Header", typeof(string),
                typeof(NavigationPane), new FrameworkPropertyMetadata(string.Empty,
                FrameworkPropertyMetadataOptions.AffectsRender));

        /// <summary>
        /// Identifies the Custom.Windows.Controls.NavigationPane.HeaderImageProperty property.
        /// </summary>
        public static DependencyProperty HeaderImageProperty = DependencyProperty.Register("HeaderImage", typeof(ImageSource),
                typeof(NavigationPane), new FrameworkPropertyMetadata(null,
                FrameworkPropertyMetadataOptions.AffectsRender));

        /// <summary>
        /// Identifies the Custom.Windows.Controls.NavigationPane.HeaderImageVisibilityProperty property.
        /// </summary>
        public static DependencyProperty HeaderImageVisibilityProperty = DependencyProperty.Register("HeaderImageVisibility", typeof(Visibility),
                typeof(NavigationPane), new FrameworkPropertyMetadata(null));

        /// <summary>
        /// Identifies the Custom.Windows.Controls.NavigationPane.IsCollapsableProperty property.
        /// </summary>
        public static DependencyProperty IsCollapsableProperty = DependencyProperty.Register("IsCollapsable", typeof(bool),
                typeof(NavigationPane), new FrameworkPropertyMetadata(true,
                FrameworkPropertyMetadataOptions.AffectsMeasure));

        /// <summary>
        /// Identifies the Custom.Windows.Controls.NavigationPane.DockItemsPanelVisibilityProperty property.
        /// </summary>
        public static DependencyProperty DockItemsPanelVisibilityProperty = DependencyProperty.Register("DockItemsPanelVisibility", typeof(Visibility),
                typeof(NavigationPane), new FrameworkPropertyMetadata(null));

        /// <summary>
        /// Identifies the Custom.Windows.Controls.NavigationPane.ViewModeProperty property.
        /// </summary>
        public static DependencyProperty ViewModeProperty = DependencyProperty.Register("ViewMode", typeof(NavigationPaneMode),
                typeof(NavigationPane), new UIPropertyMetadata(NavigationPaneMode.PaneMode, new PropertyChangedCallback(ViewModePropertyChangedCallback)));

        /// <summary>
        /// Identifies the Custom.Windows.Controls.NavigationPane.PanePlacementProperty property.
        /// </summary>
        public static DependencyProperty PanePlacementProperty = DependencyProperty.Register("PanePlacement", typeof(Placement),
                typeof(NavigationPane), new UIPropertyMetadata(Placement.Left));

        /// <summary>
        /// Identifies the Custom.Windows.Controls.NavigationPane.SettingsButtonVisibilityProperty property.
        /// </summary>
        public static readonly DependencyProperty SettingsButtonVisibilityProperty =
            DependencyProperty.Register("SettingsButtonVisibility", typeof(Visibility), typeof(NavigationPane), new UIPropertyMetadata(Visibility.Collapsed));

        /// <summary>
        /// Identifies the Custom.Windows.Controls.NavigationPane.SettingsMenuProperty property.
        /// </summary>
        public static readonly DependencyProperty SettingsMenuProperty =
            DependencyProperty.Register("SettingsMenu", typeof(ObservableCollection<MenuItem>), typeof(NavigationPane), new UIPropertyMetadata(null, new PropertyChangedCallback(OnSettingsMenuPropertyCallback)));

        /// <summary>
        /// The field that defines a NavigationItemsFixed dependency property.
        /// </summary>
        public static readonly DependencyProperty NavigationItemsFixedProperty =
            DependencyProperty.Register("NavigationItemsFixed", typeof(bool), typeof(NavigationPane), new PropertyMetadata(true));

        /// <summary>
        /// The field that defines a IsToggleViewChecked dependency property.
        /// </summary>
        public static readonly DependencyProperty IsToggleViewCheckedProperty =
            DependencyProperty.Register("IsToggleViewChecked", typeof(bool), typeof(NavigationPane), new PropertyMetadata(true));

        #endregion

        #region Enumerations

        /// <summary>
        /// Represents navigation pane mode.
        /// </summary>
        public enum NavigationPaneMode
        {
            /// <summary>
            /// This field represents PaneMode.
            /// </summary>
            PaneMode,
            
            /// <summary>
            /// This field represents TabMode.
            /// </summary>
            TabMode,
            
            /// <summary>
            /// This field represents TabWithoutHeaderMode.
            /// </summary>
            TabWithoutHeaderMode,
        }

        /// <summary>
        /// Represents placement.
        /// </summary>
        public enum Placement
        {
            /// <summary>
            /// This field represents Left placement.
            /// </summary>
            Left,
            
            /// <summary>
            /// This field represents Right placement.
            /// </summary>
            Right,
        }

        #endregion

        #region Header Property


        /// <summary>
        /// Gets or sets the header of the NavigationPane.
        /// </summary>
        /// <value>
        /// The header.
        /// </value>
        public string Header
        {
            get
            {
                return (string)this.GetValue(NavigationPane.HeaderProperty);
            }
            set
            {
                this.SetValue(NavigationPane.HeaderProperty, value);
            }
        }

        #endregion

        #region HeaderImage Property

        /// <summary>
        /// Gets or sets the header image.
        /// </summary>
        /// <value>
        /// The header image.
        /// </value>
        public ImageSource HeaderImage
        {
            get
            {
                return (ImageSource)this.GetValue(HeaderImageProperty);
            }
            set
            {
                this.SetValue(HeaderImageProperty, value);
            }
        }

        #endregion

        #region DockItemsPanelVisibility Property

        /// <summary>
        /// Gets or sets the dock items panel visibility.
        /// </summary>
        /// <value>
        /// The dock items panel visibility.
        /// </value>
        public Visibility DockItemsPanelVisibility
        {
            get
            {
                return (Visibility)this.GetValue(DockItemsPanelVisibilityProperty);
            }
            set
            {
                this.SetValue(DockItemsPanelVisibilityProperty, value);
            }
        }

        #endregion

        #region HeaderImageVisibility Property

        /// <summary>
        /// Gets or sets the header image visibility.
        /// </summary>
        /// <value>
        /// The header image visibility.
        /// </value>
        public Visibility HeaderImageVisibility
        {
            get
            {
                return (Visibility)this.GetValue(HeaderImageVisibilityProperty);
            }
            set
            {
                this.SetValue(HeaderImageVisibilityProperty, value);
            }
        }

        #endregion

        #region IsCollapsable Property

        /// <summary>
        /// Gets or sets a value indicating whether this instance is collapsable.
        /// </summary>
        /// <value>
        /// Is <c>true</c> if this instance is collapsable; otherwise, <c>false</c>.
        /// </value>
        public bool IsCollapsable
        {
            get
            {
                return (bool)this.GetValue(IsCollapsableProperty);
            }
            set
            {
                this.SetValue(IsCollapsableProperty, value);
            }
        }

        #endregion

        #region ViewMode Property

        /// <summary>
        /// Gets or sets the view mode.
        /// </summary>
        /// <value>
        /// The view mode.
        /// </value>
        public NavigationPaneMode ViewMode
        {
            get
            {
                return (NavigationPaneMode)this.GetValue(ViewModeProperty);
            }
            set
            {
                this.SetValue(ViewModeProperty, value);
            }
        }

        /// <summary>
        /// Is called when Views the mode property is changed.
        /// </summary>
        /// <param name="d">The intsance which property changed.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void ViewModePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NavigationPane navi = d as NavigationPane;

            NavigationPaneMode mode = (NavigationPaneMode)e.NewValue;

            if (mode == NavigationPaneMode.TabMode)
            {
                navi.DockItemsPanelVisibility = Visibility.Collapsed;
            }
            else
            {
                navi.DockItemsPanelVisibility = Visibility.Visible;
            }
        }

        #endregion

        #region PanePlacement Property

        /// <summary>
        /// Gets or sets the pane placement.
        /// </summary>
        /// <value>
        /// The pane placement.
        /// </value>
        public Placement PanePlacement
        {
            get
            {
                return (Placement)this.GetValue(PanePlacementProperty);
            }
            set
            {
                this.SetValue(PanePlacementProperty, value);
            }
        }

        #endregion

        #region SettingsButtonVisibility Property

        /// <summary>
        /// Gets or sets the settings button visibility.
        /// </summary>
        /// <value>
        /// The settings button visibility.
        /// </value>
        public Visibility SettingsButtonVisibility
        {
            get { return (Visibility)GetValue(SettingsButtonVisibilityProperty); }
            set { SetValue(SettingsButtonVisibilityProperty, value); }
        }

        #endregion

        #region SettingsMenu property

        /// <summary>
        /// Gets or sets the settings menu.
        /// </summary>
        /// <value>
        /// The settings menu.
        /// </value>
        public ObservableCollection<MenuItem> SettingsMenu
        {
            get
            {
                return (ObservableCollection<MenuItem>)GetValue(SettingsMenuProperty);
            }
            set
            {
                SetValue(SettingsMenuProperty, value);
            }
        }

        /// <summary>
        /// Called when settings menu property changes.
        /// </summary>
        /// <param name="d">The intsance which property changed.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnSettingsMenuPropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NavigationPane pane = d as NavigationPane;

            if (pane.settingsButton == null)
                return;

            Binding binding = new Binding();
            binding.Source = e.NewValue;
            pane.settingsButton.ContextMenu.SetBinding(ContextMenu.ItemsSourceProperty, binding);
        }

        #endregion

        #region SettingsTooltip property

        /// <summary>
        /// Gets or sets the settings tooltip.
        /// </summary>
        /// <value>
        /// The settings tooltip.
        /// </value>
        public object SettingsTooltip
        {
            get { return (object)GetValue(SettingsTooltipProperty); }
            set { SetValue(SettingsTooltipProperty, value); }
        }

        /// <summary>
        /// The field that defines a SettingsTooltip dependency property.
        /// </summary>
        public static readonly DependencyProperty SettingsTooltipProperty =
            DependencyProperty.Register("SettingsTooltip", typeof(object), typeof(NavigationPane), new UIPropertyMetadata(null));

        #endregion

        #region NavigationItemsFixed Property

        /// <summary>
        /// Gets or sets a value indicating whether navigation items are fixed.
        /// </summary>
        /// <value>
        /// Is <c>true</c> if navigation items are fixed; otherwise, <c>false</c>.
        /// </value>
        public bool NavigationItemsFixed
        {
            get { return (bool)GetValue(NavigationItemsFixedProperty); }
            set { SetValue(NavigationItemsFixedProperty, value); }
        }

        #endregion

        #region IsToggleViewChecked Property

        /// <summary>
        /// Gets or sets a value indicating whether toggle view is checked.
        /// </summary>
        /// <value>
        /// Is <c>true</c> if toggle view is checked; otherwise, <c>false</c>.
        /// </value>
        public bool IsToggleViewChecked
        {
            get { return (bool)GetValue(IsToggleViewCheckedProperty); }
            set { SetValue(IsToggleViewCheckedProperty, value); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes static members of the <see cref="NavigationPane"/> class.
        /// </summary>
        static NavigationPane()
        {

            // Overriding the metadata of the native TabControl with our new NavigationPane's metadata
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NavigationPane), new FrameworkPropertyMetadata(typeof(NavigationPane)));

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationPane"/> class.
        /// </summary>
        public NavigationPane()
        {
            SettingsMenu = new ObservableCollection<MenuItem>();
        }

        #endregion

        #region Private Methods/Functions

        /// <summary>
        /// Function to attach all the events to the template parts to Window's Visual Tree.
        /// </summary>
        private void AttachToVisualTree()
        {
            rootPanel = GetChildControl<Grid>(PART_RootPanel); 

            toggleView = GetChildControl<ToggleButton>(PART_ToggleViewButton);

            if (toggleView != null)
            {
                toggleView.Checked += new RoutedEventHandler(OnToggleViewChecked);
                toggleView.Unchecked += new RoutedEventHandler(OnToggleViewUnchecked);
            }

            sidebarButton = GetChildControl<ToggleButton>(PART_SideBarButton);

            if (sidebarButton != null)
            {
                sidebarButton.Checked += new RoutedEventHandler(OnSidebarButtonChecked);
            }

            splitter = GetChildControl<GridSplitter>(PART_HGridSplitter);

            if (splitter != null)
            {
                splitter.DragDelta += new DragDeltaEventHandler(OnSplitterDragDelta);
                splitter.DragCompleted += new DragCompletedEventHandler(splitter_DragCompleted);
            }

            this.SizeChanged += new SizeChangedEventHandler(OnNavigationPaneSizeChanged);

            contentPanel = GetChildControl<Grid>(PART_ContentPanel);
            headerPanel = GetChildControl<StackPanel>(PART_HeaderPanel);
            overflowBar = GetChildControl<ListBox>(PART_OverflowPanel);
            overflowBorder = GetChildControl<Border>(PART_OverflowBorder);       
            moreItemsButton = GetChildControl<ToggleButton>(PART_MoreItemsButton); 
            
            Popup quickView = GetChildControl<Popup>(PART_QuickPopup);

            if (quickView != null)
            {
                quickView.Closed += new EventHandler(OnQuickViewClosed);
                //quickView.Opened += new EventHandler(quickView_Opened);
                //quickView.Closed += new EventHandler(quickView_Closed);
            }

            settingsButton = GetChildControl<Button>(PART_SettingsButton);
            if (settingsButton != null)
            {
                settingsButton.ContextMenu = new ContextMenu();

                Binding binding = new Binding();
                binding.Source = SettingsMenu;
                binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                settingsButton.ContextMenu.SetBinding(ContextMenu.ItemsSourceProperty, binding);

                settingsButton.PreviewMouseDown += new MouseButtonEventHandler(OnSettingsButtonPreviewMouseDown);
            }

            ShowOrHideCollapseHeader();
        }

        /// <summary>
        /// Called when settings button preview mouse down event occurs.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseButtonEventArgs"/> instance containing the event data.</param>
        private void OnSettingsButtonPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Button button = sender as Button;
            if (button == null || button.ContextMenu == null || button.ContextMenu.Items.Count == 0)
                return;

            button.ContextMenu.IsOpen = !button.ContextMenu.IsOpen;
        }

        /// <summary>
        /// Called when quick view is closed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnQuickViewClosed(object sender, EventArgs e)
        {
            byPassSelectedChanged = true;

            int oldSel = SelectedIndex;
            SelectedIndex = -1;
            SelectedIndex = oldSel;

            byPassSelectedChanged = false;
        }

        /// <summary>
        /// Called when splitter is dragged.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.Primitives.DragDeltaEventArgs"/> instance containing the event data.</param>
        private void OnSplitterDragDelta(object sender, DragDeltaEventArgs e)
        {
            ArrangeItems(true);
        }

        /// <summary>
        /// Handles the DragCompleted event of the splitter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.Primitives.DragCompletedEventArgs"/> instance containing the event data.</param>
        void splitter_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            ArrangeItems(true);
        }

        /// <summary>
        /// Handles splitter preview mouse left button up event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseButtonEventArgs"/> instance containing the event data.</param>
        private void OnSplitterPreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released)
            {
                System.Diagnostics.Debug.Print(string.Format("{0} - {1}", contentPanel.ActualHeight.ToString(), headerPanel.ActualHeight.ToString()));
            }
        }


        /// <summary>
        /// Function to get the dependency object given the control name.
        /// </summary>
        /// <typeparam name="T">Type of the object which is to be get.</typeparam>
        /// <param name="ctrlName">Name of the control which is to be get.</param>
        /// <returns>Returns the object of the given control name.</returns>
        private T GetChildControl<T>(string ctrlName) where T : DependencyObject
        {
            T ctrl = GetTemplateChild(ctrlName) as T;
            return ctrl;
        }

        #endregion

        #region Overridden Methods/Functions

        /// <summary>
        /// Determines whether the specified item is <see cref="T:Custom.Windows.Controls.NavigationPaneItem"/>.
        /// </summary>
        /// <param name="item"><see cref="T:Custom.Windows.Controls.NavigationPaneItem"/> as object.</param>
        /// <returns>
        /// Is <c>true</c> if the specified item is <see cref="T:Custom.Windows.Controls.NavigationPaneItem"/>; otherwise, <c>false</c>.
        /// </returns>
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is NavigationPaneItem;
        }

        /// <summary>
        /// Overridden the native <see cref="T:System.Windows.Controls.TabItem"/> to return <see cref="T:Custom.Windows.Controls.NavigationPaneItem"/>.
        /// </summary>
        /// <returns>
        ///   The <see cref="T:Custom.Windows.Controls.NavigationPaneItem"/> object.
        /// </returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new NavigationPaneItem();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Controls.Primitives.Selector.SelectionChanged"/> routed event.
        /// </summary>
        /// <param name="e">Provides data for <see cref="T:System.Windows.Controls.SelectionChangedEventArgs"/>.</param>
        protected override void OnSelectionChanged(System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (byPassSelectedChanged)
                e.Handled = true;

            base.OnSelectionChanged(e);

            ShowOrHideCollapseHeader();

            if (e.AddedItems.Count == 1 && e.AddedItems[0] is NavigationPaneItem)
            {
                NavigationPaneItem item = (NavigationPaneItem)e.AddedItems[0];
                if (null != item.Header)
                {
                    this.Header = item.Header.ToString();
                }
                this.HeaderImage = item.Image;
                item.RaiseActivatedEvent();
            }
        }

        /// <summary>
        /// Called to update the current selection when items change.
        /// </summary>
        /// <param name="e">The event data for the <see cref="E:System.Windows.Controls.ItemContainerGenerator.ItemsChanged"/> event.</param>
        protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);
            if (Items.Count == 0)
            {
                this.Header = string.Empty;
                this.HeaderImage = null;
                this.SelectedItem = null;
            }
        }

        /// <summary>
        /// Called when <see cref="M:System.Windows.FrameworkElement.ApplyTemplate"/> is called.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            AttachToVisualTree();
        }

        /// <summary>
        /// Gets the header toggle button.
        /// </summary>
        /// <returns>Toggle button.</returns>
        internal UIElement GetHeaderToggleButton()
        {
            return sidebarButton;
        }
        #endregion

        #region Public Methods/Functions

        /// <summary>
        /// Expands the pane.
        /// </summary>
        public void ExpandPane()
        {
            IsToggleViewChecked = false;
        }

        /// <summary>
        /// Collapses the pane.
        /// </summary>
        public void CollapsePane()
        {
            IsToggleViewChecked = true;
        }

        /// <summary>
        /// Arranges the items.
        /// </summary>
        /// <param name="splitterResizing">If set to <c>true</c> [splitter resizing].</param>
        public void ArrangeItems(bool splitterResizing)
        {
            if (ViewMode == NavigationPaneMode.TabWithoutHeaderMode || null == rootPanel)
                return;

            int expItems = 0;
            int minItems = 0;
            int colItems = 0;

            bool headerAutosize = rootPanel.RowDefinitions[2].Height.GridUnitType == GridUnitType.Auto;

            var maxItems = Math.Max((int)(headerPanel.MaxHeight / expNavItemHeight), 0);
            if (!splitterResizing && desiredExpItems.HasValue)
                maxItems = Math.Min(maxItems, desiredExpItems.Value);

            var possibleExpItems = headerAutosize || !splitterResizing ? maxItems : Math.Min((int)(rootPanel.RowDefinitions[2].Height.Value / expNavItemHeight), maxItems);
            var possibleMinItems = Math.Max((int)((overflowBorder.ActualWidth - 2) / minNavItemWidth), 0);

            // make room for "more" button
            if (Items.Count - possibleExpItems - possibleMinItems > 0)
                possibleMinItems = (int)(((overflowBorder.ActualWidth - 2) - moreItemsButton.Width) / minNavItemWidth);

            foreach (NavigationPaneItem item in Items)
            {
                if (expItems < possibleExpItems)
                {
                    item.ItemState = NavigationItemState.expanded;
                    expItems++;
                }
                else if (minItems < possibleMinItems)
                {
                    item.ItemState = NavigationItemState.minimized;
                    minItems++;
                }
                else
                {
                    item.ItemState = NavigationItemState.collapsed;
                    colItems++;
                }
            }

            //set height for header or restore auto height 
            rootPanel.RowDefinitions[2].Height = (minItems + colItems == 0) ? new GridLength(0, GridUnitType.Auto) : new GridLength(expItems * expNavItemHeight, GridUnitType.Pixel);

            if (splitterResizing)
            {
                if (minItems + colItems == 0)
                    desiredExpItems = null;
                else
                    desiredExpItems = expItems;
            }

            moreItemsButton.Visibility = colItems > 0 ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
        }

        #endregion

        #region Class Events and Handlers
        double previousWidth = 0;
        /// <summary>
        /// Called when toggle view is unchecked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void OnToggleViewUnchecked(object sender, RoutedEventArgs e)
        {
            if (ExpandClick != null && !byPassToggle)
            {
                ExpandClick(sender, e);
                //sidebarButton.ContentTemplate = null;
            }
        }

        /// <summary>
        /// Called when toggle view is checked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void OnToggleViewChecked(object sender, RoutedEventArgs e)
        {
            if (CollaspeClick != null && !byPassToggle)
            {
                CollaspeClick(sender, e);
                ShowOrHideCollapseHeader();
            }
        }

        /// <summary>
        /// Shows or hides the collapse header.
        /// </summary>
        private void ShowOrHideCollapseHeader()
        {
            NavigationPaneItem item = (NavigationPaneItem)this.SelectedItem;

            if (item != null && null != sidebarButton && sidebarButton.ContentTemplate == null)
            {
                if (item.ShowHeaderContent)
                {
                    //DataTemplate dataTemplateObect = item.CollapseHeaderContent as DataTemplate;
                    //sidebarButton.ContentTemplate = dataTemplateObect;
                    sidebarButton.Content = item.CollapseHeaderContent;
                    sidebarButton.DataContext = item;
                }
                else
                {
                    //sidebarButton.ContentTemplate = null;
                    sidebarButton.Content = item.Header;
                }
            }
        }

        /// <summary>
        /// Called when sidebar button is checked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void OnSidebarButtonChecked(object sender, RoutedEventArgs e)
        {

            ToggleButton owner = (ToggleButton)sender;
            Popup popup = GetChildControl<Popup>(PART_QuickPopup);

            if (popup != null)
            {
                popup.MinWidth = 200;
                popup.MinHeight = owner.ActualWidth + 35;
            }
        }

        /// <summary>
        /// Called when navigation pane size is changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.SizeChangedEventArgs"/> instance containing the event data.</param>
        private void OnNavigationPaneSizeChanged(object sender, SizeChangedEventArgs e)
        {
            ColumnDefinition col = GetChildControl<ColumnDefinition>("ColumnDefinition0");

            if (col != null)
            {
                if (col.ActualWidth <= col.MinWidth + 1)
                {
                    byPassToggle = true;
                    IsToggleViewChecked = true;
                    byPassToggle = false;
                }
                else
                {
                    byPassToggle = true;
                    IsToggleViewChecked = false;
                    byPassToggle = false;
                }
            }
            ArrangeItems(false);
        }

        #endregion

        #region Hiding Properties/Methods/Functions

        /// <summary>
        /// Gets or sets how tab headers align relative to the tab content.
        /// </summary>
        /// <returns>The alignment of tab headers relative to tab content. The default is <see cref="F:System.Windows.Controls.Dock.Top"/>.</returns>
        internal new Dock TabStripPlacement
        {
            get;
            set;
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (toggleView != null)
            {

                toggleView.Checked -= OnToggleViewChecked;
                toggleView.Unchecked -= OnToggleViewUnchecked;
            }

            ToggleButton sidebarButton = GetChildControl<ToggleButton>(PART_SideBarButton);

            if (sidebarButton != null)
            {
                sidebarButton.Checked -= OnSidebarButtonChecked;
            }

            if (splitter != null)
            {
                splitter.DragDelta -= OnSplitterDragDelta;
            }

            this.SizeChanged -= OnNavigationPaneSizeChanged;

            Popup quickView = GetChildControl<Popup>(PART_QuickPopup);

            if (quickView != null)
            {
                quickView.Closed -= new EventHandler(OnQuickViewClosed);
            }

            if (settingsButton != null)
            {
                settingsButton.PreviewMouseDown -= OnSettingsButtonPreviewMouseDown;
            }
        }

        #endregion
    }

    #region FixedNavigationItemsConverter
    /// <summary>
    /// Represents converter for fixed navigation items.
    /// </summary>
    public class FixedNavigationItemsConverter : IMultiValueConverter
    {
        #region IMultiValueConverter Members

        /// <summary>
        /// Converts source values to a value for the binding target. The data binding engine calls this method when it propagates the values from source bindings to the binding target.
        /// </summary>
        /// <param name="values">The array of values that the source bindings in the <see cref="T:System.Windows.Data.MultiBinding"/> produces. The value <see cref="F:System.Windows.DependencyProperty.UnsetValue"/> indicates that the source binding has no value to provide for conversion.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value.If the method returns null, the valid null value is used.A return value of <see cref="T:System.Windows.DependencyProperty"/>.<see cref="F:System.Windows.DependencyProperty.UnsetValue"/> indicates that the converter did not produce a value, and that the binding will use the <see cref="P:System.Windows.Data.BindingBase.FallbackValue"/> if it is available, or else will use the default value.A return value of <see cref="T:System.Windows.Data.Binding"/>.<see cref="F:System.Windows.Data.Binding.DoNothing"/> indicates that the binding does not transfer the value or use the <see cref="P:System.Windows.Data.BindingBase.FallbackValue"/> or the default value.
        /// </returns>
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var dockItemsVisibility = (Visibility)values[0];
            var navItemsFixed = (bool)values[1];
            return navItemsFixed ? Visibility.Collapsed : dockItemsVisibility;
        }

        /// <summary>
        /// Converts a binding target value to the source binding values.
        /// </summary>
        /// <param name="value">The value that the binding target produces.</param>
        /// <param name="targetTypes">The array of types to convert to. The array length indicates the number and types of values that are suggested for the method to return.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// An array of values that have been converted from the target value back to the source values.
        /// </returns>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    #endregion

    #region NavigationHeaderMaxHeightConverter

    /// <summary>
    /// Represents converter for navigation header maximum height.
    /// </summary>
    public class NavHeaderMaxHeightConverter : IValueConverter
    {
        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (double)value - 200;
        }

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    #endregion

    #region NavItemsVisibilityConverter

    /// <summary>
    /// Represents converter for navigation items visibility.
    /// </summary>
    public class NavItemsVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter.ToString() == "minimized")
                return ((NavigationItemState)value) == NavigationItemState.minimized ? Visibility.Visible : Visibility.Collapsed;
            else if (parameter.ToString() == "collapsed")
                return ((NavigationItemState)value) == NavigationItemState.collapsed ? Visibility.Visible : Visibility.Collapsed;
            else
                return null;
        }

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    #endregion
}
