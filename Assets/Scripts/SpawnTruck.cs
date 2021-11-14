using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTruck : MonoBehaviour
{

    public GameObject TruckPrefab;

    private GameObject Truck = null;

    private void Start()
    {
        Spawn();
    }

    public void RequestNew()
    {
        StartCoroutine(SpanwAfter(2.0f));
    }

    public void Spawn()
    {
        Truck = Instantiate(TruckPrefab, transform.position, transform.rotation);
        Truck.transform.parent = transform;
        Truck.transform.localScale = new Vector3(4, 4, 4);
        Truck.GetComponent<TruckController>().parent = this;
    }

    IEnumerator SpanwAfter(float seconds_)
    {
        yield return new WaitForSeconds(seconds_);
        Spawn();
    }

}
