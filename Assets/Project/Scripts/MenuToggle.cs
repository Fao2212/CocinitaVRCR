using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuToggle : MonoBehaviour
{
    public InputAction _trigger;
    public InputActionAsset inputActions;
    public Canvas menu;
    private void Start()
    {
        _trigger = inputActions.FindActionMap("XRI LeftHand").FindAction("Menu");
        _trigger.Enable();
        _trigger.performed += ToggleMenu;
    }

    public void ToggleMenu(InputAction.CallbackContext context)
    {
        menu.enabled = !menu.enabled;
    }
}
