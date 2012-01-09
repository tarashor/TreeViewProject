//------------------------------------------------------------------------------------------------- 
// <copyright file="NavigationPaneItem.cs" company="Eagle Investment Systems LLC.">
// Copyright (c) Eagle Investment Systems LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the NavigationPaneItem class.
// </summary>
//------------------------------------------------------------------------------------------------- 

namespace ControlsLibrary.Controls
{

    #region Namespace Imports

    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Media;

    #endregion

    /// <summary>
    /// Class that represent Eagle.Windows.Controls.NavigationPaneItem .
    /// </summary>
    [ToolboxItem(false), DesignTimeVisible(true)]
    public class NavigationPaneItem : System.Windows.Controls.TabItem
    {

        #region Declarations

        /// <summary>
        /// The field that defines a Image dependency property.
        /// </summary>
        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register("Image", typeof(ImageSource), typeof(NavigationPaneItem));

        /// <summary>
        /// The field that defines a ItemState dependency property.
        /// </summary>
        public static readonly DependencyProperty ItemStateProperty = DependencyProperty.Register("ItemState", typeof(NavigationItemState), typeof(NavigationPaneItem));

        /// <summary>
        /// The field that defines a ItemIndex dependency property.
        /// </summary>
        public static readonly DependencyProperty ItemIndexProperty = DependencyProperty.Register("ItemIndex", typeof(int), typeof(NavigationPaneItem));

        /// <summary>
        /// The field that defines a CollapseHeaderContent dependency property.
        /// </summary>
        public static readonly DependencyProperty CollapseHeaderContentProperty = DependencyProperty.Register("CollapseHeaderContent", typeof(object), typeof(NavigationPaneItem));

        /// <summary>
        /// The field that defines a ShowHeaderTemplate dependency property.
        /// </summary>
        public static readonly DependencyProperty ShowHeaderTemplateProperty = DependencyProperty.Register("ShowHeaderTemplate", typeof(bool), typeof(NavigationPaneItem));

        /// <summary>
        /// The field that defines a IsBusinessElementNavigationItem dependency property.
        /// </summary>
        public static readonly DependencyProperty IsBusinessElementNavigationItemProperty = DependencyProperty.Register("IsBusinessElementNavigationItem", typeof(bool), typeof(NavigationPaneItem), new PropertyMetadata(false));
        
        /// <summary>
        /// Identifies the Eagle.Windows.Controls.NavigationPane.ViewModeProperty property.
        /// </summary>
        public static DependencyProperty ViewModeProperty = DependencyProperty.Register("ViewMode", typeof(NavigationPane.NavigationPaneMode),
                typeof(NavigationPaneItem), new UIPropertyMetadata(NavigationPane.NavigationPaneMode.PaneMode));

        #endregion

        #region Image Property

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        public ImageSource Image
        {
            get
            {
                return (ImageSource)GetValue(ImageProperty);
            }
            set
            {
                SetValue(ImageProperty, value);
            }
        }

        #endregion

        #region ItemState Property

        /// <summary>
        /// Gets or sets the state of the item.
        /// </summary>
        /// <value>
        /// The state of the item.
        /// </value>
        public NavigationItemState ItemState
        {
            get
            {
                return (NavigationItemState)GetValue(ItemStateProperty);
            }
            set
            {
                SetValue(ItemStateProperty, value);
            }
        }

        #endregion

        #region ItemIndex Property

        /// <summary>
        /// Gets or sets the index of the item.
        /// </summary>
        /// <value>
        /// The index of the item.
        /// </value>
        public int ItemIndex
        {
            get
            {
                return (int)GetValue(ItemIndexProperty);
            }
            set
            {
                SetValue(ItemIndexProperty, value);
            }
        }

        #endregion

        #region ViewMode Property

        /// <summary>
        /// Gets the view mode.
        /// </summary>
        /// <value>
        /// The view mode.
        /// </value>
        public NavigationPane.NavigationPaneMode ViewMode
        {
            get
            {                
                return  (NavigationPane.NavigationPaneMode)GetValue(ViewModeProperty);
            }
            internal set
            {
                SetValue(ViewModeProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the content of the collapsed header.
        /// </summary>
        /// <value>
        /// The content of the collapsed header.
        /// </value>
        public object CollapseHeaderContent
        {
            get
            {
                return (object)GetValue(CollapseHeaderContentProperty);
            }
            set
            {
                SetValue(CollapseHeaderContentProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether header content is shown.
        /// </summary>
        /// <value>
        /// Is <c>true</c> if header content is shown; otherwise, <c>false</c>.
        /// </value>
        public bool ShowHeaderContent
        {
            get
            {
                return (bool)GetValue(ShowHeaderTemplateProperty);
            }
            set
            {
                SetValue(ShowHeaderTemplateProperty, value);
            }
        }
        #endregion

        #region IsBusinessElementNavigationItem Property

        /// <summary>
        /// Gets or sets a value indicating whether this instance is business element navigation item.
        /// </summary>
        /// <value>
        /// Is <c>true</c> if this instance is business element navigation item; otherwise, <c>false</c>.
        /// </value>
        public bool IsBusinessElementNavigationItem
        {
            get
            {
                return (bool)GetValue(IsBusinessElementNavigationItemProperty);
            }
            set
            {
                SetValue(IsBusinessElementNavigationItemProperty, value);
            }
        }

        #endregion


        #region Activated Event

        /// <summary>
        /// Fires when navigation pane item is activated.
        /// </summary>
        public static readonly RoutedEvent ActivatedEvent = EventManager.RegisterRoutedEvent("Activated", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(NavigationPaneItem));

        /// <summary>
        /// Activated event fires when the Activated command is performed.
        /// </summary>
        public event RoutedEventHandler Activated
        {
            add
            {
                base.AddHandler(ActivatedEvent, value);
            }
            remove
            {
                base.RemoveHandler(ActivatedEvent, value);
            }
        }

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes static members of the <see cref="NavigationPaneItem"/> class.
        /// </summary>
        static NavigationPaneItem()
        {

            DefaultStyleKeyProperty.OverrideMetadata(typeof(NavigationPaneItem), new FrameworkPropertyMetadata(typeof(NavigationPaneItem)));

        }

        #endregion
        
        #region Overriden Methods/functions

        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or internal processes call <see cref="M:System.Windows.FrameworkElement.ApplyTemplate"/>.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            AttachToVisualTree();
         
        }
        #endregion

        #region Private Methods/functions

        /// <summary>
        /// Attaches to visual tree.
        /// </summary>
        private void AttachToVisualTree()
        {
            NavigationPane np = GetParentNavigationPane();

            if (np == null)
            {
                ItemIndex = -1;
                return;
            }

            ItemIndex = np.Items.IndexOf(this);            
        }

        /// <summary>
        /// Gets the parent navigation pane.
        /// </summary>
        /// <returns>Navigation pane.</returns>
        private NavigationPane GetParentNavigationPane()
        {
            NavigationPane np = this.Parent as NavigationPane;

            return np;
        }

        /// <summary>
        /// Raises the activated event.
        /// </summary>
        internal void RaiseActivatedEvent()
        {
            RoutedEventArgs args = new RoutedEventArgs(NavigationPaneItem.ActivatedEvent, this);
            this.RaiseEvent(args);
        }

        #endregion

        #region Public Methods/Functions

        /// <summary>
        /// Gets the header content.
        /// </summary>
        /// <returns>The content of the header.</returns>
        public UIElement GetHeaderContentControl()
        {
            NavigationPane pane = this.Parent as NavigationPane;

            if (pane == null)
                return null;

            return pane.GetHeaderToggleButton();
        }

        #endregion

    }

    /// <summary>
    /// Represents navigation item state.
    /// </summary>
    public enum NavigationItemState
    {
        /// <summary>
        /// This field represents expanded state.
        /// </summary>
        expanded,
        
        /// <summary>
        /// This field represents minimized state.
        /// </summary>
        minimized,
        
        /// <summary>
        /// This field represents collapsed state.
        /// </summary>
        collapsed
    }
}
