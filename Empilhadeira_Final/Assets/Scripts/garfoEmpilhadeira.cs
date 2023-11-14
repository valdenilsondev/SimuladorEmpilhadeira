using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class garfoEmpilhadeira : MonoBehaviour
{

    public int quantidadeMissao;
    public Button[] btnMissoes;
    
    void Start()
    {
        
    }

  
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Missao")
        {
            Debug.Log("Colidir");
            quantidadeMissao += 1;
            Destroy(other.gameObject);
            btnMissoes[0].image.color = Color.green;
        }
    }

}
