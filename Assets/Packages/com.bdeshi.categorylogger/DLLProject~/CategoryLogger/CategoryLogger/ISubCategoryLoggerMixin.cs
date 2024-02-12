using System;
using UnityEngine;

namespace BDeshi.Logging
{

    /// <summary>
    /// Mixin for calling logger easily
    /// </summary>
    /// <typeparam name="TLogCategory"></typeparam>
    /// <typeparam name="TLoggerHolder"></typeparam>
    public interface ISubCategoryLoggerMixin<TLogCategory> : ILoggerMixin<TLogCategory>
        where TLogCategory: struct, Enum, IConvertible
    {
        TLogCategory Category { get; }
        //#NOTE, all method defs are in extension methods because this.log() syntax requires that
    }
}