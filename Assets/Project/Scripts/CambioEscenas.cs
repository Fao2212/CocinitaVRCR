using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioEscenas : MonoBehaviour
{
    [SerializeField]
    private GameObject escenaTetrica;
    [SerializeField]
    private GameObject escenaBosque;

    public void setEscenaBosque()
    {
        escenaTetrica.SetActive(false);
        escenaBosque.SetActive(true);
    }
    public void setEscenaTetrica()
    {
        escenaTetrica.SetActive(true);
        escenaBosque.SetActive(false);
    }
    public void setEscenaLimpia()
    {
        escenaTetrica.SetActive(false);
        escenaBosque.SetActive(false);
    }
}
