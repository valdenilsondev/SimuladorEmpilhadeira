using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class pararColisaoInferior : MonoBehaviour
{

    private ComnadoElevador _comandos;
    // Start is called before the first frame update
    void Start()
    {
        _comandos = FindObjectOfType(typeof(ComnadoElevador)) as ComnadoElevador;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "pararColisao")
        {
            _comandos.limitePararInferior = true;
        }
    }
}
