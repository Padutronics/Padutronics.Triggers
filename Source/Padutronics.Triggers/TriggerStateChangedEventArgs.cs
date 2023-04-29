using System;

namespace Padutronics.Triggers;

public sealed class TriggerStateChangedEventArgs : EventArgs
{
    public TriggerStateChangedEventArgs(bool isTriggerActive)
    {
        IsTriggerActive = isTriggerActive;
    }

    public bool IsTriggerActive { get; }
}