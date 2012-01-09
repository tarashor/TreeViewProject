using System.Windows;

namespace ThemesPack
{
    public class CustomResources
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

        private static ComponentResourceKey _borderBrush;
        private static ComponentResourceKey _labelHighlightBrush;
        private static ComponentResourceKey _disabledForegroundBrush;
        private static ComponentResourceKey _darkNormalSolidBrush2;
        private static ComponentResourceKey _pressedSolidBrush;
        private static ComponentResourceKey _tabItemDisabledBackgroundBrush;
        private static ComponentResourceKey _hSplitterBackgroundBrush;
        private static ComponentResourceKey _captionBrush;
        private static ComponentResourceKey _sideBarBackgroundBrush;

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

        public static ResourceKey BorderBrushKey
        {
            get
            {
                if (_borderBrush == null)
                {
                    _borderBrush = new ComponentResourceKey(typeof(CustomResources), CustomResourcesID.BorderBrush);
                }

                return _borderBrush;
            }
        }

        public static ResourceKey LabelHighlightBrushKey
        {
            get
            {
                if (_labelHighlightBrush == null)
                {
                    _labelHighlightBrush = new ComponentResourceKey(typeof(CustomResources), CustomResourcesID.LabelHighlightBrush);
                }

                return _labelHighlightBrush;
            }
        }

        public static ResourceKey DisabledForegroundBrushKey
        {
            get
            {
                if (_disabledForegroundBrush == null)
                {
                    _disabledForegroundBrush = new ComponentResourceKey(typeof(CustomResources), CustomResourcesID.DisabledForegroundBrush);
                }

                return _disabledForegroundBrush;
            }
        }

        public static ResourceKey DarkNormalSolidBrush2Key
        {
            get
            {
                if (_darkNormalSolidBrush2 == null)
                {
                    _darkNormalSolidBrush2 = new ComponentResourceKey(typeof(CustomResources), CustomResourcesID.DarkNormalSolidBrush2);
                }

                return _darkNormalSolidBrush2;
            }
        }

        public static ResourceKey PressedSolidBrushKey
        {
            get
            {
                if (_pressedSolidBrush == null)
                {
                    _pressedSolidBrush = new ComponentResourceKey(typeof(CustomResources), CustomResourcesID.PressedSolidBrush);
                }

                return _pressedSolidBrush;
            }
        }

        public static ResourceKey TabItemDisabledBackgroundBrushKey
        {
            get
            {
                if (_tabItemDisabledBackgroundBrush == null)
                {
                    _tabItemDisabledBackgroundBrush = new ComponentResourceKey(typeof(CustomResources), CustomResourcesID.TabItemDisabledBackgroundBrush);
                }

                return _tabItemDisabledBackgroundBrush;
            }
        }

        public static ResourceKey SideBarBackgroundBrushKey
        {
            get
            {
                if (_sideBarBackgroundBrush == null)
                {
                    _sideBarBackgroundBrush = new ComponentResourceKey(typeof(CustomResources), CustomResourcesID.SideBarBackgroundBrush);
                }

                return _sideBarBackgroundBrush;
            }
        }

        public static ResourceKey HSplitterBackgroundBrushKey
        {
            get
            {
                if (_hSplitterBackgroundBrush == null)
                {
                    _hSplitterBackgroundBrush = new ComponentResourceKey(typeof(CustomResources), CustomResourcesID.HSplitterBackgroundBrush);
                }

                return _hSplitterBackgroundBrush;
            }
        }

        public static ResourceKey CaptionBrushKey
        {
            get
            {
                if (_captionBrush == null)
                {
                    _captionBrush = new ComponentResourceKey(typeof(CustomResources), CustomResourcesID.CaptionBrush);
                }

                return _captionBrush;
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

        BorderBrush,
        LabelHighlightBrush,
        DisabledForegroundBrush,
        DarkNormalSolidBrush2,
        PressedSolidBrush,
        TabItemDisabledBackgroundBrush,
        SideBarBackgroundBrush,
        HSplitterBackgroundBrush,
        CaptionBrush
    }
}
