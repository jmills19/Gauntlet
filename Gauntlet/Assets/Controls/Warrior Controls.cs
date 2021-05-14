// GENERATED AUTOMATICALLY FROM 'Assets/Controls/Warrior Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace WarriorControls
{
    public class @WarriorControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @WarriorControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Warrior Controls"",
    ""maps"": [
        {
            ""name"": ""Game Controls"",
            ""id"": ""b5309165-6b0c-4761-b6cb-4e6fd583267c"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""927f2ee2-0792-448c-9ab0-3d81d9f715ec"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""333fc269-fb55-47df-a70d-14c1d1e273e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""3920fbba-b4ba-4971-8ef2-5054fb22e111"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""69b0eb90-6eb7-443f-ba1d-9340b35d0ca8"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""017d53eb-86b7-4128-b4ba-7b00c3cd9d5c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9acccfcb-f83f-42c6-a0e7-c9a59e83578f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""341c7fdc-83e4-4c50-9208-b7ba97ea0370"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f7a13612-785f-4072-abad-9441a7fdbc8c"",
                    ""path"": ""<Keyboard>/space"",
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
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard Mouse"",
            ""bindingGroup"": ""Keyboard Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Game Controls
            m_GameControls = asset.FindActionMap("Game Controls", throwIfNotFound: true);
            m_GameControls_Movement = m_GameControls.FindAction("Movement", throwIfNotFound: true);
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
        private readonly InputAction m_GameControls_Movement;
        private readonly InputAction m_GameControls_Shoot;
        public struct GameControlsActions
        {
            private @WarriorControls m_Wrapper;
            public GameControlsActions(@WarriorControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_GameControls_Movement;
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
                    @Movement.started -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnMovement;
                    @Shoot.started -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnShoot;
                    @Shoot.performed -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnShoot;
                    @Shoot.canceled -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnShoot;
                }
                m_Wrapper.m_GameControlsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @Shoot.started += instance.OnShoot;
                    @Shoot.performed += instance.OnShoot;
                    @Shoot.canceled += instance.OnShoot;
                }
            }
        }
        public GameControlsActions @GameControls => new GameControlsActions(this);
        private int m_KeyboardMouseSchemeIndex = -1;
        public InputControlScheme KeyboardMouseScheme
        {
            get
            {
                if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard Mouse");
                return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
            }
        }
        private int m_ControllerSchemeIndex = -1;
        public InputControlScheme ControllerScheme
        {
            get
            {
                if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
                return asset.controlSchemes[m_ControllerSchemeIndex];
            }
        }
        public interface IGameControlsActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnShoot(InputAction.CallbackContext context);
        }
    }
}
