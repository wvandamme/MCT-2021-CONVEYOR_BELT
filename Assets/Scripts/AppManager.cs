
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    [System.Serializable]
    public class PackageMaterial
    {
        public string name;
        public Material material;
    }

    public GameObject Package;
    public Transform SpawnPoint;
    public PackageMaterial[] PackageMaterials;

    IEnumerator PackageWorker = null;

    void Start()
    {
        PackageWorker = PackageWorkerRoutine();
    }

    public void StartBelts()
    {
        foreach (BeltController belt in GameObject.FindObjectsOfType<BeltController>())
        {
            belt.StartOperation();
        }
    }


    public void StopBelts()
    {
        foreach (BeltController belt in GameObject.FindObjectsOfType<BeltController>())
        {
            belt.StopOperation();
        }
    }

    public void EnableSpawningOfPackages(bool enable_)
    {
        if (enable_)
        {
            StartCoroutine(PackageWorker);
        }
        else
        {
            StopCoroutine(PackageWorker);
        }
    }

    IEnumerator PackageWorkerRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            Instantiate(Package, SpawnPoint.position, Quaternion.identity);
        }
    }

}
