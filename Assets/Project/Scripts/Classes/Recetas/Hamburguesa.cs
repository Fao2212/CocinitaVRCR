using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Este script son los pasos o reglas a seguir para crear una hamburguesa, esta funcion es llamada por el manager de la receta cada vez que se agrega un ingrediente y poder validar un paso.
/// </summary>
public class Hamburguesa : Receta
{
    public override void ValidarPaso()
    {
        if(!RecipeManager.Instace.Terminada)
        {
            List<GameObject> ingredientesReceta = RecipeManager.Instace.RecetaDeEscena.ingredientesReceta;
            List<Ingredient> ingredientesActuales = RecipeManager.Instace.IngredientesActuales;
            Ingredient ingrediente = ingredientesActuales[ingredientesActuales.Count-1];
            GameObject siguienteIngredienteValido = ingredientesReceta[RecipeManager.Instace.Fase];
            switch (RecipeManager.Instace.Fase)
            {
                case 0:
                    if (ingrediente.originPrefab.name == siguienteIngredienteValido.name)
                    {
                        RecipeManager.Instace.Fase++;
                        Debug.Log("Se agrega el primer pan");
                    }
                    else
                    {
                        //No es el primer pan
                        Debug.Log("No es el primer pan");
                    }
                    break;
                case 1:
                    //Si no es el ultimo pan. Puede ser cualquier pan. Puede trabajarse el codigo con tags en vez de con referencias.
                    if (ingrediente.originPrefab != ingredientesReceta[2])
                    {
                        //Si es la torta
                        if (ingrediente.name == ingredientesReceta[1].name)
                        {
                            RecipeManager.Instace.Fase++;
                            Debug.Log("Se agrega la torta");
                        }
                    }
                    else
                    {
                        //Se ponen 2 panes seguidos
                        Debug.Log("Se ponen 2 panes seguidos");
                    }
                    break;
                case 2:
                    if(ingrediente.originPrefab.name == siguienteIngredienteValido.name)
                    {
                        //Se termina la receta con el ultimo pan
                        RecipeManager.Instace.Fase++;
                        RecipeManager.Instace.Terminada = true;
                    }
                    else
                    {
                        Debug.Log("Termino la receta con el pan");
                    }
                    break;
                default:
                    Debug.Log("Ya la receta termino");
                    break;
            }
        }
    }

}
