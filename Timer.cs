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
        private TimeSpan startTime;

        public Action<TimeSpan> StartTimeChangedEvent { get; set; } = delegate { };

        private TimeSpan endTime;

        public Action<TimeSpan> EndTimeChangedEvent { get; set; } = delegate { };

        private TimeSpan interval;

        public Action<TimeSpan> IntervalChangedEvent { get; set; } = delegate { };
        // ------------------------------

        #endregion User Input

        #endregion Variables

        // ==============================

        #region Constructor

        public Timer()
        { }

        #endregion Constructor

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