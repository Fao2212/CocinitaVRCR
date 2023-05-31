using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public enum Estados
{
    QUEMADO,
    CORTADO,
    COCINADO,
    CRUDO
}

[System.Serializable]
public class Ingredient : MonoBehaviour
{

    private Estados estadoActual;
    public List<Material> materiales;
    public Dictionary<Estados,Material> materialesSegunEstado;
    public float tiempoDeCoccion;
    public float tiempoDeCoccionActual;
    public float tiempoDeQuemado;
    private Renderer renderer;
    public bool opcional;
    public GameObject originPrefab;
    private float timeToDissapear = 2;
    private float aumentoDeTiempo = 0.01f;
    private float tiempoDeBorrarActual = 0;

    public void CambiarEstadoACCortar()
    {
        estadoActual = Estados.CORTADO;
    }

    public void Cocinar()
    {
        if(estadoActual != Estados.QUEMADO)
        {
            tiempoDeCoccionActual += 1;

            if(tiempoDeCoccionActual >= tiempoDeCoccion && estadoActual != Estados.COCINADO)
            {
                CambiarEstadoACocinado();
            }

            if (tiempoDeCoccionActual >= tiempoDeQuemado)
            {
                CambiarEstadoAQuemar();
            }
        }
    }

    public void CambiarEstadoACocinado()
    {
        estadoActual = Estados.COCINADO;
        renderer.material = materialesSegunEstado[estadoActual];
    }

    public void CambiarEstadoAQuemar()
    {
        estadoActual = Estados.QUEMADO;
        renderer.material = materialesSegunEstado[estadoActual];
    }

    // Start is called before the first frame update
    void Start()
    {
        materialesSegunEstado = new();
        int contador = 0;
        //foreach (Estados estado in Enum.GetValues(typeof(Estados)))
        //{
        //    materialesSegunEstado[estado] = materiales[contador];
        //    contador++;
        //}
        renderer = GetComponent<Renderer>();
    }

    public void RemoveIngredient()
    {
        StartCoroutine(RemoveIngredientTask());
    }

    private IEnumerator RemoveIngredientTask()
    {
        Destroy(GetComponent<XRGrabInteractable>());
        Destroy(GetComponent<Rigidbody>());
        while (tiempoDeBorrarActual < timeToDissapear)
        {
            tiempoDeBorrarActual += aumentoDeTiempo;
            yield return new WaitForSeconds(aumentoDeTiempo);
        }
        Destroy(gameObject);
    }

}
