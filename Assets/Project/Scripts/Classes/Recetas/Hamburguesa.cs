using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Este script son los pasos o reglas a seguir para crear una hamburguesa, esta funcion es llamada por el manager de la receta cada vez que se agrega un ingrediente y poder validar un paso.
/// </summary>
public class Hamburguesa : Receta
{
    public ScreenState screenState;
    public override void ValidarPaso()
    {
        if(!RecipeManager.Instance.Terminada)
        {
            List<GameObject> ingredientesReceta = RecipeManager.Instance.RecetaDeEscena.ingredientesReceta;
            List<Ingredient> ingredientesActuales = RecipeManager.Instance.IngredientesActuales;
            Ingredient ingrediente = ingredientesActuales[ingredientesActuales.Count-1];
            GameObject siguienteIngredienteValido = ingredientesReceta[RecipeManager.Instance.Fase];
            switch (RecipeManager.Instance.Fase)
            {
                case 0:
                    if (ingrediente.originPrefab.name == siguienteIngredienteValido.name)
                    {
                        RecipeManager.Instance.Fase++;
                    }
                    else
                    {
                        //No es el primer pan
                        screenState.SetRedScreen();
                    }
                    break;
                case 1:
                    //Si no es el ultimo pan. Puede ser cualquier pan. Puede trabajarse el codigo con tags en vez de con referencias.
                    if (ingrediente.originPrefab.name != ingredientesReceta[2].name)
                    {
                        //Si es la torta
                        if (ingrediente.name == ingredientesReceta[1].name)
                        {
                            RecipeManager.Instance.Fase++;
                        }
                    }
                    else
                    {
                        //Se ponen 2 panes seguidos
                        screenState.SetRedScreen();
                    }
                    break;
                case 2:
                    if(ingrediente.originPrefab.name == siguienteIngredienteValido.name)
                    {
                        //Se termina la receta con el ultimo pan
                        RecipeManager.Instance.Fase++;
                        RecipeManager.Instance.Terminada = true;
                        RecipeManager.Instance.DONE.SetActive(true);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
