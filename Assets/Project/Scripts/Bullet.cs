using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Rigidbody objectRigidBody;
    private float force = 30;

    public void Shoot(Vector3 forward)
    {
        objectRigidBody = gameObject.GetComponent<Rigidbody>();
        objectRigidBody.AddForce(forward*force,ForceMode.Impulse);
    }

}
