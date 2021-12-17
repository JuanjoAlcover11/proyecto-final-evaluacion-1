using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float velocidad = 15f;
    private float turnSpeed = 30f;

    private float horizontalInput;
    private float verticalInput;
    private float leftRange = -200f;
    private float rightRange = 200f;
    private float downRange = 0f;
    private float upRange = 200f;
    private float z1Range = -200f;
    private float z2Range = 200f;

    public GameObject projectilPrefab;

    private Vector3 offset = new Vector3(0, 100, 0);

    private int counter = 0;

    void Start()
    {
        transform.position = offset;
    }

    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");

        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);

        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);

        transform.Rotate(Vector3.left, turnSpeed * Time.deltaTime * verticalInput);

        if (transform.position.x < leftRange)
        {
            transform.position = new Vector3(leftRange, transform.position.y,
                transform.position.z);
        }

        if (transform.position.x > rightRange)
        {
            transform.position = new Vector3(rightRange, transform.position.y,
                transform.position.z);
        }

        if (transform.position.y < downRange)
        {
            transform.position = new Vector3(transform.position.x, downRange,
                transform.position.z);
        }

        if (transform.position.y > upRange)
        {
            transform.position = new Vector3(transform.position.x, upRange,
                transform.position.z);
        }

        if (transform.position.z < z1Range)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,
                z1Range);
        }

        if (transform.position.z > z2Range)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,
                z2Range);
        }

        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            Instantiate(projectilPrefab, transform.position,
           gameObject.transform.rotation);
        }

    }

     private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("coin"))
        {
            counter++;
            Destroy(otherCollider.gameObject);
            Debug.Log($"Ahora tienes {counter} monedas");
            if (counter == 10)
            {
                Time.timeScale = 0;
                Debug.Log("VICTORIA!!!");
            }
        }
    }
}

