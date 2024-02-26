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
        private bool isUserPaused = false;

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
        private int intervalHourInput;
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
        private int intervalMinuteInput;
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
        private int intervalSecondInput;
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
        // ------------------------------

        #endregion Timekeeping

        #endregion Variables

        // ==============================

        #region Constructor

        public Timer()
        { }

        #endregion Constructor

        // ==============================

        #region User Input

        public TimeSpan RecalculateStartTime()
        {
            return new TimeSpan(startHourInput, startMinuteInput, 0);
        }

        public TimeSpan RecalculateEndTime()
        {
            return new TimeSpan(endHourInput, endMinuteInput, 0);
        }

        #endregion User Input

        // ==============================

        #region Timer Functions

        public void StartTimer()
        {
        }

        public async void RunTimer()
        {
        }

        private bool CheckRunTimes()
        {
            return true;
        }

        #endregion Timer Functions
    }
}