using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckController : MonoBehaviour
{
    public float speed;
    public SpawnTruck parent;

    private int counter;

    void Start()
    {
        counter = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PackageController>())
        {
            counter++;
            other.transform.SetParent(transform);
            if (counter >= 5)
            {
                StartCoroutine(Driving());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PackageController>())
        {
            --counter;
            other.transform.SetParent(null);
        }
    }

    private IEnumerator Driving()
    {
        parent.RequestNew();
        GameObject.Destroy(gameObject, 8.0f);
        while (true) 
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            yield return null;
        }
    }

}
