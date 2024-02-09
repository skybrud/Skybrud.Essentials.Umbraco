using System;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Skybrud.Essentials.Time;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Extensions;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Sync;

namespace Skybrud.Essentials.Umbraco.Scheduling;

/// <summary>
/// Helper class for running tasks inside Umbraco.
/// </summary>
public class TaskHelper {

    private readonly IRuntimeState _runtimeState;
    private readonly IServerRoleAccessor _serverRoleAccessor;
    private readonly IWebHostEnvironment _webHostEnvironment;

    #region Properties

    /// <summary>
    /// Gets the current runtime level, via the injected <see cref="IRuntimeState"/>.
    /// </summary>
    public RuntimeLevel RuntimeLevel => _runtimeState.Level;

    /// <summary>
    /// Gets the current server role, via the injected <see cref="IServerRoleAccessor"/>.
    /// </summary>
    public ServerRole ServerRole => _serverRoleAccessor.CurrentServerRole;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new task helper instance.
    /// </summary>
    /// <param name="runtimeState">A reference to the current <see cref="IRuntimeState"/>.</param>
    /// <param name="serverRoleAccessor">A reference to the current <see cref="IServerRoleAccessor"/>.</param>
    /// <param name="webHostEnvironment">A reference to the current <see cref="IWebHostEnvironment"/>.</param>
    public TaskHelper(IRuntimeState runtimeState, IServerRoleAccessor serverRoleAccessor, IWebHostEnvironment webHostEnvironment) {
        _runtimeState = runtimeState;
        _serverRoleAccessor = serverRoleAccessor;
        _webHostEnvironment = webHostEnvironment;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Returns the name of the specified <paramref name="task"/>.
    /// </summary>
    /// <param name="task">The task.</param>
    /// <returns>The name of the task.</returns>
    protected virtual string GetTaskName(object task) {
        return task switch  {
            null => throw new ArgumentNullException(nameof(task)),
            string str => str,
            Type type => type.FullName!,
            _ => task.GetType().FullName!
        };
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

    /// <summary>
    /// Returns the last run time of the specified <paramref name="task"/>. If the task has not yet been run,
    /// <see cref="DateTime.MinValue"/> is returned instead.
    /// </summary>
    /// <param name="task">The task.</param>
    /// <returns>The last run time of the task, or <see cref="DateTime.MinValue"/> if the task has not yet run.</returns>
    public DateTime GetLastRunTimeUtc(object task) {
        string path = Path.Combine(GetTaskDirectoryPath(GetTaskName(task)), "LastRunTime.txt");
        return File.Exists(path) ? File.GetLastWriteTimeUtc(path) : DateTime.MinValue;
    }

    /// <summary>
    /// Returns whether the specified <paramref name="task"/> should run.
    /// </summary>
    /// <param name="task">The task.</param>
    /// <param name="now">The current time.</param>
    /// <param name="hour">The hour the task should run.</param>
    /// <param name="minute">The minute the task should run.</param>
    /// <param name="weekdays">The days of the week the task should run.</param>
    /// <returns><c>true</c> if the task should run; otherwise <c>false</c>.</returns>
    public bool ShouldRun(object task, DateTime now, int hour, int minute, DayOfWeek[]? weekdays) {

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

    /// <summary>
    /// Returns whether the specified <paramref name="task"/> should run.
    /// </summary>
    /// <param name="task">The task.</param>
    /// <param name="hour">The hour the task should run.</param>
    /// <returns><c>true</c> if the task should run; otherwise <c>false</c>.</returns>
    public bool ShouldRun(object task, int hour) {
        return ShouldRun(GetTaskName(task), DateTime.Now, hour, 0, null);
    }

    /// <summary>
    /// Returns whether the specified <paramref name="task"/> should run.
    /// </summary>
    /// <param name="task">The task.</param>
    /// <param name="hour">The hour the task should run.</param>
    /// <param name="minute">The minute the task should run.</param>
    /// <returns><c>true</c> if the task should run; otherwise <c>false</c>.</returns>
    public bool ShouldRun(object task, int hour, int minute) {
        return ShouldRun(GetTaskName(task), DateTime.Now, hour, minute, null);
    }

    /// <summary>
    /// Returns whether the specified <paramref name="task"/> should run.
    /// </summary>
    /// <param name="task">The task.</param>
    /// <param name="hour">The hour the task should run.</param>
    /// <param name="minute">The minute the task should run.</param>
    /// <param name="weekdays">The days of the week the task should run.</param>
    /// <returns><c>true</c> if the task should run; otherwise <c>false</c>.</returns>
    public bool ShouldRun(object task, int hour, int minute, params DayOfWeek[] weekdays) {
        return ShouldRun(GetTaskName(task), DateTime.Now, hour, minute, weekdays);
    }

    /// <summary>
    /// Returns whether the specified <paramref name="task"/> should run.
    /// </summary>
    /// <param name="task">The task.</param>
    /// <param name="interval">The interval by which the task should run.</param>
    /// <returns><c>true</c> if the task should run; otherwise <c>false</c>.</returns>
    public bool ShouldRun(object task, TimeSpan interval) {
        string taskName = GetTaskName(task);
        return GetLastRunTimeUtc(taskName) < DateTime.UtcNow.Subtract(interval);
    }

    /// <summary>
    /// Sets the last run time of the specified <paramref name="task"/>.
    /// </summary>
    /// <param name="task">The task.</param>
    public void SetLastRunTime(object task) {

        // Get the task name
        string taskName = GetTaskName(task);

        // Make sure we have a valid directory to save to
        EnsureTaskDirectory(taskName, out string directory);

        // Calculate the path to the fiule
        string path = Path.Combine(directory, "LastRunTime.txt");

        // Save the file to the disk
        File.WriteAllLines(path, new [] { "Hello there!", EssentialsTime.UtcNow.Iso8601 }, Encoding.UTF8);

    }

    /// <summary>
    /// Appends the value of <paramref name="stringBuilder"/> to the log of the specified <paramref name="task"/>.
    /// </summary>
    /// <param name="task">The task</param>.
    /// <param name="stringBuilder">The string builder with the value to be logged.</param>
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

    /// <summary>
    /// Returns the path for the directory for the specified task name.
    /// </summary>
    /// <param name="taskName">The name of the task.</param>
    /// <returns>The directory path for the task.</returns>
    protected virtual string GetTaskDirectoryPath(string taskName) {
        string directory = taskName.IndexOf("Limbo.", StringComparison.Ordinal) == 0 ? "Limbo" : "Skybrud";
        string path = Path.Combine(Constants.SystemDirectories.Data, directory, "Tasks", taskName);
        return _webHostEnvironment.MapPathContentRoot(path);
    }

    /// <summary>
    /// Ensures that there is a valid directory for the task with the specified <paramref name="taskName"/>.
    /// </summary>
    /// <param name="taskName">The name of the task.</param>
    /// <param name="path">The path to the task directory.</param>
    protected virtual void EnsureTaskDirectory(string taskName, out string path) {
        path = GetTaskDirectoryPath(taskName);
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);
    }

    #endregion

}