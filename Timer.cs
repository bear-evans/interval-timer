using Microsoft.Windows.Themes;
using System;

namespace IntervalTimer
{
    public class Timer
    {
        #region Variables

        #region App Flags

        // ------------------------------
        /// <summary>
        /// Operational status of the timer functions. If false, intervals are not counted and no
        /// chimes will be played.
        /// </summary>
        public bool IsRunning
        {
            get => isRunning;

            set
            {
                isRunning = value;
                IsRunningChangedEvent?.Invoke(isRunning);
            }
        }
        private bool isRunning = false;

        /// <summary> Event fired when the operational status of the timer changes. </summary>
        public Action<bool> IsRunningChangedEvent { get; set; } = delegate { };

        /// <summary>
        /// True if the user has paused the timer. False if the timer is not paused or was paused by
        /// the time frame.
        /// </summary>
        public bool IsUserPaused
        {
            get => isUserPaused;

            set
            {
                isUserPaused = value;
                UserPausedChangedEvent?.Invoke(isUserPaused);
            }
        }
        private bool isUserPaused = true;

        /// <summary> Event fired when the user pauses or unpauses the timer. </summary>
        public Action<bool> UserPausedChangedEvent { get; set; } = delegate { };
        // ------------------------------

        #endregion App Flags

        #region User Input

        // ------------------------------
        /// <summary> The contents of the hour text field for the start time UI. </summary>
        public int StartHourInput
        {
            get => startHourInput;

            set
            {
                startHourInput = value;
                StartInputChanged?.Invoke();
            }
        }
        private int startHourInput = 9;

        /// <summary> The contents of the minute text field for the start time UI. </summary>
        public int StartMinuteInput
        {
            get => startMinuteInput; set

            {
                startMinuteInput = value;
                StartInputChanged?.Invoke();
            }
        }
        private int startMinuteInput = 30;

        /// <summary> Event fired when the start time input is changed by the user. </summary>
        public Action StartInputChanged { get; set; } = delegate { };

        /// <summary> The contents of the hour text field for the end time UI. </summary>
        public int EndHourInput
        {
            get => endHourInput; set

            {
                endHourInput = value;
                EndInputChanged?.Invoke();
            }
        }
        private int endHourInput = 16;

        /// <summary> The contents of the minute text field for the end time UI. </summary>
        public int EndMinuteInput
        {
            get => endMinuteInput;

            set
            {
                endMinuteInput = value;
                EndInputChanged?.Invoke();
            }
        }
        private int endMinuteInput = 30;

        /// <summary> Event fired when the end time input is changed by the user. </summary>
        public Action EndInputChanged { get; set; } = delegate { };

        /// <summary> The contents of the interval hour text field. </summary>
        public int IntervalHourInput
        {
            get => intervalHourInput;

            set
            {
                intervalHourInput = value;
                IntervalInputChanged?.Invoke();
            }
        }
        private int intervalHourInput = 0;
        /// <summary> The contents of the interval minute field. </summary>
        public int IntervalMinuteInput
        {
            get => intervalMinuteInput;

            set
            {
                intervalMinuteInput = value;
                IntervalInputChanged?.Invoke();
            }
        }
        private int intervalMinuteInput = 3;
        /// <summary> The contents of the interval second field. </summary>
        public int IntervalSecondInput
        {
            get => intervalSecondInput;

            set
            {
                intervalSecondInput = value;
                IntervalInputChanged?.Invoke();
            }
        }
        private int intervalSecondInput = 0;
        /// <summary> Event fired when the interval input is changed by the user. </summary>
        public Action IntervalInputChanged { get; set; } = delegate { };
        // ------------------------------

        #endregion User Input

        #region Timekeeping

        // ------------------------------
        /// <summary> The user-set start time for the timer. </summary>
        public TimeSpan StartTime
        {
            get => startTime;

            set
            {
                startTime = value;
                StartTimeChangedEvent?.Invoke(startTime);
            }
        }
        private TimeSpan startTime;

        /// <summary> Event fired when the start time changes. </summary>
        public Action<TimeSpan> StartTimeChangedEvent { get; set; } = delegate { };

        /// <summary> The user-set end time for the timer. </summary>
        public TimeSpan EndTime
        {
            get => endTime;

            set
            {
                endTime = value;
                EndTimeChangedEvent?.Invoke(endTime);
            }
        }
        private TimeSpan endTime;

        /// <summary> Event fired when the end time changes. </summary>
        public Action<TimeSpan> EndTimeChangedEvent { get; set; } = delegate { };

        /// <summary> The user-configured time interval for the timer. </summary>
        public TimeSpan Interval
        {
            get => interval;

            set
            {
                interval = value;
                IntervalChangedEvent?.Invoke(interval);
            }
        }
        private TimeSpan interval;

        /// <summary> Event fired when the interval changes. </summary>
        public Action<TimeSpan> IntervalChangedEvent { get; set; } = delegate { };

        private TimeSpan timeSinceStart;
        /// <summary> Amount of time left before the chime. </summary>
        public double RemainingSeconds
        {
            get => remainingSeconds;

            set
            {
                lastSeconds = remainingSeconds;
                remainingSeconds = value;
            }
        }
        private double lastSeconds;
        private double remainingSeconds;
        // ------------------------------

        #endregion Timekeeping

        #region Display Properties

        // ------------------------------
        /// <summary> The content of the countdown display text field. </summary>
        public string CountdownDisplay
        {
            get => countdownDisplay;

            set
            {
                countdownDisplay = value;
                CountdownDisplayChanged?.Invoke(countdownDisplay);
            }
        }
        private string countdownDisplay = "Waiting...";

        /// <summary> Event fired when the countdown display text is changed. </summary>
        public Action<string> CountdownDisplayChanged { get; set; } = delegate { };
        // ------------------------------

        #endregion Display Properties

        #endregion Variables

        // ==============================

        #region Constructor

        public Timer()
        {
            // initialize timespans
            StartTime = new TimeSpan(StartHourInput, StartMinuteInput, 0);
            EndTime = new TimeSpan(EndHourInput, EndMinuteInput, 0);
            Interval = new TimeSpan(IntervalHourInput, IntervalMinuteInput, IntervalSecondInput);

            // Register input event listeners
            StartInputChanged += OnStartTimeInputChanged;
            EndInputChanged += OnEndTimeInputChanged;
            IntervalInputChanged += OnIntervalInputChanged;
        }

        #endregion Constructor

        // ==============================

        #region User Input

        /// <summary> Creates a new start time Timespan object from the user's input. </summary>
        public void OnStartTimeInputChanged()
        {
            StartTime = new TimeSpan(startHourInput, startMinuteInput, 0);
        }

        /// <summary> Creates a new end time Timespan object from the user's input. </summary>
        public void OnEndTimeInputChanged()
        {
            EndTime = new TimeSpan(endHourInput, endMinuteInput, 0);
        }

        /// <summary> Creates a new interval Timespan object from the user's input. </summary>
        public void OnIntervalInputChanged()
        {
            Interval = new TimeSpan(intervalHourInput, intervalMinuteInput, intervalSecondInput);
        }

        #endregion User Input

        // ==============================

        #region Timer Functions

        public void StartStopTimer()
        {
            IsUserPaused = !IsUserPaused;

            if (!IsUserPaused)
            {
                RunTimer();
            }
        }

        public async void RunTimer()
        {
            // Start the timer
            IsRunning = true;

            // run the timer until the user pauses.
            while (!IsUserPaused)
            {
                // if between start and stop times, run the timer, otherwise, pause it.
                if (CheckRunTimes())
                {
                    // Calculate the remaining time in the current interval from the start time.
                    timeSinceStart = DateTime.Now.TimeOfDay - startTime;
                    RemainingSeconds = timeSinceStart.TotalSeconds % interval.TotalSeconds;

                    if (lastSeconds > remainingSeconds)
                    {
                        PlayChime();
                    }

                    // change the display to reflect the new state of the countdown
                    CountdownDisplay = FormatCountdownText(TimeSpan.FromSeconds(interval.TotalSeconds - remainingSeconds));

                    // wait briefly
                    await Task.Delay(TimeSpan.FromSeconds(0.25));
                }
                else
                {
                    DisplayWaiting();

                    // check frequently for changes
                    await Task.Delay(TimeSpan.FromSeconds(0.5));
                }
            }

            DisplayPaused();
        }

        /// <summary> Checks if the current time is between the start time and end time. </summary>
        /// <returns>
        /// True if the current time is between the start time and end time, false if not.
        /// </returns>
        private bool CheckRunTimes()
        {
            if (startTime < EndTime)
            {
                if (DateTime.Now.TimeOfDay >= StartTime && DateTime.Now.TimeOfDay < EndTime)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (DateTime.Now.TimeOfDay >= StartTime && DateTime.Now.TimeOfDay < EndTime)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        #endregion Timer Functions

        // ==============================

        #region Display Functions

        private void DisplayPaused()
        {
            CountdownDisplay = "Paused...";
        }

        private void DisplayWaiting()
        {
            CountdownDisplay = "Waiting...";
        }

        /// <summary>
        /// Formats a Timespan object as a string to be displayed to the user in the countdown text.
        /// </summary>
        /// <param name="timeSpan"> The remaining time to format as a string. </param>
        /// <returns> A formatted time string. </returns>
        public string FormatCountdownText(TimeSpan timeSpan)
        {
            if (interval.Hours > 0)
            {
                return string.Format("{0:00}:{1:00}:{2:00}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
            }
            else
            {
                return string.Format("{0:00}:{1:00}", timeSpan.Minutes, timeSpan.Seconds);
            }
        }

        private void UpdateTimerProgress()
        {
        }

        #endregion Display Functions

        // ==============================

        #region Audio

        private void PlayChime()
        {
        }

        #endregion Audio
    }
}