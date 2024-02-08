using System;
using BDeshi.Logging;
using UnityEngine;

namespace BDeshi.Logging
{
    public static class LoggingExtensions
    {
        public static string Colored(this string s, string color)
        {
            return $"<color={color}>{s}</color>";
        }
        
        public static string RedColored(this string s)
        {
            return s.Colored("#FF0000");
        }
        
        public static string GreenColored(this string s)
        {
            return s.Colored("#00FF00");
        }
        
        public static string BlueColored(this string s)
        {
            return s.Colored("#0000FF");
        }
        
        public static string Bolded(this string s, string color)
        {
            return $"<b>{s}</b>";
        }
        
        public static void Log<TLogCategory, TLoggerHolder>(this ISubLoggerMixin<TLogCategory> subLogger,string msg, LogPriority priority = LogPriority.Normal)
            where TLogCategory: struct, Enum, IConvertible
        {
            subLogger.Logger.Log(subLogger.Category, msg, subLogger.gameObject, priority);
        }
        
        public static void LogWarning<TLogCategory, TLoggerHolder>(this ISubLoggerMixin<TLogCategory> subLogger,string msg, LogPriority priority = LogPriority.Normal)
            where TLogCategory: struct, Enum, IConvertible

        {
            subLogger.Logger.LogWarning(subLogger.Category, msg, subLogger.gameObject, priority);
        }
        
        public static void LogError<TLogCategory, TLoggerHolder>(this ISubLoggerMixin<TLogCategory> subLogger,string msg, LogPriority priority = LogPriority.Normal)
            where TLogCategory: struct, Enum, IConvertible

        {
            subLogger.Logger.LogError(subLogger.Category, msg, subLogger.gameObject, priority);
        }
        
        public static void Log<TLogCategory, TLoggerHolder>(this ISubLoggerMixin<TLogCategory> subLogger,string msg, TLogCategory categoryOverride, LogPriority priority = LogPriority.Normal)
            where TLogCategory: struct, Enum, IConvertible

        {
            subLogger.Logger.Log(categoryOverride, msg, subLogger.gameObject, priority);
        }
        
        public static void LogWarning<TLogCategory, TLoggerHolder>(this ISubLoggerMixin<TLogCategory> subLogger,string msg, TLogCategory categoryOverride, LogPriority priority = LogPriority.Normal)
            where TLogCategory: struct, Enum, IConvertible

        {
            subLogger.Logger.LogWarning(categoryOverride, msg, subLogger.gameObject, priority);
        }

        public static void LogError<TLogCategory, TLoggerHolder>(this ISubLoggerMixin<TLogCategory> subLogger, string msg, TLogCategory categoryOverride, LogPriority priority = LogPriority.Normal)
            where TLogCategory: struct, Enum, IConvertible

        {
            subLogger.Logger.LogError(categoryOverride, msg, subLogger.gameObject, priority);
        }
    }
}