﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCorrupter : MonoBehaviour {
    [HideInInspector]
    public CorrupterSpawnerManager CorrupterManager;
    [HideInInspector]
    public int CorrupterID;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
    virtual protected void Update () {
//        transform.Translate(Vector3.left * Time.deltaTime);
	}

    virtual protected void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.tag == "cash")
        {
            CorrupterManager.Despawn(this);
            col.gameObject.SetActive(false);
        }
    }
}