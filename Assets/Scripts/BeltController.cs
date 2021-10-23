using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltController : MonoBehaviour
{

    public float speed = 3.0f;
    public Transform TargetPosition;

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PackageController>())
        {
           float scaled_speed = System.Math.Abs(Vector3.Dot((other.transform.position - TargetPosition.position).normalized, other.transform.lossyScale));
           other.transform.position = Vector3.MoveTowards(other.transform.position, TargetPosition.position, speed * Time.deltaTime * scaled_speed);
        }
    }

}
