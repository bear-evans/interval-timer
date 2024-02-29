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
        }

        #endregion Constructor

        // =======================================================

        #region Event Handlers

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            timer.StartTimer();
        }

        #endregion Event Handlers

        // =======================================================

        /// <summary> Updates the countdown text display when triggered by a property change. </summary>
        /// <param name="text"> The new text to display. </param>
        public void OnCountdownTextChanged(string text)
        {
            CountdownDisplay.Content = text;
        }
    }
}