using UnityEngine;using System;
using System.Runtime.CompilerServices;

namespace BDeshi.Logging
{
    [Serializable]
    public class SerializableCategoryLogger<TLogCategory> : ICategoryLogger<TLogCategory> where TLogCategory : struct, Enum, IConvertible
    {
        public TLogCategory Flags;
        public LogPriority MinLogPriority = LogPriority.Normal;
        public UnityEngine.Object DefaultContext { get; set; }
        public Color CategoryColor = Color.green;
        public string Prefix;
        
        public SerializableCategoryLogger(TLogCategory flags, string Prefix, UnityEngine.Object defaultContext = null, LogPriority minLogPriority = LogPriority.Normal)
        {
            this.Flags = flags;
            this.DefaultContext = defaultContext;
            this.Prefix = Prefix;
            this.MinLogPriority = minLogPriority;
        }
        public SerializableCategoryLogger(TLogCategory flags, UnityEngine.Object defaultContext = null, LogPriority minLogPriority = LogPriority.Normal)
            : this(flags, typeof(TLogCategory).Name + ".", defaultContext, minLogPriority) 
        {
            
        }

        public void Log(TLogCategory flag, string msg, LogPriority priority = LogPriority.Normal)
        {
# if DEBUG
            Log(flag, msg, DefaultContext, priority);
#endif
        }
        public void LogWarning(TLogCategory flag, string msg, LogPriority priority = LogPriority.Normal)
        {
# if DEBUG
            LogWarning(flag, msg, DefaultContext, priority);
#endif
        }
        public void LogError(TLogCategory flag, string msg, LogPriority priority = LogPriority.Normal)
        {
# if DEBUG
            LogError(flag, msg, DefaultContext, priority);
#endif
        }
        public void Log(TLogCategory flag, string msg, UnityEngine.Object ctx, LogPriority priority = LogPriority.Normal)
        {
# if DEBUG
            if (!PriorityCheck(priority, MinLogPriority) || !CheckHasFlag(Flags, flag))
            {
                return;
            }
            msg = $"{Prefix}{flag.ToString().Colored(CategoryColor)}: {msg}";

            Debug.Log(msg, ctx);
#endif
        }
        public void LogWarning(TLogCategory flag, string msg, UnityEngine.Object ctx, LogPriority priority = LogPriority.Normal)
        {
# if DEBUG
            if (!PriorityCheck(priority, MinLogPriority) || !CheckHasFlag(Flags, flag))
            {
                return;
            }
            msg = $"{Prefix}{flag.ToString().Colored(CategoryColor)}: {msg}";
            Debug.LogWarning(msg, ctx);
#endif

        }
        public void LogError(TLogCategory flag, string msg, UnityEngine.Object ctx, LogPriority priority = LogPriority.Normal)
        {
# if DEBUG
            if (!PriorityCheck(priority, MinLogPriority) || !CheckHasFlag(Flags, flag))
            {
                return;
            }
            msg = $"{Prefix}{flag.ToString().Colored(CategoryColor)}: {msg}";
            
            Debug.LogError(msg, ctx);
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

