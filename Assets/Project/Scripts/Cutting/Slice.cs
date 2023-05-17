using EzySlice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Slice : MonoBehaviour
{

    public LayerMask layerMask;
    public float cutCooldown = .5f;
    public bool inCooldown;
    //Size of the edge
    public Material tempMaterial;
    public bool canCut;
    public XRInteractionManager interactionManager;

    public IEnumerator Cooldown()
    {
        inCooldown = true;
        yield return new WaitForSeconds(cutCooldown);
        inCooldown = false;
    }

    public void SliceIngredient()
    {
        if(!inCooldown && canCut)
        {
           StartCoroutine(Cooldown());
            Vector3 cutterPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y-0.5f, gameObject.transform.position.z);
            Collider[] hits = Physics.OverlapBox(gameObject.transform.position, transform.localScale, gameObject.transform.rotation, layerMask);
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
        MeshCollider collider = hullObject.AddComponent<MeshCollider>();
        collider.convex = true;
        XRGrabInteractable grabInteractable = hullObject.AddComponent<XRGrabInteractable>();
        grabInteractable.interactionLayers = InteractionLayerMask.GetMask("Ingredients");
    }

    public SlicedHull cutObject(GameObject objectToCut, Material crossSectionMaterial = null)
    {
        return objectToCut.Slice(gameObject.transform.position, gameObject.transform.up, crossSectionMaterial);
    }

    private void Update()
    {
        SliceIngredient();
    }

    public void CutOn()
    {
        canCut = true;
    }

    public void CutOff()
    {
        canCut = false;
    }

}
