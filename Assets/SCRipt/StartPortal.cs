﻿using UnityEngine;
using System.Collections;

public class StartPortal : MonoBehaviour
{
    private float cd = 2f;
    private float lasthit;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.name == "Player1" && col.collider.GetComponent<Stats>().decPortal())
        {
            col.collider.GetComponent<Stats>().respawn();
            col.collider.GetComponent<Stats>().NewBackGround();
        }
        else if (col.collider.name == "Player2" && lasthit + cd < Time.time)
        {
            lasthit = Time.time;
            col.collider.GetComponent<Stats>().respawn();
            col.collider.GetComponent<Stats>().incPortal();
            col.collider.GetComponent<Stats>().NewBackGround();
        }
    }
}
