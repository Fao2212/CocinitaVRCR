using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Singleton que maneja receta actual en la escena. Es necesario agregar una receta para que funcione.
/// </summary>
/// 
[RequireComponent(typeof(Receta))]
public class RecipeManager : MonoBehaviour
{
    public static RecipeManager Instance { get; private set;}
    [field:SerializeField]
    public Receta RecetaDeEscena { get; set; }
    public List<Ingredient> IngredientesActuales { get; set; }
    public int Fase { get; set; }
    [SerializeField]
    public bool Terminada { get; set; }

    public UnityEvent ingredientAddedEvent;
    public UnityEvent ingredientRemovedEvent;

    public void AgregarIngrediente(Ingredient ingredient)
    {
        IngredientesActuales.Add(ingredient);
        RecetaDeEscena.ValidarPaso();
        ingredientAddedEvent.Invoke();
    }

    public void RemoverIngrediente(Ingredient ingrediente)
    {
        IngredientesActuales.Remove(ingrediente);
        ingredientRemovedEvent.Invoke();
    }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            Instance.RecetaDeEscena = GetComponent<Receta>();
            IngredientesActuales = new();
        }
        else
        {
            Debug.LogError("Error, there is more than one Instance of the RecipeManager. Should be a Singleton");
        }
    }
}
