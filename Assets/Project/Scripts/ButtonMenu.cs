using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject queso;
    [SerializeField]
    private GameObject torta;
    [SerializeField]
    private GameObject lechuga;
    [SerializeField]
    private GameObject pan;
    [SerializeField]
    private GameObject tomate;
    [SerializeField]
    private GameObject cuchillo;
    private GameObject selectedObject;
    public GameObject spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void crear() {
        Ingredient obj = Instantiate(selectedObject, spawnPoint.transform.position, transform.rotation).GetComponent<Ingredient>();
    }

    public void setTomate()
    {
        selectedObject = tomate;
        crear();
    }
    public void setPan()
    {
        selectedObject = pan;
        crear();
    }

    public void setLechuga()
    {
        selectedObject = lechuga;
        crear();
    }

    public void setTorta()
    {
        selectedObject = torta;
        crear();
    }

    public void setQueso()
    {
        selectedObject = queso;
        crear();
    }

    public void setCuchillo()
    {
        selectedObject = cuchillo;
        crear();
    }
}
