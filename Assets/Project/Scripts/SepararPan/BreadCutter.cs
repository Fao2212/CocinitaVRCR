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
    public MeshRenderer planeRenderer;
    private Ingredient originalIngredient;

    private void Start()
    {
        planeRenderer = plane.GetComponent<MeshRenderer>();
        originalIngredient = GetComponent<Ingredient>().originPrefab.GetComponent<Ingredient>();
        originalIngredient = originalIngredient.originPrefab.GetComponent<Ingredient>();
    }

    private void Update()
    {
        if(hands == 1)
        {
            if(!planeRenderer.enabled)
            {
                planeRenderer.enabled = true;
            }
            Vector3 direction = RightHand.transform.position - LeftHand.transform.position;
            plane.transform.LookAt(direction.normalized);
        }
        else
        {
            planeRenderer.enabled = false;
        }
    }

    public void GrabTheBreada()
    {
        AddHand();
        if(hands == 2 && !cutted) 
        {
            cutted = true;
            SlicedHull hull = gameObject.Slice(plane.transform.position,plane.transform.up);
            GameObject upperObject = hull.CreateUpperHull(gameObject, gameObject.GetComponent<Renderer>().material);
            GameObject lowerObject = hull.CreateLowerHull(gameObject, gameObject.GetComponent<Renderer>().material);
            AddHullComponents(upperObject);
            AddHullComponents(lowerObject);
            Destroy(gameObject);
        }
    }

    public void AddHand()
    {
        hands += 1;
        print("Number Of Hands:"+hands);
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
        Ingredient ingredient = hullObject.AddComponent<Ingredient>();
        ingredient.tiempoDeCoccion = originalIngredient.tiempoDeCoccion;
        ingredient.tiempoDeCoccionActual = originalIngredient.tiempoDeCoccionActual;
        ingredient.tiempoDeQuemado = originalIngredient.tiempoDeQuemado;
        ingredient.opcional = originalIngredient.opcional;
        ingredient.originPrefab = originalIngredient.originPrefab;
    }


}
