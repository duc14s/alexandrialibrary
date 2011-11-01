﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Gnosis.Tasks
{
    #region TaskBase

    public abstract class TaskBase
        : ITask
    {
        protected TaskBase(ILogger logger)
        {
            if (logger == null)
                throw new ArgumentNullException("logger");

            this.logger = logger;

            worker.DoWork += DoWork;
            worker.RunWorkerCompleted += WorkCompleted;
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
        }

        #region Private Members

        private TaskProgress progress;
        private TaskStatus status = TaskStatus.Ready;
        private Exception error;
        private readonly IList<Action> startedCalledbacks = new List<Action>();
        private readonly IList<Action> pausedCallbacks = new List<Action>();
        private readonly IList<Action> resumedCallbacks = new List<Action>();
        private readonly IList<Action> cancelledCallbacks = new List<Action>();
        private readonly IList<Action> completedCallbacks = new List<Action>();
        private readonly IList<Action<TaskProgress>> progressCallbacks = new List<Action<TaskProgress>>();
        private readonly IList<Action<Exception>> failedCallbacks = new List<Action<Exception>>();
        private readonly BackgroundWorker worker = new BackgroundWorker();

        private void OnStarted()
        {
            foreach (var callback in startedCalledbacks)
                callback();
        }

        private void OnPaused()
        {
            foreach (var callback in pausedCallbacks)
                callback();
        }

        private void OnResumed()
        {
            foreach (var callback in resumedCallbacks)
                callback();
        }

        private void OnCancelled()
        {
            foreach (var callback in cancelledCallbacks)
                callback();
        }

        private void OnProgressUpdated()
        {
            foreach (var callback in progressCallbacks)
                callback(progress);
        }

        private void OnCompleted()
        {
            foreach (var callback in completedCallbacks)
                callback();
        }

        private void OnFailed()
        {
            foreach (var callback in failedCallbacks)
                callback(error);
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DoWork();
            }
            catch (Exception ex)
            {
                Fail(ex);
            }
        }

        private void Wait(TimeSpan timeout)
        {
            if (status != TaskStatus.Running)
                return;

            var start = DateTime.Now;
            while (status == TaskStatus.Running)
            {
                System.Threading.Thread.Sleep(100);
                if (timeout > TimeSpan.Zero && DateTime.Now.Subtract(start) > timeout)
                    throw new TimeoutException(string.Format("Timeout occured in TaskHandle: {0} seconds elapsed", timeout.TotalSeconds));
            }
        }

        #endregion

        protected readonly ILogger logger;

        protected abstract void DoWork();

        protected void BlockIfPaused()
        {
            while (status == TaskStatus.Paused)
            {
                System.Threading.Thread.Sleep(100);
            }
        }

        protected virtual void WorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (status != TaskStatus.Cancelled && status != TaskStatus.Failed)
                {
                    status = TaskStatus.Completed;

                    OnCompleted();
                }
            }
            catch (Exception ex)
            {
                logger.Error("TaskHandle.WorkCompleted", ex);
            }
        }

        protected virtual void UpdateProgress(int number, string description)
        {
            this.progress = new TaskProgress(number, description);

            OnProgressUpdated();
        }

        protected virtual void Fail(Exception error)
        {
            status = TaskStatus.Failed;
            this.error = error;

            OnFailed();
        }

        protected virtual void Fail(Exception error, string message)
        {
            status = TaskStatus.Failed;
            var errorWrapper = new ApplicationException(message, error);
            this.error = errorWrapper;

            OnFailed();
        }

        public TaskProgress Progress
        {
            get { return progress; }
        }

        public TaskStatus Status
        {
            get { return status; }
        }

        public Exception Error
        {
            get { return error; }
        }

        public void AddStartedCallback(Action callback)
        {
            if (callback == null)
                throw new ArgumentNullException("callback");

            startedCalledbacks.Add(callback);
        }

        public void AddPausedCallback(Action callback)
        {
            if (callback == null)
                throw new ArgumentNullException("callback");

            pausedCallbacks.Add(callback);
        }

        public void AddResumedCallback(Action callback)
        {
            if (callback == null)
                throw new ArgumentNullException("callback");

            resumedCallbacks.Add(callback);
        }

        public void AddCancelledCallback(Action callback)
        {
            if (callback == null)
                throw new ArgumentNullException("callback");

            cancelledCallbacks.Add(callback);
        }

        public void AddProgressCallback(Action<TaskProgress> callback)
        {
            if (callback == null)
                throw new ArgumentNullException("callback");

            progressCallbacks.Add(callback);
        }

        public void AddCompletedCallback(Action callback)
        {
            if (callback == null)
                throw new ArgumentNullException("callback");

            completedCallbacks.Add(callback);
        }

        public void AddFailedCallback(Action<Exception> callback)
        {
            if (callback == null)
                throw new ArgumentNullException("callback");

            failedCallbacks.Add(callback);
        }

        public void Start()
        {
            if (status != TaskStatus.Ready)
                throw new InvalidOperationException("Cannot start a task that is not ready. status: " + status);

            status = TaskStatus.Running;

            OnStarted();

            worker.RunWorkerAsync();
        }

        public void StartSynchronously()
        {
            if (status != TaskStatus.Ready)
                return;

            Start();

            Wait(TimeSpan.Zero);
        }

        public void StartSynchronously(TimeSpan timeout)
        {
            if (status != TaskStatus.Ready)
                return;

            Start();

            Wait(timeout);
        }

        public void Pause()
        {
            if (status != TaskStatus.Running)
                return;

            status = TaskStatus.Paused;

            OnPaused();
        }

        public void Resume()
        {
            if (status != TaskStatus.Paused)
                return;

            status = TaskStatus.Running;

            OnResumed();
        }

        public void Cancel()
        {
            if (status != TaskStatus.Paused && status != TaskStatus.Running)
                return;

            try
            {
                status = TaskStatus.Cancelled;

                worker.CancelAsync();

                OnCancelled();
            }
            catch (Exception ex)
            {
                logger.Error("  TaskHandle.Cancel", ex);
            }
        }
    }

    #endregion

    #region TaskBase<T>

    public abstract class TaskBase<T>
        : TaskBase, ITask<T>
    {
        protected TaskBase(ILogger logger)
            : base(logger)
        {
        }

        private readonly IList<Action<T>> resultsCallbacks = new List<Action<T>>();

        public void AddResultsCallback(Action<T> callback)
        {
            if (callback == null)
                throw new ArgumentNullException("callback");

            resultsCallbacks.Add(callback);
        }

        public void UpdateResults(T results)
        {
            foreach (var callback in resultsCallbacks)
                callback(results);
        }
    }

    #endregion
}