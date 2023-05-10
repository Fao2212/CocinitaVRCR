using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Receta : MonoBehaviour
{
    //Soolo vayan los ingredientes obligatorios
    //Todo lo que sea opcional no importa
    //O una validacion rapida que ingrediente tenga un id y que el id este orodendo de mayor a mneor y se valida que le ingrediente sea de mayor a menor
    public List<Ingredient> ingredientesReceta;
    public List<Ingredient> ingredientesActuales;
    [SerializeField]
    protected bool terminada;
    //Ve si los ingredientes tienen que ir en un orden especifico o se peuden agregar a lo loco
    [SerializeField]
    protected bool isInOrden;

    private void Start()
    {
        ingredientesActuales = new();
    }

    public void AgregarIngrediente(Ingredient ingredient)
    {
        ingredientesActuales.Add(ingredient);
    }

    public void ValidarIngrediente(Ingredient ingredient)
    {

    }

    public void RemoverIngrediente(Ingredient ingrediente)
    {

    }

    public abstract void ValidarReceta(Ingredient ingrediente);


}
