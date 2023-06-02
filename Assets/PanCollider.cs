using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanCollider : MonoBehaviour
{
    private int nextUpdate;
    private Torta torta;

    void Start()
    {
        nextUpdate = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // If the next update is reached
        if (Time.time >= nextUpdate)
        { 
            // Change the next update (current second+1)
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            // Call your fonction
            if (torta != null) torta.Cocinar();
            else Debug.Log("No torta aun");
        }
    }

    private void onTriggerEnter(Collider other)
    {
        Debug.Log("Debug");
        torta = other.GetComponent<Torta>();
        if (torta != null) Debug.Log("Recibio torta");
        else Debug.Log("No recibio torta");
    }
}
