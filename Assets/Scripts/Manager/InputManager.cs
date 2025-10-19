using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    //public PlayerInputManager Controls;

    public bool PauseInput {  get; private set; }

    private PlayerInput PlayerInput;
    private InputAction PauseAction;
    //private InputAction GameplayInput;
    //private InputAction NavigateInput;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        PlayerInput = GetComponent<PlayerInput>();
        PauseAction = PlayerInput.actions["Pause"];

    }

    private void Update()
    {
        PauseInput = PauseAction.WasPressedThisFrame();
        
        
    }
}
