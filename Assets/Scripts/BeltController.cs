using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltController : MonoBehaviour
{

    public float speed = 3.0f;
    public Transform TargetPosition;
    public bool isOn;

    private void OnTriggerStay(Collider other)
    {
        if (isOn)
        {
            other.transform.position = Vector3.MoveTowards(other.transform.position, TargetPosition.position, speed * Time.deltaTime);
        }
    }

    public void StartOperation()
    {
        isOn = true;
    }

    public void StopOperation()
    {
        isOn = false;
    }

}
