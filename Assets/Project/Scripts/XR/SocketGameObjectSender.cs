using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketGameObjectSender : MonoBehaviour
{

    public XRSocketInteractor socket;
    public bool locked = false;


    private void FixedUpdate()
    {
        if (socket.hasHover && !locked)
        {
                gameObject.transform.rotation = socket.interactablesHovered[socket.interactablesHovered.Count-1].transform.rotation;
                gameObject.transform.position = socket.interactablesHovered[socket.interactablesHovered.Count - 1].transform.position;
        }
    }

    public void SendGameObject()
    {

            Ingredient ingrediente;
            if(socket.firstInteractableSelected.transform.gameObject.TryGetComponent<Ingredient>(out ingrediente))
            {
            locked = true;
                RecipeManager.Instance.AgregarIngrediente(ingrediente);
                SocketManager.Instance.CreateSocketAndRemoveGrabbable(ingrediente);
                socket.showInteractableHoverMeshes = false;
            }
            else
            {
                Debug.LogError("No es un ingrediente");
            }

    }

}
