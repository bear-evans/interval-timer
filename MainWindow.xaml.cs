using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IntervalTimer
{
    /// <summary> Interaction logic for MainWindow.xaml </summary>
    public partial class MainWindow : Window
    {
        #region External References

        // -------------------------------------------------------
        private Timer timer;
        // -------------------------------------------------------

        #endregion External References

        // =======================================================

        #region Constructor

        public MainWindow()
        {
            // Create timer and bind to it
            timer = new Timer();
            this.DataContext = timer;

            InitializeComponent();

            // Connect UI callbacks
            timer.CountdownDisplayChanged += OnCountdownTextChanged;
            timer.UserPausedChangedEvent += OnUserPausedChanged;
            timer.TimebarColorChanged += OnTimebarColorChanged;
            timer.TimebarProgressChanged += OnTimebarProgressChanged;
        }

        #endregion Constructor

        // =======================================================

        #region Event Handlers

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            timer.StartStopTimer();
        }

        #endregion Event Handlers

        // =======================================================

        /// <summary> Updates the countdown text display when triggered by a property change. </summary>
        /// <param name="text"> The new text to display. </param>
        public void OnCountdownTextChanged(string text)
        {
            CountdownDisplay.Content = text;
        }

        /// <summary>
        /// Changes the label of the start and stop button when the user paused state changes.
        /// </summary>
        /// <param name="isPaused"> The new value of IsUserPaused. </param>
        public void OnUserPausedChanged(bool isPaused)
        {
            StartButton.Content = isPaused ? "Start" : "Pause";
        }

        /// <summary> Changes the color of the progress bar as time progresses. </summary>
        /// <param name="color"> The new color of the progress bar. </param>
        public void OnTimebarColorChanged(Color color)
        {
            CountdownBar.Foreground = new SolidColorBrush(color);
        }

        /// <summary> Updates the time bar when the countdown progresses. </summary>
        /// <param name="progress"> The new progress value. </param>
        public void OnTimebarProgressChanged(double progress)
        {
            CountdownBar.Value = progress * 100f;
        }
    }
}