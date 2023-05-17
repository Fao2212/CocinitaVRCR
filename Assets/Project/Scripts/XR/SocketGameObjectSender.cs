using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketGameObjectSender : MonoBehaviour
{
    public void SendGameObject()
    {
        Debug.Log("Sending");
        XRSocketInteractor interactor;
        if (TryGetComponent<XRSocketInteractor>(out interactor))
        {
            Ingredient ingrediente;
            if(interactor.firstInteractableSelected.transform.gameObject.TryGetComponent<Ingredient>(out ingrediente))
            {
                RecipeManager.Instance.AgregarIngrediente(ingrediente);
                SocketManager.Instance.CreateSocketAndRemoveGrabbable(ingrediente);
            }
            else
            {
                Debug.LogError("No es un ingrediente");
            }
        }
        else
        {
            Debug.LogError("No hay interactor");
        }
    }
}
