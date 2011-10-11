using System.Windows;

namespace ThemesPack
{
    public static class CustomResources
    {
        #region Brushes
        
        private static ComponentResourceKey _inverseBorderBrush;
        private static ComponentResourceKey _normalGradientBrush;
        private static ComponentResourceKey _inverseNormalGradientBrush;
        private static ComponentResourceKey _buttonNormalBrush;
        private static ComponentResourceKey _buttonSelectedBrush;
        private static ComponentResourceKey _buttonPressedBrush;
        private static ComponentResourceKey _buttonHoverBrush;
        private static ComponentResourceKey _buttonDarkBrush;
        private static ComponentResourceKey _buttonGreenBrush;
        private static ComponentResourceKey _buttonDarkHoverBrush;
        private static ComponentResourceKey _backgroundGradientBrush;
        private static ComponentResourceKey _hoverGradientBrush;

        #endregion

        #region Styles

        private static ComponentResourceKey _buttonWithBorderGlowTemplate;
        private static ComponentResourceKey _normalButtonStyle;
        private static ComponentResourceKey _buttonFocusVisual;
        private static ComponentResourceKey _buttonScaleTransform;

        #endregion
        

        public static ResourceKey InverseBorderBrushKey
        {
            get
            {
                if (_inverseBorderBrush == null)
                {
                    _inverseBorderBrush = new ComponentResourceKey(typeof(CustomResources), CustomResourcesID.InverseBorderBrush);
                }

                return _inverseBorderBrush;
            }
        }

        public static ResourceKey NormalGradientBrushKey
        {
            get
            {
                if (_normalGradientBrush == null)
                {
                    _normalGradientBrush = new ComponentResourceKey(typeof(CustomResources), CustomResourcesID.NormalGradientBrush);
                }

                return _normalGradientBrush;
            }
        }

        public static ResourceKey InverseNormalGradientBrushKey
        {
            get
            {
                if (_inverseNormalGradientBrush == null)
                {
                    _inverseNormalGradientBrush = new ComponentResourceKey(typeof(CustomResources), CustomResourcesID.InverseNormalGradientBrush);
                }

                return _inverseNormalGradientBrush;
            }
        }

        public static ResourceKey ButtonNormalBrushKey
        {
            get
            {
                if (_buttonNormalBrush == null)
                {
                    _buttonNormalBrush = new ComponentResourceKey(typeof(CustomResources), CustomResourcesID.ButtonNormalBrush);
                }

                return _buttonNormalBrush;
            }
        }

        public static ResourceKey ButtonSelectedBrushKey
        {
            get
            {
                if (_buttonSelectedBrush == null)
                {
                    _buttonSelectedBrush = new ComponentResourceKey(typeof(CustomResources), CustomResourcesID.ButtonSelectedBrush);
                }

                return _buttonSelectedBrush;
            }
        }

        public static ResourceKey ButtonPressedBrushKey
        {
            get
            {
                if (_buttonPressedBrush == null)
                {
                    _buttonPressedBrush = new ComponentResourceKey(typeof(CustomResources), CustomResourcesID.ButtonPressedBrush);
                }

                return _buttonPressedBrush;
            }
        }

        public static ResourceKey ButtonHoverBrushKey
        {
            get
            {
                if (_buttonHoverBrush == null)
                {
                    _buttonHoverBrush = new ComponentResourceKey(typeof(CustomResources), CustomResourcesID.ButtonHoverBrush);
                }

                return _buttonHoverBrush;
            }
        }

        public static ResourceKey ButtonDarkBrushKey
        {
            get
            {
                if (_buttonDarkBrush == null)
                {
                    _buttonDarkBrush = new ComponentResourceKey(typeof(CustomResources), CustomResourcesID.ButtonDarkBrush);
                }

                return _buttonDarkBrush;
            }
        }

        public static ResourceKey ButtonGreenBrushKey
        {
            get
            {
                if (_buttonGreenBrush == null)
                {
                    _buttonGreenBrush = new ComponentResourceKey(typeof(CustomResources), CustomResourcesID.ButtonGreenBrush);
                }

                return _buttonGreenBrush;
            }
        }

        public static ResourceKey ButtonDarkHoverBrushKey
        {
            get
            {
                if (_buttonDarkHoverBrush == null)
                {
                    _buttonDarkHoverBrush = new ComponentResourceKey(typeof(CustomResources), CustomResourcesID.ButtonDarkHoverBrush);
                }

                return _buttonDarkHoverBrush;
            }
        }

        public static ResourceKey BackgroundGradientBrushKey
        {
            get
            {
                if (_backgroundGradientBrush == null)
                {
                    _backgroundGradientBrush = new ComponentResourceKey(typeof(CustomResources), CustomResourcesID.BackgroundGradientBrush);
                }

                return _backgroundGradientBrush;
            }
        }

        public static ResourceKey HoverGradientBrushKey
        {
            get
            {
                if (_hoverGradientBrush == null)
                {
                    _hoverGradientBrush = new ComponentResourceKey(typeof(CustomResources), CustomResourcesID.HoverGradientBrush);
                }

                return _hoverGradientBrush;
            }
        }

        public static ResourceKey ButtonWithBorderGlowTemplateKey
        {
            get
            {
                if (_buttonWithBorderGlowTemplate == null)
                {
                    _buttonWithBorderGlowTemplate = new ComponentResourceKey(typeof(CustomResources), CustomResourcesID.ButtonWithBorderGlowTemplate);
                }

                return _buttonWithBorderGlowTemplate;
            }
        }

        public static ResourceKey NormalButtonStyleKey
        {
            get
            {
                if (_normalButtonStyle == null)
                {
                    _normalButtonStyle = new ComponentResourceKey(typeof(CustomResources), CustomResourcesID.NormalButtonStyle);
                }

                return _normalButtonStyle;
            }
        }

        public static ResourceKey ButtonFocusVisualKey
        {
            get
            {
                if (_buttonFocusVisual == null)
                {
                    _buttonFocusVisual = new ComponentResourceKey(typeof(CustomResources), CustomResourcesID.ButtonFocusVisual);
                }

                return _buttonFocusVisual;
            }
        }

        public static ResourceKey ButtonScaleTransformKey
        {
            get
            {
                if (_buttonScaleTransform == null)
                {
                    _buttonScaleTransform = new ComponentResourceKey(typeof(CustomResources), CustomResourcesID.ButtonScaleTransform);
                }

                return _buttonScaleTransform;
            }
        }
    }

    internal enum CustomResourcesID
    {
        InverseBorderBrush,
        //Gradient Color Brush
        NormalGradientBrush,
        InverseNormalGradientBrush,
        ButtonNormalBrush,
        ButtonSelectedBrush,
        ButtonPressedBrush,
        ButtonGreenBrush,
        ButtonHoverBrush,
        ButtonDarkBrush,
        ButtonDarkHoverBrush,
        ButtonNormalBackgroundBrush,

        BackgroundGradientBrush,
        HoverGradientBrush,

        //Styles
        ButtonWithBorderGlowTemplate,
        NormalButtonStyle,
        //Visuals
        ButtonFocusVisual,
        ButtonScaleTransform,

        
    }
}
