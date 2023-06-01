using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketGameObjectSender : MonoBehaviour
{

    public XRSocketInteractor socket;


    private void Update()
    {
        if (socket.firstInteractableSelected != null)
        {
            socket.attachTransform.rotation = socket.firstInteractableSelected.transform.rotation;
        }
        
    }

    public void SendGameObject()
    {

            Ingredient ingrediente;
            if(socket.firstInteractableSelected.transform.gameObject.TryGetComponent<Ingredient>(out ingrediente))
            {
                RecipeManager.Instance.AgregarIngrediente(ingrediente);
                SocketManager.Instance.CreateSocketAndRemoveGrabbable(ingrediente);
            }
            else
            {
                Debug.LogError("No es un ingrediente");
            }

    }

}
