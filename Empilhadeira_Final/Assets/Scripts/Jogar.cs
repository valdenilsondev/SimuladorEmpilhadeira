using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogar : MonoBehaviour
{
    public void iniciar()
    {
        SceneManager.LoadScene("Level SAMI 1 - Programa��o");
    }
    public void sairJogo()
    {
        Application.Quit();
    }


}
