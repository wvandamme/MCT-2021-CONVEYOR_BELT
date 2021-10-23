using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    public Canvas SpawnCanvas;
    public Material RedMaterial;
    public Material GreenMaterial;
    public Material BlueMaterial;
    public Material YellowMaterial;
    public GameObject PackagePrefab;

    private void OnEnable()
    {
        SpawnCanvas.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Camera>())
        {
            SpawnCanvas.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Camera>())
        {
            SpawnCanvas.gameObject.SetActive(false);
        }
    }

    public void SpawnRed()
    {
        SpanwPackage(RedMaterial);
    }

    public void SpawnGreen()
    {
        SpanwPackage(GreenMaterial);
    }

    public void SpawnBlue()
    {
        SpanwPackage(BlueMaterial);
    }

    public void SpawnYellow()
    {
        SpanwPackage(YellowMaterial);
    }

    private void SpanwPackage(Material material)
    {
        GameObject obj = Instantiate(PackagePrefab, transform.position, Quaternion.identity);
        obj.transform.localScale = Vector3.Scale(obj.transform.localScale, transform.lossyScale);
        MeshRenderer renderer = obj.GetComponent<MeshRenderer>();
        renderer.material = material;
        Object.Destroy(obj, 20);
    }

}
