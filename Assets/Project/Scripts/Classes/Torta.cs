using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torta : MonoBehaviour
{
    private Renderer renderer;
    public List<Material> materiales;
    private int tiempoCocinando = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Cocinar()
    {
        if (tiempoCocinando >= 5 && tiempoCocinando <= 15) renderer.material = materiales[1];
        else if (tiempoCocinando > 15  && tiempoCocinando <= 20) renderer.material = materiales[2];
        else if (tiempoCocinando > 20) renderer.material = materiales[3];
        tiempoCocinando++;
    }
}
