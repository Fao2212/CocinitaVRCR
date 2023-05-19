using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketManager : MonoBehaviour
{
    public GameObject socketPrefab;
    public List<XRSocketInteractor> socketList;
    public static SocketManager Instance { get; private set; }


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
        //Get other ingredient size
        if (socketList.Count - 1 > 0)
        {
            Ingredient lastIngredient;
            XRSocketInteractor lastIngredientSocket = socketList[socketList.Count - 2];
            lastSocket.transform.Translate(new Vector3(0, 0, 0), Space.Self);
            lastIngredientSocket.firstInteractableSelected.transform.gameObject.TryGetComponent<Ingredient>(out lastIngredient);
            if (lastIngredient)
            {
                lastSocket.transform.position = lastIngredientSocket.transform.position;
                lastSocket.transform.position = new Vector3(lastSocket.transform.position.x, lastSocket.transform.position.y+ingredient.transform.lossyScale.y/2+lastIngredient.transform.lossyScale.y/2, lastSocket.transform.position.z);
            }
            else
            {
                Debug.LogError("There is not last ingredient");
            }
        }
        Vector3 lastSocketPosition = socketList[socketList.Count - 1].transform.position;
        GameObject newSocketObjeect = Instantiate(socketPrefab, new Vector3(lastSocketPosition.x, lastSocketPosition.y + ingredient.transform.lossyScale.y, lastSocketPosition.z), Quaternion.identity, transform);
        XRSocketInteractor socket = newSocketObjeect.GetComponent<XRSocketInteractor>();
        socketList.Add(socket);
    }
}
