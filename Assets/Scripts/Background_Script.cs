﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Script : MonoBehaviour {
    public float baseScrollSpeed;
    public float fastScrollSpeed;
    public float scrollSpeed;
    public PlayerMovement playerMovement;
    public Sprite[] oceanSprites;
    private Vector3 screenBottomLeft;
    private Vector3 screenUpperRight;
    private Vector3 startPosition;
    private float xBounds;
    private float yBounds;
	// Use this for initialization
	void Start () {
        xBounds = GetComponent<SpriteRenderer>().bounds.size.x;
        yBounds = GetComponent<SpriteRenderer>().bounds.size.y;

        screenBottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 1));
        screenUpperRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 1));
        startPosition = transform.position;
        scrollSpeed = baseScrollSpeed;

        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        RandomSprite();
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate((Vector3.left + Vector3.down) * scrollSpeed * Time.deltaTime);

        if (transform.position.x < screenBottomLeft.x - xBounds/ 2)
        {
            transform.position = new Vector3(screenUpperRight.x + xBounds, transform.position.y, startPosition.z);
            RandomSprite();
        }
        if (transform.position.y < screenBottomLeft.y - yBounds / 2)
        {
            transform.position = new Vector3(startPosition.x, screenUpperRight.y + yBounds, startPosition.z);
            RandomSprite();
        }

        if (playerMovement.IsSurfing())
        {
            scrollSpeed = fastScrollSpeed;
        }
        else
        {
            scrollSpeed = baseScrollSpeed;
        }
	}

    void RandomSprite()
    {
        int choice = Random.Range(0, oceanSprites.Length - 1);
        GetComponent<SpriteRenderer>().sprite = oceanSprites[choice];
    }
}
