﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   void OnTriggerEnter2D(Collider2D other) {
       Debug.Log("trigger");
       Destroy(gameObject);
    //    score += 5;
    //    Debug.Log("score:" + score);
   }

}
