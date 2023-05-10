using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamburguesa : Receta
{
    protected override void ValidarReceta()
    {
        if(!terminada)
        {
            Ingredient ingrediente = ingredientesActuales[ingredientesActuales.Count];
            Ingredient siguienteIngredienteValido = ingredientesReceta[fase];
            switch (fase)
            {
                case 0:
                    if (ingrediente == siguienteIngredienteValido)
                    {
                        fase++;
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
                    if (ingrediente != ingredientesReceta[2])
                    {
                        //Si es la torta
                        if (ingrediente == ingredientesReceta[1])
                        {
                            fase++;
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
                    if(ingrediente == siguienteIngredienteValido)
                    {
                        //Se termina la receta con el ultimo pan
                        fase++;
                        terminada = true;
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
