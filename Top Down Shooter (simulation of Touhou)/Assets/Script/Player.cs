﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //config
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float xPadding = 0.5f;
    [SerializeField] float yPadding = 1f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 20f;
    [SerializeField] float firingInterval = 0.1f;

    Coroutine firingCoroutine;

    float xMin, xMax, yMin, yMax;

    // Use this for initialization
    void Start () {
        SetUpMoveBoundaries();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        Fire();
	}

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).x + xPadding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1,0,0)).x - xPadding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).y + yPadding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0,1,0)).y - yPadding;
    }

    private void Move()
    {
        //declaration of var

        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        //movement
        transform.position = new Vector2(newXPos, newYPos);
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            yield return new WaitForSeconds(firingInterval);
        }
    }
}