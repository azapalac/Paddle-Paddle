﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHandler : MonoBehaviour {
    float currentSpeed = 1f;
    float timer;
    public float spawnRate = 2;
    public GameObject obs;
    public List<GameObject> obsList = new List<GameObject>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        spawnRate = 1.5f / (timer / 60);
        if (spawnRate < 0.1f)
        {
            spawnRate = 0.1f;
        }
        if(timer >= spawnRate)
        {
            
            spawnObs();
            timer = 0;
        }
       
	}
    public void spawnObs()
    {
        float x = Random.Range(100, 300);
        x = x / 100;
        float y = (-1*x) + 4;
       
        Vector2 spawnloc = new Vector2(x, y);
        GameObject obs1 = GameObject.Instantiate(obs, spawnloc, new Quaternion(0, 0, 0, 0));
        obsList.Add(obs1);
        obs1.GetComponent<ObstacleBehaviour>().changeSpeed(currentSpeed);
    }
    public void changeSpeed(float new_)
    {
        foreach (GameObject obs_ in obsList)
        {
            obs_.GetComponent<ObstacleBehaviour>().changeSpeed(new_);
        }
    }

}
