using Vintagestory.API.Common;

namespace Unlock_Mouse_Toggle;

public class Unlock_Mouse_Toggle : ModSystem
{
    // Called on server and client
    // Useful for registering block/entity classes on both sides

    #region unneeded
    /*
    public override void Start(ICoreAPI api)
    {
        api.Logger.Notification("Hello from template mod: " + api.Side);
    }

    public override void StartServerSide(ICoreServerAPI api)
    {
        api.Logger.Notification("Hello from template mod server side: " + Lang.Get("mouselocktoggle:hello"));
    }
    */
    #endregion

    public boolean MouseToggled = false;


    public override void StartClientSide(ICoreClientAPI api)
    {
        api.Logger.Notification("Hello from test mod client side: " + Lang.Get("mouselocktoggle:hello"));
    }
}