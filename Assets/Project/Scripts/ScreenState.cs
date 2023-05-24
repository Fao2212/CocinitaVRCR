using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenState : MonoBehaviour
{
    public Material goodIngredientMaterial;
    public Material badIngredientMaterial;

    public void SetGreenScreen()
    {
        GetComponent<Renderer>().material = goodIngredientMaterial;
    }

    public void SetRedScreen()
    {
        GetComponent<Renderer>().material = badIngredientMaterial;
    }
}
