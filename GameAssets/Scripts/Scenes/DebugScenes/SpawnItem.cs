using System.IO;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public GameObject testPrefab;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        var loadPath = "items/HealthPotion";
        Debug.Log($"Loading asset from {loadPath}");
        var thing = Resources.Load(loadPath);
        Instantiate(thing, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
