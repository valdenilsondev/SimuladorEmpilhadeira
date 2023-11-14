using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private ComnadoElevador _comandoGancho;
    public int quantMissoes;
    public int quantMissoesCompletas;
    public GameObject[] sensorInicioMissao;
    public GameObject[] sensorCompletaMissao;
    public GameObject[] missoes;
    public Transform[] positionPallet;
    public GameObject pallet;
    public bool missaoCompleta;
    public float tempo;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayInstanciarObjeto());
    }

    // Update is called once per frame
    void Update()
    {

        tempo += Time.deltaTime;


/*
        if(quantMissoes == 1)
        {
            sensorInicioMissao[0].SetActive(false);
            missoes[0].SetActive(true);
            missaoCompleta = true;
            
        }
        if(quantMissoesCompletas  == 1)
        {
            missoes[0].SetActive(false);
            sensorCompletaMissao[0].SetActive(false);
            missoes[1].SetActive(true);
            sensorCompletaMissao[1].SetActive(true);
        }

        if (quantMissoesCompletas == 2)
        {
            missoes[1].SetActive(false);
            sensorCompletaMissao[1].SetActive(false);
            missoes[2].SetActive(true);
            sensorCompletaMissao[2].SetActive(true);
        }
*/

    }

    IEnumerator DelayInstanciarObjeto()
    {
        for(int i = 0; i<6; i++)
        {
            Instantiate(pallet, positionPallet[i].position, Quaternion.identity);
            yield return new WaitForSeconds(90);
        }
        
       

    }
}
