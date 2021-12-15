using System;
using System.IO;
using System.Linq;
using System.Text;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Hosting;

namespace Skybrud.Essentials.Umbraco.Scheduling {
    
    /// <summary>
    /// Helper class for running tasks inside Umbraco.
    /// </summary>
    public class TaskHelper {
        
        private readonly IHostingEnvironment _hostingEnvironment;

        #region Constructors

        public TaskHelper(IHostingEnvironment hostingEnvironment) {
            _hostingEnvironment = hostingEnvironment;
        }
        
        #endregion

        #region Member methods

        /// <summary>
        /// Returns the name of the specified <paramref name="task"/>.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <returns>The name of the task.</returns>
        protected virtual string GetTaskName(object task) {

            switch (task) {

                case null:
                    throw new ArgumentNullException(nameof(task));

                case string str:
                    return str;

                case Type type:
                    return type.FullName;

                default:
                    return task.GetType().FullName;
                
            }

        }

        /// <summary>
        /// Returns the last run time of the specified <paramref name="task"/>. If the task has not yet been run,
        /// <see cref="DateTime.MinValue"/> is returned instead.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <returns>The last run time of the task, or <see cref="DateTime.MinValue"/> if the task has not yet run.</returns>
        public DateTime GetLastRunTime(object task) {
            string path = Path.Combine(GetTaskDirectoryPath(GetTaskName(task)), "LastRunTime.txt");
            return File.Exists(path) ? File.GetLastWriteTime(path) : DateTime.MinValue;
        }
        
        public DateTime GetLastRunTimeUtc(object task) {
            string path = Path.Combine(GetTaskDirectoryPath(GetTaskName(task)), "LastRunTime.txt");
            return File.Exists(path) ? File.GetLastWriteTimeUtc(path) : DateTime.MinValue;
        }

        public bool ShouldRun(object task, DateTime now, int hour, int minute, DayOfWeek[] weekdays) {

            // Determine when the task is supposed to run on the current day
            DateTime scheduled = new(now.Year, now.Month, now.Day, hour, minute, 0);

            // Return "false" if we haven't reached the scheduled time yet
            if (now < scheduled) return false;

            // Return "false" if the task is not supposed to run the current day
            if (weekdays != null && weekdays.Length > 0 && !weekdays.Contains(now.DayOfWeek)) return false;

            // Get the last run time of the task
            DateTime lastRunTime = GetLastRunTime(GetTaskName(task));

            // Return "true" if the last run time is before the schduled time
            return lastRunTime < scheduled;

        }

        public bool ShouldRun(object task, int hour) {
            return ShouldRun(GetTaskName(task), DateTime.Now, hour, 0, null);
        }

        public bool ShouldRun(object task, int hour, int minute) {
            return ShouldRun(GetTaskName(task), DateTime.Now, hour, minute, null);
        }

        public bool ShouldRun(object task, int hour, int minute, params DayOfWeek[] weekdays) {
            return ShouldRun(GetTaskName(task), DateTime.Now, hour, minute, weekdays);
        }

        public void SetLastRunTime(object task) {

            // Get the task name
            string taskName = GetTaskName(task);

            // Make sure we have a valid directory to save to
            EnsureTaskDirectory(taskName, out string directory);

            // Calculate the path to the fiule
            string path = Path.Combine(directory, "LastRunTime.txt");
            
            // Save the file to the disk
            File.WriteAllText(path, "Hello there!", Encoding.UTF8);

        }

        public void AppendToLog(object task, StringBuilder stringBuilder) {

            // Get the task name
            string taskName = GetTaskName(task);

            // Make sure we have a valid directory to save to
            EnsureTaskDirectory(taskName, out string directory);

            // Calculate the path to the fiule
            string path = Path.Combine(directory, "Log.txt");

            // Append the string builder value to the file on disk
            File.AppendAllText(path, stringBuilder.ToString(), Encoding.UTF8);

        }

        public bool ShouldRun(object task, TimeSpan interval) {
            string taskName = GetTaskName(task);
            return GetLastRunTimeUtc(taskName) < DateTime.UtcNow.Subtract(interval);
        }

        protected string GetTaskDirectoryPath(string taskName) {
            string directory = taskName.IndexOf("Limbo.", StringComparison.Ordinal) == 0 ? "Limbo" : "Skybrud";
            string path = Path.Combine(Constants.SystemDirectories.Umbraco, directory, "Tasks", taskName);
            return _hostingEnvironment.MapPathContentRoot(path);
        }

        private void EnsureTaskDirectory(string taskName, out string path) {
            path = GetTaskDirectoryPath(taskName);
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        }
        
        #endregion

    }

}