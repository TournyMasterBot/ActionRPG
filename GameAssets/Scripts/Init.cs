using Assets.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Initialize();
        var pingOutput = StateManager.GrpcClient.PingServer();
        pingOutput.Wait();
        Debug.Log($"Ping Output: {pingOutput.Result.Timestamp}");       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
