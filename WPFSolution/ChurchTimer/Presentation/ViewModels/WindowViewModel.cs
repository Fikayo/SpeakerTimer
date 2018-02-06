using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ChurchTimer.Presentation.ViewModels
{
    /// <summary>
    /// View Model for a custom flat window
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        /// <summary>
        /// The window this view model controls
        /// </summary>
        private Window window;

        private int outerMarginSize = 0;

        private int windowRadius = 1;

        private int resizeBorder = 3;
        
        private int titleHeight = 30;

        private int minimumSize = 150;

        public WindowViewModel(Window window)
        {
            this.window = window;
            this.window.StateChanged += Window_StateChanged;

            // XOR the windows state with maximized in order to toggle between maximized and normal
            this.MaximizeCommand = new CommandHandler(() => this.window.WindowState ^= WindowState.Maximized);
            this.MinimizeCommand = new CommandHandler(() => this.window.WindowState = WindowState.Minimized);
            this.CloseCommand = new CommandHandler(() => this.window.Close());
            this.SystemMenuCommand = new CommandHandler(() => SystemCommands.ShowSystemMenu(this.window, Utils.GetMousePosition()));
        }

        #region Properties

        /// <summary>
        /// Gets or sets the minimum width of the window
        /// </summary>
        public int MinimumWidth
        {
            get { return this.minimumSize; }

            set
            {
                if (this.minimumSize != value)
                {
                    this.minimumSize = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the minimum height of the window
        /// </summary>
        public int MinimumHeight
        {
            get { return this.minimumSize; }

            set
            {
                if (this.minimumSize != value)
                {
                    this.minimumSize = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// The thickness of the border used to resize the window
        /// </summary>
        public int ResizeBorder
        {
            get { return this.resizeBorder; }

            set
            {
                if (this.resizeBorder != value)
                {
                    this.resizeBorder = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get { return this.window.WindowState == WindowState.Maximized ? 0 : this.outerMarginSize; }

            set
            {
                if (this.outerMarginSize != value)
                {
                    this.outerMarginSize = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public int WindowRadius
        {
            get { return this.window.WindowState == WindowState.Maximized ? 0 : this.windowRadius; }

            set
            {
                if (this.windowRadius != value)
                {
                    this.windowRadius = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the height of the window title/caption bar
        /// </summary>
        public int TitleHeight
        {
            get { return this.titleHeight; }

            set
            {
                if (this.titleHeight != value)
                {
                    this.titleHeight = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets the GridLength for the title height
        /// </summary>
        public GridLength TitleHeightGridLength
        {
            get
            {
                return new GridLength(this.TitleHeight);
            }
        }

        /// <summary>
        /// Gets the window CornerRadius value
        /// </summary>
        public CornerRadius WindowCornerRadius
        {
            get
            {
                return new CornerRadius(this.WindowRadius);
            }
        }

        /// <summary>
        /// Gets the resize border Thickness value
        /// </summary>
        public Thickness ResizeBorderThickness
        {
            get
            {
                return new Thickness(this.ResizeBorder);
            }
        }

        /// <summary>
        /// Gets the outer margine size Thickness value
        /// </summary>
        public Thickness OuterMarginSizeThickness
        {
            get
            {
                return new Thickness(this.OuterMarginSize);
            }
        }

        #endregion

        #region Commands

        public ICommand MinimizeCommand { get; protected set; }

        public ICommand MaximizeCommand { get; protected set; }

        public ICommand CloseCommand { get; protected set; }

        public ICommand SystemMenuCommand { get; protected set; }

        #endregion

        private void Window_StateChanged(object sender, EventArgs e)
        {
            // Fire off events for all properties that are effected by a resize
            this.OnPropertyChanged(nameof(this.OuterMarginSizeThickness));
            this.OnPropertyChanged(nameof(this.ResizeBorderThickness));
            this.OnPropertyChanged(nameof(this.WindowCornerRadius));
        }
    }
}
