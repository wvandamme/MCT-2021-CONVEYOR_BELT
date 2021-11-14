using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    public GameObject PackagePrefab;

    private void Start()
    {
        StartCoroutine(SpanwPackage());
    }

    private IEnumerator SpanwPackage()
    {
        for (;;)
        {
            GameObject obj = Instantiate(PackagePrefab, transform.position, Quaternion.identity);
            obj.transform.localScale = Vector3.Scale(obj.transform.localScale, transform.lossyScale);
            Object.Destroy(obj, 20);
            yield return new WaitForSeconds(1.0f);
        }
    }

}
