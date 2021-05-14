// GENERATED AUTOMATICALLY FROM 'Assets/Controls/Elf Control.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ElfControl : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ElfControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Elf Control"",
    ""maps"": [
        {
            ""name"": ""Game Controls"",
            ""id"": ""7e59ff90-b21f-43f8-a8a5-39ebb4ce358d"",
            ""actions"": [
                {
                    ""name"": ""Moventment"",
                    ""type"": ""Value"",
                    ""id"": ""d9ea5206-d40b-4ca2-868f-964ff52ecb5a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""23cc3ad9-aa72-4452-827d-01a70bd0e4e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4d279b7d-077c-4d22-b51c-01cdf7b15121"",
                    ""path"": ""<DualShockGamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moventment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c9a38920-b27a-4194-a517-94900d270673"",
                    ""path"": ""<DualShockGamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""New action map"",
            ""id"": ""d0993eb9-8173-481d-a6ba-6c8986f058de"",
            ""actions"": [
                {
                    ""name"": ""mouse"",
                    ""type"": ""Button"",
                    ""id"": ""d478edec-5672-4244-9584-85c777986368"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e53168ff-df48-49fa-acfd-b967bb967d2d"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""New control scheme"",
            ""bindingGroup"": ""New control scheme"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Game Controls
        m_GameControls = asset.FindActionMap("Game Controls", throwIfNotFound: true);
        m_GameControls_Moventment = m_GameControls.FindAction("Moventment", throwIfNotFound: true);
        m_GameControls_Shoot = m_GameControls.FindAction("Shoot", throwIfNotFound: true);
        // New action map
        m_Newactionmap = asset.FindActionMap("New action map", throwIfNotFound: true);
        m_Newactionmap_mouse = m_Newactionmap.FindAction("mouse", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Game Controls
    private readonly InputActionMap m_GameControls;
    private IGameControlsActions m_GameControlsActionsCallbackInterface;
    private readonly InputAction m_GameControls_Moventment;
    private readonly InputAction m_GameControls_Shoot;
    public struct GameControlsActions
    {
        private @ElfControl m_Wrapper;
        public GameControlsActions(@ElfControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Moventment => m_Wrapper.m_GameControls_Moventment;
        public InputAction @Shoot => m_Wrapper.m_GameControls_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_GameControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameControlsActions set) { return set.Get(); }
        public void SetCallbacks(IGameControlsActions instance)
        {
            if (m_Wrapper.m_GameControlsActionsCallbackInterface != null)
            {
                @Moventment.started -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnMoventment;
                @Moventment.performed -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnMoventment;
                @Moventment.canceled -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnMoventment;
                @Shoot.started -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnShoot;
            }
            m_Wrapper.m_GameControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Moventment.started += instance.OnMoventment;
                @Moventment.performed += instance.OnMoventment;
                @Moventment.canceled += instance.OnMoventment;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
            }
        }
    }
    public GameControlsActions @GameControls => new GameControlsActions(this);

    // New action map
    private readonly InputActionMap m_Newactionmap;
    private INewactionmapActions m_NewactionmapActionsCallbackInterface;
    private readonly InputAction m_Newactionmap_mouse;
    public struct NewactionmapActions
    {
        private @ElfControl m_Wrapper;
        public NewactionmapActions(@ElfControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @mouse => m_Wrapper.m_Newactionmap_mouse;
        public InputActionMap Get() { return m_Wrapper.m_Newactionmap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(NewactionmapActions set) { return set.Get(); }
        public void SetCallbacks(INewactionmapActions instance)
        {
            if (m_Wrapper.m_NewactionmapActionsCallbackInterface != null)
            {
                @mouse.started -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnMouse;
                @mouse.performed -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnMouse;
                @mouse.canceled -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnMouse;
            }
            m_Wrapper.m_NewactionmapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @mouse.started += instance.OnMouse;
                @mouse.performed += instance.OnMouse;
                @mouse.canceled += instance.OnMouse;
            }
        }
    }
    public NewactionmapActions @Newactionmap => new NewactionmapActions(this);
    private int m_NewcontrolschemeSchemeIndex = -1;
    public InputControlScheme NewcontrolschemeScheme
    {
        get
        {
            if (m_NewcontrolschemeSchemeIndex == -1) m_NewcontrolschemeSchemeIndex = asset.FindControlSchemeIndex("New control scheme");
            return asset.controlSchemes[m_NewcontrolschemeSchemeIndex];
        }
    }
    public interface IGameControlsActions
    {
        void OnMoventment(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
    }
    public interface INewactionmapActions
    {
        void OnMouse(InputAction.CallbackContext context);
    }
}
