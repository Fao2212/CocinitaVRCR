using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoCocina : MonoBehaviour
{
    private Rigidbody objectRigidBody;

    public void CrearObjeto()
    {
        objectRigidBody = gameObject.GetComponent<Rigidbody>();
    }
}
