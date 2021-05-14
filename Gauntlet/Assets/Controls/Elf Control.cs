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
        }
    ],
    ""controlSchemes"": []
}");
        // Game Controls
        m_GameControls = asset.FindActionMap("Game Controls", throwIfNotFound: true);
        m_GameControls_Moventment = m_GameControls.FindAction("Moventment", throwIfNotFound: true);
        m_GameControls_Shoot = m_GameControls.FindAction("Shoot", throwIfNotFound: true);
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
    public interface IGameControlsActions
    {
        void OnMoventment(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
    }
}
