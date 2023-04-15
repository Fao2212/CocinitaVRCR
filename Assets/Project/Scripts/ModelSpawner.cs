using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ModelSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject chancla;
    [SerializeField]
    private GameObject taza;
    [SerializeField]
    private GameObject bala;
    private GameObject selectedObject;
    public InputActionAsset inputActions;

    public InputAction _trigger;

    private void Start()
    {
        _trigger = inputActions.FindActionMap("XRI LeftHand Interaction").FindAction("Balacera");
        _trigger.Enable();
        _trigger.performed += Shoot;
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        
        Bullet bullet = Instantiate(selectedObject, gameObject.transform.position,Quaternion.identity).GetComponent<Bullet>();
        bullet.Shoot(gameObject.transform.forward);
    }

    public void SetTaza()
    {
        selectedObject = taza;
    }
    public void SetChancla()
    {
        selectedObject = chancla;
    }

    public void SetBala()
    {
        selectedObject = bala;
    }

}
    