using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleCamera : MonoBehaviour
{
    public GameObject[] cameras;
    public int selecaoCamera;
    public Transform camera;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(selecaoCamera >= 2)
            {
                selecaoCamera = 0;

            }
            else
            {
                selecaoCamera++;
            }
            camera.transform.position = cameras[selecaoCamera].transform.position;
            camera.transform.rotation = cameras[selecaoCamera].transform.rotation;
        }
    }
}
