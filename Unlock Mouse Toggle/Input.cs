using Vintagestory.API.Client;
using Unlock_Mouse_Toggle;

namespace Unlock_Mouse_Toggle;

public class AltOverride : ICoreClientAPI.
{
    public override interface ToggleInput : Vintagestory.API.Client.IInputAPI
    {
        override boolean MouseGrabbed {
            get {
                return Unlock_Mouse_Toggle.MouseToggled;
            }
        }
    }
}


