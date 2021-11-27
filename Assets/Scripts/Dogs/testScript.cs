using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Dog a = new Boxer(1, 1);
        a.gameObject.transform.position = new Vector3(-6.0811f, -1.2312f, -1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
