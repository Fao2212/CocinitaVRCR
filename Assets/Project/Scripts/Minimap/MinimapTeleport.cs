using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class MinimapTeleport : MonoBehaviour
{
    public XRRayInteractor rayInteraactor;
    public InputActionAsset inputActions;
    public InputAction _trigger;
    public GameObject player;
    public GameObject city;

    private void Start()
    {
        _trigger = inputActions.FindActionMap("XRI RightHand Interaction").FindAction("Activate");
        _trigger.Enable();
        _trigger.performed += Telerport;
    }

    public void Telerport(InputAction.CallbackContext context)
    {
        //If hits the minimap   
        RaycastHit hit;
        if (rayInteraactor.TryGetCurrent3DRaycastHit(out hit) && hit.transform.gameObject == gameObject)
        {
            Vector3 localHit = transform.InverseTransformPoint(hit.point);
            Debug.Log(localHit);
            player.transform.position = localHit * (city.transform.localScale.magnitude - gameObject.transform.localScale.magnitude);
        }
    }

}
