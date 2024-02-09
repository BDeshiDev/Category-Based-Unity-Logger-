using System;

namespace BDeshi.Logging
{
    public interface ICategoryLogger<TLogCategory> where TLogCategory : struct, Enum, IConvertible
    {
        UnityEngine.Object DefaultContext { get; set; }
        void Log(TLogCategory flag, string msg, LogPriority priority = LogPriority.Normal);
        void Log(TLogCategory flag, string msg, UnityEngine.Object ctx, LogPriority priority = LogPriority.Normal);
        void LogWarning(TLogCategory flag, string msg, LogPriority priority = LogPriority.Normal);
        void LogWarning(TLogCategory flag, string msg, UnityEngine.Object ctx, LogPriority priority = LogPriority.Normal);
        void LogError(TLogCategory flag, string msg, LogPriority priority = LogPriority.Normal);
        void LogError(TLogCategory flag, string msg, UnityEngine.Object ctx, LogPriority priority = LogPriority.Normal);
    }
}