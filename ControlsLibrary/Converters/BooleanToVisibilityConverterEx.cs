using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ControlsLibrary.Converters
{
    /// <summary>
    /// Represents the class that converts boolean value to the <see cref="T:System.Windows.Visibility"/> object with multi options.
    /// </summary>
    public class BooleanToVisibilityConverterEx : IValueConverter
    {
        /// <summary>
        /// Defines the Inverted property.
        /// </summary>
        private bool _inverted = false;


        /// <summary>
        /// Gets or sets a value indicating whether to invert converter opeartion.
        /// </summary>
        /// <value>
        ///   Is <c>true</c> if to invert converter opeartion; otherwise, <c>false</c>.
        /// </value>
        public bool Inverted
        {
            get { return _inverted; }
            set { _inverted = value; }
        }

        /// <summary>
        /// Defines the Not property.
        /// </summary>
        private bool _not = false;


        /// <summary>
        /// Gets or sets a value indicating whether to invert boolean value.
        /// </summary>
        /// <value>
        ///   Is <c>true</c> if to invert boolean value; otherwise, <c>false</c>.
        /// </value>
        public bool Not
        {
            get { return _not; }
            set { _not = value; }
        }

        /// <summary>
        /// Defines the InvisibleType property.
        /// </summary>
        private Visibility _invisibleType = Visibility.Collapsed;


        /// <summary>
        /// Gets or sets the type of the invisible.
        /// </summary>
        /// <value>
        /// The type of the invisible.
        /// </value>
        public Visibility InvisibleType
        {
            get { return _invisibleType; }
            set { _invisibleType = value; }
        }

        /// <summary>
        /// Converts the <see cref="T:System.Windows.Visibility"/> object to boolean value.
        /// </summary>
        /// <param name="value">The <see cref="T:System.Windows.Visibility"/> value.</param>
        /// <returns>The boolean value.</returns>
        private object VisibilityToBool(object value)
        {
            if (!(value is Visibility))
            {
                return DependencyProperty.UnsetValue;
            }
            return (((Visibility)value) == Visibility.Visible) ^ Not;
        }

        /// <summary>
        /// Converts the boolean value to <see cref="T:System.Windows.Visibility"/> object.
        /// </summary>
        /// <param name="value">The boolean value.</param>
        /// <returns>The <see cref="T:System.Windows.Visibility"/> object.</returns>
        private object BoolToVisibility(object value)
        {
            if (!(value is bool))
            {
                return DependencyProperty.UnsetValue;
            }
            return ((bool)value ^ Not) ? Visibility.Visible : InvisibleType;
        }

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
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Inverted ? BoolToVisibility(value) : VisibilityToBool(value);
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
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Inverted ? VisibilityToBool(value) : BoolToVisibility(value);
        }
    }
}
