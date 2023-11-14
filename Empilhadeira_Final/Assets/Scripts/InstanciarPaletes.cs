using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class InstanciarPaletes : MonoBehaviour
{

    [Header("Conf Rel�gio")]
    public int tempoInicial;
    public int tempoAtual;
    public float segundos;
    public int Minutos;
    public int resto;
    public float descrescimoSegundo;
    public int segundosAtualizados;
    public TextMeshProUGUI txtMinutos;
    public TextMeshProUGUI txtSegundos;
    bool tempo;
    public int tempoNovo;
    public float decrescimotempoMinutos;
    public float descrecimoMinutos;
    public bool iniciarMissao;

    [Header("Config. Gerenciadpr de Endereçamento")]

    public bool isSorteio;

    public string[] enderecoCadastrado;

    public string[] localAleatorio;

    public TextMeshProUGUI[] textLocal;

    public TextMeshProUGUI[] textEndereco;

    public int aleatorio;

    public List<int> armazenar = new List<int>();

    public GameObject[] locaisDestinos;

    

    void Start()
    {
        iniciarMissao = true;

        foreach(GameObject n in locaisDestinos)
        {
            n.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        relogio();
        sortearNumerao();
        if(Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("Level SAMI 1 - Programação");
        }

    }

    public void relogio()
    {
        if (iniciarMissao == true)
        {
            descrescimoSegundo += Time.deltaTime;
            descrecimoMinutos += Time.deltaTime;

            if (decrescimotempoMinutos > 0)
            {
                if (tempoAtual > 60 && tempo == false)
                {
                    resto = tempoAtual % 60;
                    Minutos = (int)(tempoAtual - resto) / 60;
                    segundos = (int)resto;
                    txtMinutos.text = Minutos.ToString();
                    txtSegundos.text = segundos.ToString();
                    tempo = true;
                }

                segundosAtualizados = (int)segundos - (int)descrescimoSegundo;

                if (segundosAtualizados <= 0)
                {
                    Minutos--;
                    segundos = 59;
                    descrescimoSegundo = 0;
                }

                else if (segundos < 0 && Minutos < 0)
                {
                    Minutos = 0;
                    segundos = 0;
                }
                txtSegundos.text = segundosAtualizados.ToString("00");
                txtMinutos.text = Minutos.ToString("0");

            }
            else if (decrescimotempoMinutos < 0)
            {
                Minutos = 0;
                segundos = 0;
                decrescimotempoMinutos = 0;
                txtSegundos.text = segundosAtualizados.ToString("00");
                txtMinutos.text = Minutos.ToString("0");
                //painelGameOver.SetActive(true);
                iniciarMissao = false;
            }

            decrescimotempoMinutos = tempoAtual - descrecimoMinutos;
        }
    }

    public void sortearNumerao()
    {

        if (isSorteio == false)
        {

            for (int c = 0; c < 3; c++)
            {
                aleatorio = Random.Range(0, 8);

                while (armazenar.Contains(aleatorio))
                {
                    aleatorio = Random.Range(0, 8);
                }

                armazenar.Add(aleatorio);

            }

            for (int i = 0; i < 3; i++)
            {

                if (armazenar[i] == 0)//A
                {
                    textLocal[i].text = localAleatorio[0];
                    locaisDestinos[0].SetActive(true);

                }
                if (armazenar[i] == 1)//B
                {
                    textLocal[i].text = localAleatorio[1];
                    locaisDestinos[1].SetActive(true);
                }
                if (armazenar[i] == 2)//C
                {
                    int sorteoLocal = Random.Range(2, 5);
                    textLocal[i].text = localAleatorio[sorteoLocal];
                    locaisDestinos[sorteoLocal].SetActive(true);
                }
                if (armazenar[i] == 3)//D
                {
                    int sorteoLocal = Random.Range(5, 7);
                    textLocal[i].text = localAleatorio[sorteoLocal];
                    locaisDestinos[sorteoLocal].SetActive(true);
                }
                if (armazenar[i] == 4)//E
                {
                    textLocal[i].text = localAleatorio[7];
                    locaisDestinos[7].SetActive(true);
                }
                if (armazenar[i] == 5)//F
                {
                    textLocal[i].text = localAleatorio[8];
                    locaisDestinos[8].SetActive(true);
                }
                if (armazenar[i] == 6)//G
                {
                    int sorteoLocal = Random.Range(9, 11);
                    textLocal[i].text = localAleatorio[sorteoLocal];
                    locaisDestinos[sorteoLocal].SetActive(true);

                }
                if (armazenar[i] == 7)//H
                {
                    int sorteoLocal = Random.Range(11, 14);
                    textLocal[i].text = localAleatorio[sorteoLocal];
                    locaisDestinos[sorteoLocal].SetActive(true);
                }

                textEndereco[i].text = enderecoCadastrado[armazenar[i]];

            }
            isSorteio = true;
        }
    }
}
