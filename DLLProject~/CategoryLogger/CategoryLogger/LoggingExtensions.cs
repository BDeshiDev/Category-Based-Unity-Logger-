using System;
using BDeshi.Logging;
using UnityEngine;

namespace BDeshi.Logging
{
    public static class LoggingExtensions
    {
        
        public static string Colored(this string s, Color color)
        {
            return $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{s}</color>";
        }
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
        
        public static void Log<TLogCategory>(this ISubCategoryLoggerMixin<TLogCategory> subCategoryLogger,string msg, LogPriority priority = LogPriority.Normal)
            where TLogCategory: struct, Enum, IConvertible
        {
            subCategoryLogger.Logger.Log(subCategoryLogger.Category, msg, subCategoryLogger.gameObject, priority);
        }
        
        public static void LogWarning<TLogCategory>(this ISubCategoryLoggerMixin<TLogCategory> subCategoryLogger,string msg, LogPriority priority = LogPriority.Normal)
            where TLogCategory: struct, Enum, IConvertible

        {
            subCategoryLogger.Logger.LogWarning(subCategoryLogger.Category, msg, subCategoryLogger.gameObject, priority);
        }
        
        public static void LogError<TLogCategory>(this ISubCategoryLoggerMixin<TLogCategory> subCategoryLogger,string msg, LogPriority priority = LogPriority.Normal)
            where TLogCategory: struct, Enum, IConvertible

        {
            subCategoryLogger.Logger.LogError(subCategoryLogger.Category, msg, subCategoryLogger.gameObject, priority);
        }
        
        public static void Log<TLogCategory>(this ISubCategoryLoggerMixin<TLogCategory> subCategoryLogger,string msg, TLogCategory categoryOverride, LogPriority priority = LogPriority.Normal)
            where TLogCategory: struct, Enum, IConvertible

        {
            subCategoryLogger.Logger.Log(categoryOverride, msg, subCategoryLogger.gameObject, priority);
        }
        
        public static void LogWarning<TLogCategory>(this ISubCategoryLoggerMixin<TLogCategory> subCategoryLogger,string msg, TLogCategory categoryOverride, LogPriority priority = LogPriority.Normal)
            where TLogCategory: struct, Enum, IConvertible

        {
            subCategoryLogger.Logger.LogWarning(categoryOverride, msg, subCategoryLogger.gameObject, priority);
        }

        public static void LogError<TLogCategory>(this ISubCategoryLoggerMixin<TLogCategory> subCategoryLogger, string msg, TLogCategory categoryOverride, LogPriority priority = LogPriority.Normal)
            where TLogCategory: struct, Enum, IConvertible

        {
            subCategoryLogger.Logger.LogError(categoryOverride, msg, subCategoryLogger.gameObject, priority);
        }
    }
}