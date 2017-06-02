using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {
    private CharacterModel model;

    private void Awake()
    {
        model = new CharacterModel();
        model.atk = 10;
        model.speed = 5;
        model.name = "role0";
        model.resourcePath = "Prefabs/Cube";
        GameObject go = new GameObject(model.name);
        CharacterCtl ctl = go.AddComponent<CharacterCtl>();
        ctl.Init(model);
    }

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
