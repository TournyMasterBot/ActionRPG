using Assets.Scripts.Managers;
using System;
using UnityEngine;

public class Init : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Initialize();
        StateManager.GrpcClient.PingServer().ContinueWith((output) =>
        {
            try
            {
                Debug.Log($"Ping Output: {output.Result.Timestamp}");
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
        });

        StateManager.GrpcClient.GetItem("f2e684ec-d051-46bd-afb9-aba260691e79").ContinueWith((output) =>
        {
            try
            {
                Debug.Log($"GetItem Output: {output.Result.Payload}");
            }
            catch(Exception ex)
            {
                Debug.LogException(ex);
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
