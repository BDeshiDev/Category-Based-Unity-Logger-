using UnityEngine;using System;
using System.Runtime.CompilerServices;

namespace BDeshi.Logging
{
    /// <summary>
    /// Priority level separate from log/warning/error trifecta
    /// </summary>
    public enum LogPriority
    {
        Low, Normal, High, Ultra, PlusUltra
    }
    
    [Serializable]
    public class CustomLogger<TLogCategory>
        where TLogCategory : struct, Enum, IConvertible
    {
        public TLogCategory Flags;
        public LogPriority MinLogPriority = LogPriority.Normal;
        public UnityEngine.Object DefaultContext;
        public Color CategoryColor = Color.green;
        
        public CustomLogger(TLogCategory flags, GameObject defaultContext = null, LogPriority minLogPriority = LogPriority.Normal)
        {
            Flags = flags;
            this.DefaultContext = defaultContext;
            MinLogPriority = minLogPriority;
        }

        [HideInCallstack]
        public void Log(TLogCategory flag, string msg, LogPriority priority = LogPriority.Normal)
        {
# if DEBUG || UNITY_EDITOR
            Log(flag, msg, DefaultContext, priority);
#endif
        }
        [HideInCallstack]
        public void LogWarning(TLogCategory flag, string msg, LogPriority priority = LogPriority.Normal)
        {
# if DEBUG || UNITY_EDITOR
            LogWarning(flag, msg, DefaultContext, priority);
#endif
        }
        [HideInCallstack]
        public void LogError(TLogCategory flag, string msg, LogPriority priority = LogPriority.Normal)
        {
# if DEBUG || UNITY_EDITOR
            LogError(flag, msg, DefaultContext, priority);
#endif
        }
        [HideInCallstack]
        public void Log(TLogCategory flag, string msg, UnityEngine.Object ctx, LogPriority priority = LogPriority.Normal)
        {
# if DEBUG || UNITY_EDITOR
            if (!PriorityCheck(priority, MinLogPriority) || !CheckHasFlag(Flags, flag))
            {
                return;
            }
            msg = $"_{flag.ToString().Colored(ColorUtility.ToHtmlStringRGB(CategoryColor))}: {msg}";
            SilentLoggingExtensions.LogSilently(msg, ctx);
#endif
        }
        [HideInCallstack]
        public void LogWarning(TLogCategory flag, string msg, UnityEngine.Object ctx, LogPriority priority = LogPriority.Normal)
        {
# if DEBUG || UNITY_EDITOR
            if (!PriorityCheck(priority, MinLogPriority) || !CheckHasFlag(Flags, flag))
            {
                return;
            }
            msg = $"_{flag.ToString().Colored(ColorUtility.ToHtmlStringRGB(CategoryColor))}: {msg}";
            SilentLoggingExtensions.LogWarningSilently(msg, ctx);
#endif

        }
        [HideInCallstack]
        public void LogError(TLogCategory flag, string msg, UnityEngine.Object ctx, LogPriority priority = LogPriority.Normal)
        {
# if DEBUG || UNITY_EDITOR
            if (!PriorityCheck(priority, MinLogPriority) || !CheckHasFlag(Flags, flag))
            {
                return;
            }
            msg = $"_{flag.ToString().Colored(ColorUtility.ToHtmlStringRGB(CategoryColor))}: {msg}";
            
            SilentLoggingExtensions.LogErrorSilently(msg, ctx);
#endif
        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool CheckHasFlag(TLogCategory flags, TLogCategory flag)
        {
            //#NOTE enum.hasflag has issues before c# 5.0
            //Unity uses a higher version
            //so this should not cause perf issues
            return flags.HasFlag(flag);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool PriorityCheck(LogPriority priority, LogPriority minPriority)
        {
            return (int)priority >= (int)minPriority;
        }
    }
}

