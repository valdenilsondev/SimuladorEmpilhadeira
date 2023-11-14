using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeterctarMissao : MonoBehaviour
{

    private GameManager _gameManager;
   
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindAnyObjectByType(typeof(GameManager)) as GameManager;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "sensorMissao")
        {
            _gameManager.quantMissoes += 1;
        }

        if(other.gameObject.tag == "sensorMissaoCompleta")
        {
            _gameManager.quantMissoesCompletas += 1;
            Destroy(other.gameObject);

        }
    }

}
