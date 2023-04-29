using System.Collections.Generic;
using System.Linq;

namespace Padutronics.Triggers;

public sealed class MultiTrigger : TriggerBase
{
    private readonly IEnumerable<ITrigger> triggers;

    public MultiTrigger(IEnumerable<ITrigger> triggers) :
        base(isActive: GetIsActive(triggers))
    {
        this.triggers = triggers;

        foreach (ITrigger trigger in triggers)
        {
            trigger.StateChanged += Trigger_StateChanged;
        }
    }

    private static bool GetIsActive(IEnumerable<ITrigger> triggers)
    {
        return triggers.All(trigger => trigger.IsActive);
    }

    private void Trigger_StateChanged(object? sender, TriggerStateChangedEventArgs e)
    {
        IsActive = GetIsActive(triggers);
    }
}