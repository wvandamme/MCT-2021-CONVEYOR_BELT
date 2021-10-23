
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppManager : MonoBehaviour
{

    [System.Serializable]
    public struct ImagePrefab
    {
        public string name;
        public GameObject prefab;
    }

    public GameObject ARCursorPrefab;

    private GameObject ARCursor;

    public void OnEnable()
    {
        ARCursor = Instantiate(ARCursorPrefab, transform);
        ARCursor.SetActive(false);
    }

    public void OnDisable()
    {
        Object.Destroy(ARCursor);
    }

    public void EnableARCursor(Vector3 position, Quaternion rotation)
    {
        ARCursor.SetActive(true);
        ARCursor.transform.position = position;
        ARCursor.transform.rotation = rotation;
    }

    public void DisableARCursor()
    {
        ARCursor.SetActive(false);
    }

    public bool RunsInSimulator()
    {
#if UNITY_EDITOR
        return true;
#else
        return false;
#endif
    }
























    [System.Serializable]
    public class PackageMaterial
    {
        public string name;
        public Material material;
    }

    public GameObject Package;
    public Transform SpawnPoint;
    public Dropdown MaterialSelector;
    public PackageMaterial[] PackageMaterials;
    
    IEnumerator PackageWorker = null;

    private void Start()
    { 
        PackageWorker = PackageWorkerRoutine();
        if (MaterialSelector)
        {
            MaterialSelector.options.Clear();
            foreach (PackageMaterial m in PackageMaterials)
            {
                MaterialSelector.options.Add(new Dropdown.OptionData(m.name));
            }
            MaterialSelector.RefreshShownValue();
        }
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
            GameObject obj = Instantiate(Package, SpawnPoint.position, Quaternion.identity);
            MeshRenderer renderer = obj.GetComponent<MeshRenderer>();
            renderer.material = PackageMaterials[MaterialSelector.value].material;
            yield return new WaitForSeconds(2);
        }
    }





}
