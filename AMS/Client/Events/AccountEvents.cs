using Microsoft.AspNetCore.Components;

namespace AMS.Client.Events
{
    public class AccountEvents
    {
        public event EventHandler<EventArgs> AccountAdded;
        public virtual void OnAccountAdded(ComponentBase source)
        {
            AccountAdded?.Invoke(source, EventArgs.Empty);
        }
    }
}
