using System;

namespace Padutronics.Triggers;

public interface ITrigger
{
    bool IsActive { get; }

    event EventHandler<EventArgs>? Activated;
    event EventHandler<EventArgs>? Deactivated;
    event EventHandler<TriggerStateChangedEventArgs>? StateChanged;
}