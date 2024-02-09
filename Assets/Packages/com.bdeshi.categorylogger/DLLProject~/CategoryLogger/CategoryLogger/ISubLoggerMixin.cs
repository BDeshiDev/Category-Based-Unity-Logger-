using System;
using UnityEngine;

namespace BDeshi.Logging
{

    /// <summary>
    /// Mixin for calling logger easily
    /// </summary>
    /// <typeparam name="TLogCategory"></typeparam>
    /// <typeparam name="TLoggerHolder"></typeparam>
    public interface ISubLoggerMixin<TLogCategory>
        where TLogCategory: struct, Enum, IConvertible
    {
        GameObject gameObject { get; }
        TLogCategory Category { get; }
        //#NOTE, all method defs are in extension methods because this.log() syntax requires that
        CustomLogger<TLogCategory> Logger { get; }
    }
}