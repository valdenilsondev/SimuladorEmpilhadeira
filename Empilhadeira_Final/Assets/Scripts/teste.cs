using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teste : MonoBehaviour
{

    private Rigidbody rbPlayer;
    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            rbPlayer.velocity = new Vector3(0, 1, 0);
            rbPlayer.isKinematic = false;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            
            rbPlayer.isKinematic = true;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            rbPlayer.velocity = new Vector3(0, -1, 0);
            rbPlayer.isKinematic = false;
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
           
            rbPlayer.isKinematic = true;
        }
    }
}
