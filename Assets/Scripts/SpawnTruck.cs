using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTruck : MonoBehaviour
{

    public GameObject TruckPrefab;

    private GameObject Truck;

    private void Start()
    {
        Truck = Instantiate(TruckPrefab, transform.position, transform.rotation);
        Truck.transform.localScale = Vector3.Scale(new Vector3(4, 4, 4), transform.lossyScale);
    }

}
