using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTest : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        for (int i = 0; i < 10; i++)
        {
            Object go = ResourcesManager.I.LoadObject("Prefabs/Cube");
            if (go)
            {
                GameObject.Instantiate(go);
            }
        }
        for (int i = 0; i < 10; i++)
        {
            Object go = ResourcesManager.I.LoadObject("Prefabs/Cube1");
            if (go)
            {
                GameObject.Instantiate(go);
            }
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
