using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buscaTorta : MonoBehaviour
{
    private int nextUpdate;
    private Torta torta;
    // Start is called before the first frame update
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
        }
    }
    private void OnTriggerEnter(Collider other)
    { 
        torta = other.GetComponent<Torta>();
        if (torta != null) Debug.Log("Recibio torta");
    }

    private void OnTriggerExit(Collider other)
    {
        torta = other.GetComponent<Torta>();
        if (torta != null) torta = null;

    }
}
