using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Este script es la clase abstracta de donde heredan los nuevos scripts con funciones para validar las recetas. Debe de ser agregado a cada uno de los ScriptablesObjects de las recetas.
/// </summary>
public abstract class Receta:MonoBehaviour
{
    public List<GameObject> ingredientesReceta;
    [SerializeField]
    protected bool isInOrden;
    public abstract void ValidarPaso();
}
