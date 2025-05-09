﻿using System.Collections;
using System.Collections.Generic;
using Unity.Hierarchy;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float cooldown = 0;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog and sets a cool down
        if (Input.GetKeyDown(KeyCode.Space) && cooldown <= 0)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            cooldown = 1;
        }
        if (cooldown >= 0)
        {
            cooldown -= Time.deltaTime;
        }
    }
}
