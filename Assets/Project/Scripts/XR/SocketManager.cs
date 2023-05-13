using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketManager : MonoBehaviour
{
    public GameObject socketPrefab;
    public List<XRSocketInteractor> socketList;
    public XRInteractionManager interactionManager;
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
    public void  CreateSocketAndRemoveGrabbable(Ingredient ingredient)
    {
        Vector3 lastSocketPosition = socketList[socketList.Count-1].transform.position;
        GameObject newSocketObjeect = Instantiate(socketPrefab, new Vector3(lastSocketPosition.x, lastSocketPosition.y+ingredient.transform.lossyScale.y, lastSocketPosition.z), Quaternion.identity, transform);
        XRSocketInteractor socket = newSocketObjeect.GetComponent<XRSocketInteractor>();
        socketList.Add(socket);
    }
}
