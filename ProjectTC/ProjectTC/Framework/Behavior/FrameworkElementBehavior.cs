using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Framework.Behavior
{
    public class FrameworkElementBehavior
    {
        #region MouseUp

        public static readonly DependencyProperty MouseUpCommandProperty = DependencyProperty.RegisterAttached("MouseUpCommand", typeof(ICommand), typeof(FrameworkElementBehavior), new FrameworkPropertyMetadata(new PropertyChangedCallback(MouseUpCommandChanged)));
        private static void MouseUpCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)d;
            element.MouseUp += element_MouseUp;
        }

        static void element_MouseUp(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)sender;
            ICommand cmd = GetMouseUpCommand(element);
            cmd.Execute(e);
        }

        public static void SetMouseUpCommand(UIElement element, ICommand value)
        {
            element.SetValue(MouseUpCommandProperty, value);
        }

        public static ICommand GetMouseUpCommand(UIElement element)
        {
            return (ICommand)element.GetValue(MouseUpCommandProperty);
        }

        #endregion

        #region MouserDown

        public static readonly DependencyProperty MouseDownCommandProperty = DependencyProperty.RegisterAttached("MouseDownCommand", typeof(ICommand), typeof(FrameworkElementBehavior), new FrameworkPropertyMetadata(new PropertyChangedCallback(MouseDownCommandChanged)));
        private static void MouseDownCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)d;
            element.MouseDown += element_MouseDown;
        }

        static void element_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)sender;
            ICommand cmd = GetMouseDownCommand(element);
            cmd.Execute(e);
        }

        public static void SetMouseDownCommand(UIElement element, ICommand value)
        {
            element.SetValue(MouseDownCommandProperty, value);
        }

        public static ICommand GetMouseDownCommand(UIElement element)
        {
            return (ICommand)element.GetValue(MouseDownCommandProperty);
        }

        #endregion

        #region MouseLeave

        public static readonly DependencyProperty MouseLeaveCommandProperty = DependencyProperty.RegisterAttached("MouseLeaveCommand", typeof(ICommand), typeof(FrameworkElementBehavior), new FrameworkPropertyMetadata(new PropertyChangedCallback(MouseLeaveCommandChanged)));
        private static void MouseLeaveCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)d;
            element.MouseLeave += new MouseEventHandler(element_MouseLeave);
        }

        static void element_MouseLeave(object sender, MouseEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)sender;
            ICommand cmd = GetMouseLeaveCommand(element);

            if (null != cmd)
                cmd.Execute(e);
        }

        public static void SetMouseLeaveCommand(UIElement element, ICommand value)
        {
            element.SetValue(MouseLeaveCommandProperty, value);
        }

        public static ICommand GetMouseLeaveCommand(UIElement element)
        {
            return (ICommand)element.GetValue(MouseLeaveCommandProperty);
        }

        #endregion

        #region MouseEnter

        public static readonly DependencyProperty MouseEnterCommandProperty = DependencyProperty.RegisterAttached("MouseEnterCommand", typeof(ICommand), typeof(FrameworkElementBehavior), new FrameworkPropertyMetadata(new PropertyChangedCallback(MouseEnterCommandChanged)));
        private static void MouseEnterCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)d;
            element.MouseEnter += new MouseEventHandler(element_MouseEnter);
        }

        static void element_MouseEnter(object sender, MouseEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)sender;
            ICommand cmd = GetMouseEnterCommand(element);
            if (null != cmd)
                cmd.Execute(e);
        }

        public static void SetMouseEnterCommand(UIElement element, ICommand value)
        {
            element.SetValue(MouseEnterCommandProperty, value);
        }

        public static ICommand GetMouseEnterCommand(UIElement element)
        {
            return (ICommand)element.GetValue(MouseEnterCommandProperty);
        }

        #endregion

        #region MouseLeftButtonDown

        public static readonly DependencyProperty MouseLeftButtonDownCommandProperty = DependencyProperty.RegisterAttached("MouseLeftButtonDownCommand", typeof(ICommand), typeof(FrameworkElementBehavior), new FrameworkPropertyMetadata(new PropertyChangedCallback(MouseLeftButtonDownCommandChanged)));
        private static void MouseLeftButtonDownCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)d;
            element.MouseLeftButtonDown += element_MouseLeftButtonDown;
        }

        static void element_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)sender;
            ICommand cmd = GetMouseLeftButtonDownCommand(element);
            cmd.Execute(e);
        }

        public static void SetMouseLeftButtonDownCommand(UIElement element, ICommand value)
        {
            element.SetValue(MouseLeftButtonDownCommandProperty, value);
        }

        public static ICommand GetMouseLeftButtonDownCommand(UIElement element)
        {
            return (ICommand)element.GetValue(MouseLeftButtonDownCommandProperty);
        }

        #endregion

        #region MouseLeftButtonUp

        public static readonly DependencyProperty MouseLeftButtonUpCommandProperty = DependencyProperty.RegisterAttached("MouseLeftButtonUpCommand", typeof(ICommand), typeof(FrameworkElementBehavior), new FrameworkPropertyMetadata(new PropertyChangedCallback(MouseLeftButtonUpCommandChanged)));
        private static void MouseLeftButtonUpCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)d;
            element.MouseLeftButtonUp += element_MouseLeftButtonUp;
        }

        static void element_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)sender;
            ICommand cmd = GetMouseLeftButtonUpCommand(element);
            cmd.Execute(e);
        }

        public static void SetMouseLeftButtonUpCommand(UIElement element, ICommand value)
        {
            element.SetValue(MouseLeftButtonUpCommandProperty, value);
        }

        public static ICommand GetMouseLeftButtonUpCommand(UIElement element)
        {
            return (ICommand)element.GetValue(MouseLeftButtonUpCommandProperty);
        }

        #endregion

        #region MouseMove

        public static readonly DependencyProperty MouseMoveCommandProperty = DependencyProperty.RegisterAttached("MouseMoveCommand", typeof(ICommand), typeof(FrameworkElementBehavior), new FrameworkPropertyMetadata(new PropertyChangedCallback(MouseMoveCommandChanged)));
        private static void MouseMoveCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)d;
            element.MouseMove += new MouseEventHandler(element_MouseMove);
        }

        static void element_MouseMove(object sender, MouseEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)sender;
            ICommand cmd = GetMouseMoveCommand(element);
            cmd.Execute(e);
        }

        public static void SetMouseMoveCommand(UIElement element, ICommand value)
        {
            element.SetValue(MouseMoveCommandProperty, value);
        }

        public static ICommand GetMouseMoveCommand(UIElement element)
        {
            return (ICommand)element.GetValue(MouseMoveCommandProperty);
        }

        #endregion

        #region MouseRightButtonDown

        public static readonly DependencyProperty MouseRightButtonDownCommandProperty = DependencyProperty.RegisterAttached("MouseRightButtonDownCommand", typeof(ICommand), typeof(FrameworkElementBehavior), new FrameworkPropertyMetadata(new PropertyChangedCallback(MouseRightButtonDownCommandChanged)));
        private static void MouseRightButtonDownCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)d;
            element.MouseRightButtonDown += element_MouseRightButtonDown;
        }

        static void element_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)sender;
            ICommand cmd = GetMouseRightButtonDownCommand(element);
            cmd.Execute(e);
        }

        public static void SetMouseRightButtonDownCommand(UIElement element, ICommand value)
        {
            element.SetValue(MouseRightButtonDownCommandProperty, value);
        }

        public static ICommand GetMouseRightButtonDownCommand(UIElement element)
        {
            return (ICommand)element.GetValue(MouseRightButtonDownCommandProperty);
        }

        #endregion

        #region MouseRightButtonUp

        public static readonly DependencyProperty MouseRightButtonUpCommandProperty = DependencyProperty.RegisterAttached("MouseRightButtonUpCommand", typeof(ICommand), typeof(FrameworkElementBehavior), new FrameworkPropertyMetadata(new PropertyChangedCallback(MouseRightButtonUpCommandChanged)));

        private static void MouseRightButtonUpCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)d;
            element.MouseRightButtonUp += element_MouseRightButtonUp;
        }

        static void element_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)sender;
            ICommand cmd = GetMouseRightButtonUpCommand(element);
            cmd.Execute(e);
        }

        public static void SetMouseRightButtonUpCommand(UIElement element, ICommand value)
        {
            element.SetValue(MouseRightButtonUpCommandProperty, value);
        }

        public static ICommand GetMouseRightButtonUpCommand(UIElement element)
        {
            return (ICommand)element.GetValue(MouseRightButtonUpCommandProperty);
        }

        #endregion

        #region MouseWheel

        public static readonly DependencyProperty MouseWheelCommandProperty = DependencyProperty.RegisterAttached("MouseWheelCommand", typeof(ICommand), typeof(FrameworkElementBehavior), new FrameworkPropertyMetadata(new PropertyChangedCallback(MouseWheelCommandChanged)));
        private static void MouseWheelCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)d;
            element.MouseWheel += new MouseWheelEventHandler(element_MouseWheel);
        }

        static void element_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)sender;
            ICommand cmd = GetMouseWheelCommand(element);
            cmd.Execute(e);
        }

        public static void SetMouseWheelCommand(UIElement element, ICommand value)
        {
            element.SetValue(MouseWheelCommandProperty, value);
        }

        public static ICommand GetMouseWheelCommand(UIElement element)
        {
            return (ICommand)element.GetValue(MouseWheelCommandProperty);
        }

        #endregion

        #region PreviewMouseDown

        public static readonly DependencyProperty PreviewMouseDownCommandProperty = DependencyProperty.RegisterAttached("PreviewMouseDownCommand", typeof(ICommand), typeof(FrameworkElementBehavior), new FrameworkPropertyMetadata(new PropertyChangedCallback(PreviewMouseDownCommandChanged)));
        private static void PreviewMouseDownCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)d;
            element.PreviewMouseDown += element_PreviewMouseDown;
        }

        static void element_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)sender;
            ICommand cmd = GetPreviewMouseDownCommand(element);
            cmd.Execute(e);
        }

        public static void SetPreviewMouseDownCommand(UIElement element, ICommand value)
        {
            element.SetValue(PreviewMouseDownCommandProperty, value);
        }

        public static ICommand GetPreviewMouseDownCommand(UIElement element)
        {
            return (ICommand)element.GetValue(PreviewMouseDownCommandProperty);
        }

        #endregion

        #region PreviewMouseLeftButtonDown

        public static readonly DependencyProperty PreviewMouseLeftButtonDownCommandProperty = DependencyProperty.RegisterAttached("PreviewMouseLeftButtonDownCommand", typeof(ICommand), typeof(FrameworkElementBehavior), new FrameworkPropertyMetadata(new PropertyChangedCallback(PreviewMouseLeftButtonDownCommandChanged)));
        private static void PreviewMouseLeftButtonDownCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)d;
            element.PreviewMouseLeftButtonDown += element_PreviewMouseLeftButtonDown;
        }

        static void element_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)sender;
            ICommand cmd = GetPreviewMouseLeftButtonDownCommand(element);
            cmd.Execute(e);
        }

        public static void SetPreviewMouseLeftButtonDownCommand(UIElement element, ICommand value)
        {
            element.SetValue(PreviewMouseLeftButtonDownCommandProperty, value);
        }

        public static ICommand GetPreviewMouseLeftButtonDownCommand(UIElement element)
        {
            return (ICommand)element.GetValue(PreviewMouseLeftButtonDownCommandProperty);
        }

        #endregion

        #region PreviewMouseLeftButtonUp

        public static readonly DependencyProperty PreviewMouseLeftButtonUpCommandProperty = DependencyProperty.RegisterAttached("PreviewMouseLeftButtonUpCommand", typeof(ICommand), typeof(FrameworkElementBehavior), new FrameworkPropertyMetadata(new PropertyChangedCallback(PreviewMouseLeftButtonUpCommandChanged)));
        private static void PreviewMouseLeftButtonUpCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)d;
            element.PreviewMouseLeftButtonUp += element_PreviewMouseLeftButtonUp;
        }

        static void element_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)sender;
            ICommand cmd = GetPreviewMouseLeftButtonUpCommand(element);
            cmd.Execute(e);
        }

        public static void SetPreviewMouseLeftButtonUpCommand(UIElement element, ICommand value)
        {
            element.SetValue(PreviewMouseLeftButtonUpCommandProperty, value);
        }

        public static ICommand GetPreviewMouseLeftButtonUpCommand(UIElement element)
        {
            return (ICommand)element.GetValue(PreviewMouseLeftButtonUpCommandProperty);
        }

        #endregion

        #region PreviewMouseMove

        public static readonly DependencyProperty PreviewMouseMoveCommandProperty = DependencyProperty.RegisterAttached("PreviewMouseMoveCommand", typeof(ICommand), typeof(FrameworkElementBehavior), new FrameworkPropertyMetadata(new PropertyChangedCallback(PreviewMouseMoveCommandChanged)));
        private static void PreviewMouseMoveCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)d;
            element.PreviewMouseMove += new MouseEventHandler(element_PreviewMouseMove);
        }

        static void element_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)sender;
            ICommand cmd = GetPreviewMouseMoveCommand(element);

            cmd.Execute(e);
        }

        public static void SetPreviewMouseMoveCommand(UIElement element, ICommand value)
        {
            element.SetValue(PreviewMouseMoveCommandProperty, value);
        }

        public static ICommand GetPreviewMouseMoveCommand(UIElement element)
        {
            return (ICommand)element.GetValue(PreviewMouseMoveCommandProperty);
        }

        #endregion

        #region PreviewMouseWheel

        public static readonly DependencyProperty PreviewMouseWheelCommandProperty = DependencyProperty.RegisterAttached("PreviewMouseWheelCommand", typeof(ICommand), typeof(FrameworkElementBehavior), new FrameworkPropertyMetadata(new PropertyChangedCallback(PreviewMouseWheelCommandChanged)));
        private static void PreviewMouseWheelCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)d;
            element.PreviewMouseWheel += element_PreviewMouseWheel;
        }

        static void element_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)sender;
            ICommand cmd = GetPreviewMouseWheelCommand(element);
            cmd.Execute(e);
        }

        public static void SetPreviewMouseWheelCommand(UIElement element, ICommand value)
        {
            element.SetValue(PreviewMouseWheelCommandProperty, value);
        }

        public static ICommand GetPreviewMouseWheelCommand(UIElement element)
        {
            return (ICommand)element.GetValue(PreviewMouseWheelCommandProperty);
        }

        #endregion

        #region LostFocus

        public static readonly DependencyProperty LostFocusCommandProperty = DependencyProperty.RegisterAttached("LostFocusCommand", typeof(ICommand), typeof(FrameworkElementBehavior), new FrameworkPropertyMetadata(new PropertyChangedCallback(LostFocusCommandChanged)));

        private static void LostFocusCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)d;
            element.LostFocus += element_LostFocus;
        }

        static void element_LostFocus(object sender, RoutedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)sender;
            ICommand cmd = GetLostFocusCommand(element);
            cmd.Execute(e);
        }

        public static void SetLostFocusCommand(UIElement element, ICommand value)
        {
            element.SetValue(LostFocusCommandProperty, value);
        }

        public static ICommand GetLostFocusCommand(UIElement element)
        {
            return (ICommand)element.GetValue(LostFocusCommandProperty);
        }

        #endregion

        #region LostFocusKeyboard

        public static readonly DependencyProperty LostKeyboardFocusCommandProperty = DependencyProperty.RegisterAttached("LostKeyboardFocusCommand", typeof(ICommand), typeof(FrameworkElementBehavior), new FrameworkPropertyMetadata(new PropertyChangedCallback(LostKeyboardFocusCommandChanged)));

        private static void LostKeyboardFocusCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)d;
            element.LostKeyboardFocus += element_LostKeyboardFocus;
        }

        static void element_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)sender;
            ICommand cmd = GetLostKeyboardFocusCommand(element);
            cmd.Execute(e);
        }

        public static void SetLostKeyboardFocusCommand(UIElement element, ICommand value)
        {
            element.SetValue(LostKeyboardFocusCommandProperty, value);
        }

        public static ICommand GetLostKeyboardFocusCommand(UIElement element)
        {
            return (ICommand)element.GetValue(LostKeyboardFocusCommandProperty);
        }

        #endregion

        #region MouseDoubleClick

        public static readonly DependencyProperty MouseDoubleClickCommandProperty = DependencyProperty.RegisterAttached("MouseDoubleClickCommand", typeof(ICommand), typeof(FrameworkElementBehavior), new FrameworkPropertyMetadata(new PropertyChangedCallback(MouseDoubleClickCommandChanged)));
        private static void MouseDoubleClickCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)d;
            element.MouseLeftButtonDown += element_MouseDoubleClick;
        }

        static void element_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)sender;

            if (null == element)
                return;

            if (e.ClickCount < 2)
                return;

            ICommand cmd = GetMouseDoubleClickCommand(element);
            cmd.Execute(e);
        }

        public static void SetMouseDoubleClickCommand(UIElement element, ICommand value)
        {
            element.SetValue(MouseDoubleClickCommandProperty, value);
        }

        public static ICommand GetMouseDoubleClickCommand(UIElement element)
        {
            return (ICommand)element.GetValue(MouseDoubleClickCommandProperty);
        }

        #endregion
    }
}
