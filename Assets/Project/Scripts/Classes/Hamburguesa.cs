using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamburguesa : Receta
{
    public override void ValidarReceta(Ingredient ingrediente)
    {
        throw new System.NotImplementedException();
        //Se necesita un pan de primero en la lista
        //Se van a gregando interiente pero cuando se agrega un pan se tacha el primero y busca una torta
       
        //If primero es pan pasa a seguunda condicion.
        //If no es torta and not pan pasa a tercera.
        //If pan termina receta.

        //expresiones regulares es muy buena opcion. Se conecta la cadena de string con nombres de ingredientes y se aplica expresionees regulares.
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
