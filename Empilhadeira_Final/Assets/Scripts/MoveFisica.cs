using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFisica : MonoBehaviour
{
    [Header("Config Limite Garfo")]

    public float velocidadeElevação;
    private bool limiteInferiorPratileira;
    public float limiteInferiorGarfo;
    public float limiteSuperiorGarfo;
    public Transform suporteElevador;
    public float velocidadeSuporteElevador;
    public Transform alturaEmpilhadeira;

    private Rigidbody rbEmpilhadeira;
    public float velocidadeSubir;

    public GameObject garfo;

    private void Start()
    {
        rbEmpilhadeira = GetComponent<Rigidbody>();

        garfo = GameObject.Find("Pilha de Caixotes");
    }

    private void FixedUpdate()
    {
        #region 
        /*
        if (alturaEmpilhadeira.position.y >= 1.6f)
        {
            limiteInferiorGarfo = alturaEmpilhadeira.position.y + 1.6f;
        }
        if (alturaEmpilhadeira.position.y < 1)
        {
            limiteInferiorGarfo = 1.6f;
        }
        */
        /*
        if (transform.position.y > limiteSuperiorGarfo)
        {

            //velocidadeElevação = 0;
            //velocidadeSuporteElevador = 0;

        }
        else if (Input.GetKey(KeyCode.E))
        {
            rbEmpilhadeira.velocity = new Vector3(0,10,0) * velocidadeSuporteElevador;

           
            velocidadeElevação = 1f;
            velocidadeSuporteElevador = 0.5f;
            transform.Translate(new Vector3(0, velocidadeElevação, 0) * Time.deltaTime);
            suporteElevador.transform.Translate(new Vector3(0, velocidadeSuporteElevador, 0) * Time.deltaTime);
            

        }*/
        /*
        if (transform.position.y < limiteInferiorGarfo)
        {

            //velocidadeElevação = 0;
            //velocidadeSuporteElevador = 0;

        }
        else if (Input.GetKey(KeyCode.Q) && limiteInferiorPratileira == false)
        {
            velocidadeSuporteElevador = -0.5f;
            velocidadeElevação = -1f;
            transform.Translate(new Vector3(0, velocidadeElevação, 0) * Time.deltaTime);
            suporteElevador.transform.Translate(new Vector3(0, velocidadeSuporteElevador, 0) * Time.deltaTime);

        }*/
        #endregion

        //Movimento utilizando física

        if (Input.GetKeyDown(KeyCode.E))
        {
            rbEmpilhadeira.velocity = new Vector3(0, 1, 0) * velocidadeSubir;
           rbEmpilhadeira.isKinematic = false;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            rbEmpilhadeira.velocity = new Vector3(0, 0, 0) ;
            rbEmpilhadeira.isKinematic = true;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            rbEmpilhadeira.velocity = new Vector3(0, -1, 0) * velocidadeSubir;
           rbEmpilhadeira.isKinematic = false;
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {

           rbEmpilhadeira.isKinematic = true;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Garfo")
        {
            garfo.gameObject.GetComponent<Rigidbody>().isKinematic  = true;

            garfo.transform.SetParent(transform);
        }
    }
}
