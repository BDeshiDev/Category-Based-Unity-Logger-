using System;
using UnityEngine;

namespace BDeshi.Logging
{
    public interface ILoggerMixin<TLogCategory>
        where TLogCategory: struct, Enum, IConvertible
    {
        GameObject gameObject { get; }
        ICategoryLogger<TLogCategory> Logger { get; }
        //#NOTE, all method defs are in extension methods because this.log() syntax requires that
    }
}