using Padutronics.Diagnostics.Debugging;
using System;
using System.Diagnostics;

namespace Padutronics.Triggers;

[DebuggerDisplay(DebuggerDisplayValues.DebuggerDisplay)]
public abstract class TriggerBase : ITrigger
{
    private bool isActive;

    protected TriggerBase() :
        this(isActive: false)
    {
    }

    protected TriggerBase(bool isActive)
    {
        this.isActive = isActive;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerDisplay => IsActive ? "Active" : "Inactive";

    public bool IsActive
    {
        get => isActive;
        protected set
        {
            if (isActive != value)
            {
                isActive = value;

                RaiseEvents();
            }
        }
    }

    public event EventHandler<EventArgs>? Activated;
    public event EventHandler<EventArgs>? Deactivated;
    public event EventHandler<TriggerStateChangedEventArgs>? StateChanged;

    protected virtual void OnActivated(EventArgs e)
    {
        Activated?.Invoke(this, e);
    }

    protected virtual void OnDeactivated(EventArgs e)
    {
        Deactivated?.Invoke(this, e);
    }

    protected virtual void OnStateChanged(TriggerStateChangedEventArgs e)
    {
        StateChanged?.Invoke(this, e);
    }

    private void RaiseEvents()
    {
        if (IsActive)
        {
            OnActivated(EventArgs.Empty);
        }
        else
        {
            OnDeactivated(EventArgs.Empty);
        }

        OnStateChanged(new TriggerStateChangedEventArgs(IsActive));
    }
}