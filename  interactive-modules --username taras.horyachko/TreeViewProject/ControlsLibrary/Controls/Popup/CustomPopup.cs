using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Interop;

namespace ControlsLibrary.Controls
{
    /// <summary>
    /// Represents popup that can be TOPMOST popup.
    /// </summary>
    public class CustomPopup : Popup
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance of EaglePopup is TOPMOST.
        /// </summary>
        /// <value>
        ///   Is <c>true</c> if this instance of EaglePopup is TOPMOST; otherwise, <c>false</c>.
        /// </value>
        public bool NormalizeTopMost
        {
            get { return (bool)GetValue(NormalizeTopMostProperty); }
            set { SetValue(NormalizeTopMostProperty, value); }
        }

        /// <summary>
        /// The field that defines a NormalizeTopMost dependency property.
        /// </summary>
        public static readonly DependencyProperty NormalizeTopMostProperty = DependencyProperty.Register("NormalizeTopMost", typeof(bool), typeof(CustomPopup), new PropertyMetadata(false));

        /// <summary>
        /// Responds to the condition in which the value of the <see cref="P:System.Windows.Controls.Primitives.Popup.IsOpen"/> property changes from false to true.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnOpened(EventArgs e)
        {
            var hwnd = ((HwndSource)PresentationSource.FromVisual(this.Child)).Handle;
            RECT rect;

            if (NormalizeTopMost && GetWindowRect(hwnd, out rect))
            {
                SetWindowPos(hwnd, -2, rect.Left, rect.Top, (int)this.ActualWidth, (int)this.ActualHeight, 0);
            }

            base.OnOpened(e);
        }

        #region Imports

        /// <summary>
        /// The RECT structure defines the coordinates of the upper-left and lower-right corners of a rectangle.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            /// <summary>
            /// The x-coordinate of the upper-left corner of the rectangle.
            /// </summary>
            public int Left;
            /// <summary>
            /// The y-coordinate of the upper-left corner of the rectangle.
            /// </summary>
            public int Top;
            /// <summary>
            /// The x-coordinate of the lower-right corner of the rectangle.
            /// </summary>
            public int Right;
            /// <summary>
            /// The y-coordinate of the lower-right corner of the rectangle.
            /// </summary>
            public int Bottom;
        }

        /// <summary>
        /// Retrieves the dimensions of the bounding rectangle of the specified window. 
        /// </summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="lpRect">A pointer to a RECT structure that receives the screen coordinates of the upper-left and lower-right corners of the window.</param>
        /// <returns>If the function succeeds, the return value is <c>true</c>.If the function fails, the return value is <c>false</c>.</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        /// <summary>
        /// Changes the size, position, and Z order of a child, pop-up, or top-level window.
        /// </summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="hwndInsertAfter">The HWND insert after.</param>
        /// <param name="x">The new position of the left side of the window, in client coordinates.</param>
        /// <param name="y">The new position of the top of the window, in client coordinates.</param>
        /// <param name="cx">The new width of the window, in pixels.</param>
        /// <param name="cy">The new height of the window, in pixels.</param>
        /// <param name="wFlags">The window sizing and positioning flags.</param>
        /// <returns>If the function succeeds, the return value is <c>true</c>.If the function fails, the return value is <c>false</c>.</returns>
        [DllImport("user32", EntryPoint = "SetWindowPos")]
        private static extern int SetWindowPos(IntPtr hWnd, int hwndInsertAfter, int x, int y, int cx, int cy, int wFlags);

        #endregion
    }
}
