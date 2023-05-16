using EzySlice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slice : MonoBehaviour
{

    public LayerMask layerMask;
    public float cutCooldown = 1;
    public bool inCooldown;
    //Size of the edge
    public Material tempMaterial;

    public IEnumerator Cooldown()
    {
        inCooldown = true;
        yield return new WaitForSeconds(cutCooldown);
        inCooldown = false;
    }

    public void SliceIngredient()
    {
        if(!inCooldown)
        {
            StartCoroutine(Cooldown());
            Collider[] hits = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, gameObject.transform.rotation, layerMask);
            if (hits.Length <= 0)
                return;

            for (int i = 0; i < hits.Length; i++)
            {
                GameObject originalObject = hits[i].gameObject;
                SlicedHull hull = cutObject(originalObject, tempMaterial);

                if (hull != null)
                {
                    GameObject upperObject = hull.CreateUpperHull(originalObject, tempMaterial);
                    GameObject lowerObject = hull.CreateLowerHull(originalObject, tempMaterial);
                    AddHullComponents(upperObject);
                    AddHullComponents(lowerObject);
                    upperObject.layer = 6;
                    lowerObject.layer = 6;
                    Destroy(originalObject);
                }
            }
        }

    }

    public void AddHullComponents(GameObject hullObject)
    {
        //Asign cuttable layer again
        //hullObject.layer = 9;
        Rigidbody rb = hullObject.AddComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        MeshCollider collider = hullObject.AddComponent<MeshCollider>();
        collider.convex = true;
        //rb.AddExplosionForce(100, hullObject.transform.position, 10);
    }

    public SlicedHull cutObject(GameObject objectToCut, Material crossSectionMaterial = null)
    {
        return objectToCut.Slice(gameObject.transform.position, gameObject.transform.up, crossSectionMaterial);
    }

    private void Update()
    {
        SliceIngredient();
    }
}
