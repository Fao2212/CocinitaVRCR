using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basurero : MonoBehaviour
{
    [SerializeField]
    private GameObject Bombazo;

    private void OnTriggerEnter(Collider inObject) {
        if (inObject != null) {
            Rigidbody r;

            inObject.TryGetComponent<Rigidbody>(out r);

            if (r != null)
            {
                inObject.gameObject.transform.position = Bombazo.transform.position;

                r = gameObject.GetComponent<Rigidbody>();
                r.AddForce(Bombazo.transform.forward * 30, ForceMode.Impulse);
            }
        }
    }
}
