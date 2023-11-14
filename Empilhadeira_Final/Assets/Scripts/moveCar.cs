using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using UnityEngine.UI;
using TMPro;

public enum Axel
{

    Front, Rear

}

public enum Traction
{

    Front, Rear, full

}

[Serializable]
public struct Whell
{

    public GameObject model;
    public WheelCollider collider;
    public Axel axel;

}

public class moveCar : MonoBehaviour
{

    public WheelCollider frenteEsquerda;
    public WheelCollider frenteDireita;
    public WheelCollider traseiraEsquerda;
    public WheelCollider traseiraDireita;
    public float torque;
    public float freioTorque;
    public float maxAnguloVirar;
    private Vector2 input;
    private bool isFreio;
    private Rigidbody rbPlayer;
    public Whell[] whells;
    public Traction traction;
    private Rigidbody rbCar;
    public Transform volante;
    public GameObject cameraRe;
    private bool verificarCameraRe;

    //Vari�veis cron�metro

    /*
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
    */
   // public GameObject painelGameOver;


    //Config sensor r�
    public AudioSource _SFXSensorRe;

    public GameObject teste;

    void Start()
    {
        rbCar = GetComponent<Rigidbody>();
        //iniciarMissao = true;

        teste = GameObject.Find("Garfo");

        teste.transform.SetParent(transform);
    }

    void Update()
    {
        //relogio();
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = -1 * Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            frenteDireita.motorTorque = 0;
            frenteEsquerda.motorTorque = 0;
            traseiraDireita.motorTorque = 0;
            traseiraEsquerda.motorTorque = 0;
            frenteDireita.brakeTorque = freioTorque;
            frenteEsquerda.brakeTorque = freioTorque;
            traseiraDireita.brakeTorque = freioTorque;
            traseiraEsquerda.brakeTorque = freioTorque;
            isFreio = true;

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {

            isFreio = false;
            frenteDireita.brakeTorque = 0;
            frenteEsquerda.brakeTorque = 0;
            traseiraDireita.brakeTorque = 0;
            traseiraEsquerda.brakeTorque = 0;

        }
        if (input.x == 1 && volante.transform.eulerAngles.z < 140)
        {

            volante.transform.Rotate(new Vector3(0, 0, 1));

        }
        else if (input.x == 0 && volante.transform.localEulerAngles.z >= 71)
        {

            volante.transform.Rotate(new Vector3(0, 0, -1));

        }
        else if (input.x == -1 && volante.transform.eulerAngles.z > 10)
        {

            volante.transform.Rotate(new Vector3(0, 0, -1));

        }
        else if (input.x == 0 && volante.transform.localEulerAngles.z < 70)
        {

            volante.transform.Rotate(new Vector3(0, 0, 1));

        }

        if (Input.GetKeyDown(KeyCode.T) && verificarCameraRe == false)
        {

            cameraRe.SetActive(false);
            verificarCameraRe = true;

        }
        else if (Input.GetKeyDown(KeyCode.T) && verificarCameraRe == true)
        {

            cameraRe.SetActive(true);
            verificarCameraRe = false;

        }
        //restart a cema
        if(Input.GetKeyDown(KeyCode.F)) {
             SceneManager.LoadScene("Programa��o");
         }

        if(input.y == 1)
        {
            _SFXSensorRe.enabled = true;
        }else if(input.y != 1)
        {
            _SFXSensorRe.enabled = false;
        }

        AnimateWheels();
    }

    private void FixedUpdate()
    {

        if (!isFreio)
        {

            frenteDireita.motorTorque = input.y * torque;
            frenteEsquerda.motorTorque = input.y * torque;
            traseiraDireita.motorTorque = input.y * torque;
            traseiraEsquerda.motorTorque = input.y * torque;

        }

        float anguloDirecao = input.x * maxAnguloVirar;
        frenteDireita.steerAngle = anguloDirecao;
        frenteEsquerda.steerAngle = anguloDirecao;
    }

    void AnimateWheels()
    {
        foreach (Whell w in whells)
        {

            Quaternion rot;
            Vector3 posicao;
            w.collider.GetWorldPose(out posicao, out rot);
            w.model.transform.position = posicao;
            w.model.transform.rotation = rot;

        }
    }
    /*
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

    }*/



}
