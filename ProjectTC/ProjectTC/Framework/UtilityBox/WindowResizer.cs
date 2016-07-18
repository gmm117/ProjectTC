using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Framework
{
    public class WindowResizer
    {
        private const int ResizerSize = 5;

        private const int WM_SYSCOMMAND = 0x112;
        private HwndSource hwndSource;
        private Window m_window;
        private Grid m_container;
        private Grid m_dragTarget;

        private List<WindowResizerItem> m_items = new List<WindowResizerItem>();
        private bool m_dragMode = false;

        public WindowResizer(Window window, Grid container, Grid dragTarget = null)
        {
            m_window = window;
            m_window.SourceInitialized += new EventHandler(InitializeWindowSource);

            m_container = container;
            m_dragTarget = dragTarget;

            init();
            dragInit();
        }

        private void init()
        {
            createResizer(Cursors.SizeWE, ResizeDirection.Left, ResizerSize, Double.NaN, HorizontalAlignment.Left, VerticalAlignment.Stretch, new Thickness(0, ResizerSize, 0, ResizerSize));
            createResizer(Cursors.SizeNS, ResizeDirection.Top, Double.NaN, ResizerSize, HorizontalAlignment.Stretch, VerticalAlignment.Top, new Thickness(ResizerSize, 0, ResizerSize, 0));
            createResizer(Cursors.SizeWE, ResizeDirection.Right, ResizerSize, Double.NaN, HorizontalAlignment.Right, VerticalAlignment.Stretch, new Thickness(0, ResizerSize, 0, ResizerSize));
            createResizer(Cursors.SizeNS, ResizeDirection.Bottom, Double.NaN, ResizerSize, HorizontalAlignment.Stretch, VerticalAlignment.Bottom, new Thickness(ResizerSize, 0, ResizerSize, 0));
            createResizer(Cursors.SizeNWSE, ResizeDirection.TopLeft, ResizerSize, ResizerSize, HorizontalAlignment.Left, VerticalAlignment.Top, new Thickness(0));
            createResizer(Cursors.SizeNESW, ResizeDirection.TopRight, ResizerSize, ResizerSize, HorizontalAlignment.Right, VerticalAlignment.Top, new Thickness(0));
            createResizer(Cursors.SizeNESW, ResizeDirection.BottomLeft, ResizerSize, ResizerSize, HorizontalAlignment.Left, VerticalAlignment.Bottom, new Thickness(0));
            createResizer(Cursors.SizeNWSE, ResizeDirection.BottomRight, ResizerSize, ResizerSize, HorizontalAlignment.Right, VerticalAlignment.Bottom, new Thickness(0));

            foreach (WindowResizerItem item in m_items)
            {
                if (item.FrameworkElement != null)
                {
                    item.FrameworkElement.PreviewMouseDown += new MouseButtonEventHandler(windowResizer_PreviewMouseDown);
                    item.FrameworkElement.MouseEnter += new MouseEventHandler(windowResizer_MouseEnter);
                    item.FrameworkElement.MouseLeave += new MouseEventHandler(windowResizer_MouseLeave);
                    item.FrameworkElement.MouseMove += new MouseEventHandler(windowResizer_MouseMove);
                    item.FrameworkElement.MouseUp += new MouseButtonEventHandler(windowResizer_MouseLeftButtonUp);
                }
            }
        }

        private void dragInit()
        {
            if (m_dragTarget != null)
            {
                m_dragTarget.MouseLeftButtonDown += new MouseButtonEventHandler(m_dragTarget_MouseLeftButtonDown);
                m_dragTarget.MouseLeftButtonUp += new MouseButtonEventHandler(m_dragTarget_MouseLeftButtonUp);
                m_dragTarget.MouseMove += new MouseEventHandler(m_dragTarget_MouseMove);
            }
        }

        void m_dragTarget_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_dragMode)
            {
                try
                {
                    m_window.DragMove();
                }
                catch (Exception)
                {
                    m_dragMode = false;
                }
            }
        }

        void m_dragTarget_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            m_dragMode = false;
        }

        void m_dragTarget_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            m_dragMode = true;
        }

        private void createResizer(Cursor cursor, ResizeDirection direction, double width, double height, HorizontalAlignment ha, VerticalAlignment va, Thickness margin)
        {
            Rectangle frameworkElement = new Rectangle();
            frameworkElement.Width = width;
            frameworkElement.Height = height;
            frameworkElement.HorizontalAlignment = ha;
            frameworkElement.VerticalAlignment = va;
            frameworkElement.Margin = margin;
            frameworkElement.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            frameworkElement.Opacity = 0;

            m_container.Children.Add(frameworkElement);

            m_items.Add(new WindowResizerItem(frameworkElement, cursor, direction));
        }

        private void windowResizer_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            resizeWindow(sender);
        }

        private void windowResizer_MouseEnter(object sender, MouseEventArgs e)
        {
            displayResizeCursor(sender);
        }

        private void windowResizer_MouseLeave(object sender, MouseEventArgs e)
        {
            resetCursor();
        }

        private void windowResizer_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void windowResizer_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            m_window.Cursor = Cursors.Arrow;
        }

        private void resetCursor()
        {
            if (Mouse.LeftButton != MouseButtonState.Pressed)
            {
                m_window.Cursor = Cursors.Arrow;
            }
        }

        private void InitializeWindowSource(object sender, EventArgs e)
        {
            hwndSource = PresentationSource.FromVisual((Visual)sender) as HwndSource;
            hwndSource.AddHook(new HwndSourceHook(WndProc));
        }

        IntPtr retInt = IntPtr.Zero;

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            //Debug.WriteLine("WndProc messages: " + msg.ToString());
            //
            // Check incoming window system messages
            //
            if (msg == WM_SYSCOMMAND)
            {
                //Debug.WriteLine("WndProc messages: " + msg.ToString());
            }

            return IntPtr.Zero;
        }



        public enum ResizeDirection
        {
            Left = 1,
            Right = 2,
            Top = 3,
            TopLeft = 4,
            TopRight = 5,
            Bottom = 6,
            BottomLeft = 7,
            BottomRight = 8,
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);


        private void win32_resizeWindow(ResizeDirection direction)
        {
            SendMessage(hwndSource.Handle, WM_SYSCOMMAND, (IntPtr)(61440 + direction), IntPtr.Zero);
        }


        private void resizeWindow(object sender)
        {
            FrameworkElement frameworkElement = sender as FrameworkElement;
            if (frameworkElement == null)
            {
                return;
            }

            foreach (WindowResizerItem item in m_items)
            {
                if (item.FrameworkElement == null)
                {
                    continue;
                }

                if (frameworkElement.Equals(item.FrameworkElement))
                {
                    m_window.Cursor = item.Cursor;
                    win32_resizeWindow(item.Direction);
                    break;
                }
            }
        }

        private void displayResizeCursor(object sender)
        {
            FrameworkElement frameworkElement = sender as FrameworkElement;
            if (frameworkElement == null)
            {
                return;
            }

            foreach (WindowResizerItem item in m_items)
            {
                if (item.FrameworkElement == null)
                {
                    continue;
                }

                if (frameworkElement.Equals(item.FrameworkElement))
                {
                    m_window.Cursor = item.Cursor;
                    break;
                }
            }
        }

    }

    public class WindowResizerItem
    {
        private FrameworkElement m_frameworkElement;
        private Cursor m_cursor;
        private WindowResizer.ResizeDirection m_direction;

        public FrameworkElement FrameworkElement
        {
            get { return m_frameworkElement; }
        }

        public Cursor Cursor
        {
            get { return m_cursor; }
        }

        public WindowResizer.ResizeDirection Direction
        {
            get { return m_direction; }
        }

        public WindowResizerItem(FrameworkElement frameworkElement, Cursor cursor, WindowResizer.ResizeDirection direction)
        {
            m_frameworkElement = frameworkElement;
            m_cursor = cursor;
            m_direction = direction;
        }
    }
}
