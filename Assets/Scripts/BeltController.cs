using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltController : MonoBehaviour
{

    public float speed = 3.0f;
    public Transform TargetPosition;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ENTER");
    }

    private void OnTriggerStay(Collider other)
    {
        other.transform.position = Vector3.MoveTowards(other.transform.position, TargetPosition.position, speed * Time.deltaTime);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("EXIT");
    }

}
