using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Util;

namespace UnlockMouse
{
    class UnlockMouseHandler
    {
        private bool _isMouseToggled = false;
        private readonly ICoreClientAPI _clientApi;

        private GuiDialog _dialog;



        public UnlockMouseHandler(ICoreClientAPI clientApi)
        {
            _clientApi = clientApi;
        }


        public class MouseDialog : GuiDialog
        {
            public override string ToggleKeyCombinationCode => "toggleMouse";
            public override bool PrefersUngrabbedMouse => false;


            public MouseDialog(ICoreClientAPI capi) : base(capi)
            {
                SetupDialog();
            }

            private void SetupDialog()
            {
                ElementBounds dialogBounds = ElementStdBounds.AutosizedMainDialog.WithAlignment(EnumDialogArea.CenterTop);

                ElementBounds textBounds = ElementBounds.Fixed(0, 0, 0, 0);

            }
        }

    
                public void Activate()
        {
            _clientApi.Input.RegisterHotKey("toggleMouse", "Toggle Mouse Unlock", GlKeys.F);
            _clientApi.Input.HotKeys["toggleMouse"].Handler += OnToggleMouseHotkey;

            _dialog = new MouseDialog(_clientApi);
        }
        
        private bool OnToggleMouseHotkey(KeyCombination t1)
        {
            _isMouseToggled = !_isMouseToggled;

            if (_dialog?.IsOpened() == true)
            {
                _dialog.TryClose();
            }
            else
            {
               _dialog?.TryOpen();
            }
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