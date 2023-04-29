namespace Padutronics.Triggers;

public sealed class ManualTrigger : TriggerBase
{
    public ManualTrigger()
    {
    }

    public ManualTrigger(bool isActive) :
        base(isActive)
    {
    }

    public void Activate()
    {
        Activate(force: false);
    }

    public void Activate(bool force)
    {
        if (force && IsActive)
        {
            Deactivate();
        }

        IsActive = true;
    }

    public void Deactivate()
    {
        IsActive = false;
    }
}