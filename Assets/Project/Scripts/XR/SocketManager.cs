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
        Vector3 lastSocketPosition = socketList[socketList.Count - 1].transform.position;

        //Get other ingredient size
        if (socketList.Count - 1 > 0)
        {
            Ingredient lastIngredient;
            socketList[socketList.Count - 1].firstInteractableSelected.transform.gameObject.TryGetComponent<Ingredient>(out lastIngredient);
            if (lastIngredient)
            {
                print(lastSocketPosition.y);
                print(lastIngredient.transform.localScale.y);
                print(ingredient.transform.lossyScale.y/2);
                print(lastSocketPosition.y + lastIngredient.transform.localScale.y+ (ingredient.transform.lossyScale.y/2));
                lastSocketPosition = new Vector3(lastSocketPosition.x,lastSocketPosition.y+(lastIngredient.transform.localScale.y/2),lastSocketPosition.z);
            }
            else
            {
                Debug.LogError("There is not last ingredient");
            }
        }
        GameObject newSocketObjeect = Instantiate(socketPrefab, new Vector3(lastSocketPosition.x, lastSocketPosition.y+ingredient.transform.lossyScale.y, lastSocketPosition.z), Quaternion.identity, transform);
        XRSocketInteractor socket = newSocketObjeect.GetComponent<XRSocketInteractor>();
        socketList.Add(socket);
    }
}
