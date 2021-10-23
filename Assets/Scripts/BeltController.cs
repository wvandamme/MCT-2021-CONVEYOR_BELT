using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltController : MonoBehaviour
{

    public float speed;
    public Transform TargetPosition;

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PackageController>())
        {
           other.transform.position = Vector3.MoveTowards(other.transform.position, TargetPosition.position, speed * Time.deltaTime);
        }
    }

}
