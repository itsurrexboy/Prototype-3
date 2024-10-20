using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerRB.AddForce(Vector3.up * 500);
        }
    }
}
