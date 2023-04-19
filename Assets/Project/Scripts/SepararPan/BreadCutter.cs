using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using EzySlice;

public class BreadCutter : MonoBehaviour
{

    public XRGrabInteractable interactable;
    public GameObject plane;
    public bool cutted;

    public void GrabTheBreada()
    {
        if(interactable.multipleGrabTransformersCount == 2 && !cutted) 
        {
            cutted = true;
            SlicedHull hull = gameObject.Slice(plane.transform.position,plane.transform.up);
            GameObject upperObject = hull.CreateUpperHull(gameObject, null);
            GameObject lowerObject = hull.CreateLowerHull(gameObject, null);
        }
    }

    public void AddHullComponents(GameObject hullObject)
    {
        Rigidbody rb = hullObject.AddComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        MeshCollider collider = hullObject.AddComponent<MeshCollider>();
        collider.convex = true;
    }


}
