using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testscript : MonoBehaviour
{
    public ActionRpg.Client.GameClient.Test Test = new ActionRpg.Client.GameClient.Test();

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Test.Hello);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
