using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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
    public ScreenState screenState;

    public GameObject DONE;
    public GameObject plate;

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

    public void ResetReceta()
    {
        foreach(Ingredient ingrediente in IngredientesActuales)
        {
            Destroy(ingrediente.gameObject);
        }
        IngredientesActuales = new();
        SocketManager.Instance.ResetSockets();
        screenState.SetGreenScreen();
        Fase = 0;
        Terminada = false;
        DONE.SetActive(false);
    }

    public IEnumerator DoneReceta()
    {
        plate.SetActive(false);
        SocketManager.Instance.ResetSockets();
        IngredientesActuales.Reverse();
        foreach (Ingredient ingredient in IngredientesActuales)
        {
            ingredient.RemoveIngredient();
        }
        yield return new WaitForSeconds(2);
        plate.SetActive(true);
        ResetReceta();
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
