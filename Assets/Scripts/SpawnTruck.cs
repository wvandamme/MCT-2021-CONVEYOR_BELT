using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTruck : MonoBehaviour
{

    public GameObject TruckPrefab;
    public Canvas Gui;

    private GameObject Truck = null;

    private void Start()
    {
        Spawn();
        Gui.gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Camera>())
        {
            Gui.gameObject.SetActive(Truck == null);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Camera>())
        {
            Gui.gameObject.SetActive(false);
        }
    }

    public void RequestNew()
    {
        Truck = null;
    }

    public void Spawn()
    {
        Truck = Instantiate(TruckPrefab, transform.position, transform.rotation);
        Truck.transform.localScale = Vector3.Scale(new Vector3(4, 4, 4), transform.lossyScale);
        Truck.GetComponent<TruckController>().parent = this;
    }

}
