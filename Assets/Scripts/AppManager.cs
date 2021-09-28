using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{

    public GameObject Package;
    public Transform SpawnPoint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Package, SpawnPoint.position, Quaternion.identity);
        }
    }
}
