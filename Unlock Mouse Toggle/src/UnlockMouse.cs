using System;
using Vintagestory.API.Client;
using Vintagestory.API.Common;

namespace UnlockMouse
{
    class UnlockMouseHandler
    {
        private bool _isMouseToggled = false;
        private readonly ICoreClientAPI _clientApi;

        public UnlockMouseHandler(ICoreClientAPI clientApi)
        {
            _clientApi = clientApi;
        }
        public void Activate()
        {
            _clientApi.Input.RegisterHotkey("toggleMouse", "Toggle Mouse Unlock", GlKeys.LAlt);
            _clientApi.Input.HotKeys["toggleMouse"].Handler += OnToggleMouseHotkey;
        }

        private bool OnToggleMouseHotkey(KeyCombination t1)
        {
            _isMouseToggled = !_isMouseToggled;
            _clientApi.Input.KeyEvent.AltPressed = true;
            return true;
        }
    }
    
    public class UnlockMouseSystem : ModSystem
    {
        private ICoreClientAPI _clientApi;

        private UnlockMouseHandler _mouseToggleHandler;

        public override void StartClientSide(ICoreClientAPI api)
        {
            _clientApi = api;

            _mouseToggleHandler = new UnlockMouseHandler(api);

            _mouseToggleHandler.Activate();
        }

    }
}