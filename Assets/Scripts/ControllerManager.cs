﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour {

    private Vector3 startPos,endPos;

    [SerializeField]
    private Transform throwObj;
    private Transform tmpCash; 
    private Vector3 resetPos;
	// Use this for initialization

    private float dragTime;

    public int force;
    public int distanceFactor;
	void Start () {
        resetPos = throwObj.position;
	}
	
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (startPos != null)
        {
            Vector3 startDraw = Camera.main.ScreenToWorldPoint(startPos + new Vector3(0, 0, 100));
            Vector3 endDraw = Camera.main.ScreenToWorldPoint(endPos + new Vector3(0, 0, 100));
            Gizmos.DrawLine(startDraw, endDraw);
        }
    }

	// Update is called once per frame
	void Update () {
		
        if (Input.GetMouseButtonDown(0))
        {
            resetPosition();
            tmpCash = PoolManager.Inst.CreateCash(resetPos);
            dragTime = 0;
            startPos = Input.mousePosition;
        }

        dragTime += Time.deltaTime;
        if (Input.GetMouseButtonUp(0))
        {
            endPos = Input.mousePosition;

            Vector3 targetDir = startPos - endPos;
            float angle = Vector3.Angle(targetDir, Vector3.left);
            float distance = targetDir.magnitude;
            Vector3 dir = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
            tmpCash.GetComponent<Rigidbody>().AddForce(dir * ( (force/dragTime) * (distance * distanceFactor )));

            Debug.Log("Start : " + startPos + " End : " + endPos + " angle : "+angle);
        }

	}

    private void resetPosition()
    {
        throwObj.position = resetPos;
    }
}
