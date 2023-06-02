using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketManager : MonoBehaviour
{
    public GameObject socketPrefab;
    public List<XRSocketInteractor> socketList;
    public XRSocketInteractor firstSocket;
    public static SocketManager Instance { get; private set; }

    public void ResetSockets()
    {
        foreach(XRSocketInteractor socket in socketList)
        {
            if(socket.gameObject != firstSocket.gameObject)
            {
                Destroy(socket.gameObject);
            }
        }
        socketList = new();
        socketList.Add(firstSocket);
    }    

    private void Awake()
    {   
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            print("Error 2 Instances");
        }
    }
    public void CreateSocketAndRemoveGrabbable(Ingredient ingredient)
    {
        XRSocketInteractor lastSocket = socketList[socketList.Count - 1];
        ////Get other ingredient size
        //if (socketList.Count - 1 > 0)
        //{
        //    Ingredient lastIngredient;
        //    XRSocketInteractor lastIngredientSocket = socketList[socketList.Count - 2];
        //    //lastSocket.transform.Translate(new Vector3(0, 0, 0), Space.Self);
        //    lastIngredientSocket.firstInteractableSelected.transform.gameObject.TryGetComponent<Ingredient>(out lastIngredient);
        //    if (lastIngredient)
        //    {
        //        lastSocket.transform.position = lastIngredientSocket.transform.position;
        //        lastSocket.transform.position = new Vector3(lastSocket.transform.position.x, lastSocket.transform.position.y+ingredient.transform.lossyScale.y/2+lastIngredient.transform.lossyScale.y/2, lastSocket.transform.position.z);
        //    }
        //    else
        //    {
        //        Debug.LogError("There is not last ingredient");
        //    }
        //}
        //Remove hand interaction with ingredient
        ingredient.gameObject.GetComponent<XRGrabInteractable>().interactionLayers = InteractionLayerMask.GetMask("LockedIngredient");
        ingredient.gameObject.GetComponent<XRGrabInteractable>().selectMode = InteractableSelectMode.Single;
        ingredient.gameObject.layer = LayerMask.NameToLayer("Default"); ;

        GameObject newSocketObjeect = Instantiate(socketPrefab, new Vector3(lastSocket.transform.position.x, lastSocket.transform.position.y + ingredient.transform.lossyScale.y, lastSocket.transform.position.z), Quaternion.identity, transform);
        XRSocketInteractor socket = newSocketObjeect.GetComponent<XRSocketInteractor>();
        socketList.Add(socket);



    }
}
