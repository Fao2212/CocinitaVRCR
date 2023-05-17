using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using EzySlice;

public class BreadCutter : MonoBehaviour
{

    public GameObject plane;
    public bool cutted;
    public int hands;
    public GameObject LeftHand;
    public GameObject RightHand;

    private void Update()
    {
        if(hands == 1)
        {
            plane.SetActive(true);
        }
        else
        {
            if(plane.activeInHierarchy)
                plane.SetActive(false);
        }
    }

    public void GrabTheBreada()
    {
        AddHand();
        if(hands == 2 && !cutted) 
        {
            Vector3 direction = RightHand.transform.position - LeftHand.transform.position;
            plane.transform.LookAt(direction.normalized);
            cutted = true;
            SlicedHull hull = gameObject.Slice(plane.transform.position,plane.transform.up);
            GameObject upperObject = hull.CreateUpperHull(gameObject, null);
            GameObject lowerObject = hull.CreateLowerHull(gameObject, null);
            AddHullComponents(upperObject);
            AddHullComponents(lowerObject);
            Destroy(gameObject);
        }
    }

    public void AddHand()
    {
        hands += 1;
    }

    public void RemoveHand()
    {
        hands -= 1;
    }

    public void AddHullComponents(GameObject hullObject)
    {
        MeshCollider collider = hullObject.AddComponent<MeshCollider>();
        collider.convex = true;
        XRGrabInteractable interactable = hullObject.AddComponent<XRGrabInteractable>();
        interactable.interactionLayers = InteractionLayerMask.GetMask("Ingredients");
    }


}
