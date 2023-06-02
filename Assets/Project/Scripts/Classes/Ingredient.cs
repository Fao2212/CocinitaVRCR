using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


[System.Serializable]
public class Ingredient : MonoBehaviour
{
    private Renderer renderer;
    public bool opcional;
    public GameObject originPrefab;
    private float timeToDissapear = 2;
    private float aumentoDeTiempo = 0.01f;
    private float tiempoDeBorrarActual = 0;

        
    // Start is called before the first frame update
    void Start()
    {
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
