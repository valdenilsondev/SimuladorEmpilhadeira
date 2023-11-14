using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComnadoElevador : MonoBehaviour
{
    [Header("Config Limite Garfo")]

    public float velocidadeElevação;
    private bool limiteInferiorPratileira;
    public float limiteInferiorGarfo;
    public float limiteSuperiorGarfo;
    public Transform suporteElevador;
    public float velocidadeSuporteElevador;
    public Transform alturaEmpilhadeira;

    public GameObject caixote;

    public bool limitePararInferior;
    public bool limetePararSuperior;
   
    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if(alturaEmpilhadeira.position.y >=1.6f)
        {
            limiteInferiorGarfo = alturaEmpilhadeira.position.y + 1.6f;
        }
        if(alturaEmpilhadeira.position.y < 1)
        {
            limiteInferiorGarfo = 1.6f;
        }
      

        if (transform.position.y > limiteSuperiorGarfo)
        {

            velocidadeElevação = 0;
            //velocidadeSuporteElevador = 0;

        }
        else if (Input.GetKey(KeyCode.E))
        {

            velocidadeElevação = 1f;
            velocidadeSuporteElevador = 0.5f;
            transform.Translate(new Vector3(0, velocidadeElevação, 0) * Time.deltaTime);
            suporteElevador.transform.Translate(new Vector3(0, velocidadeSuporteElevador, 0) * Time.deltaTime);

            limitePararInferior = false;
        }
        if (transform.position.y < limiteInferiorGarfo)
        {

            velocidadeElevação = 0;
            velocidadeSuporteElevador = 0;

        }
        else if (Input.GetKey(KeyCode.Q) && limiteInferiorPratileira == false && limitePararInferior == false)
        {
            velocidadeSuporteElevador = -0.5f;
            velocidadeElevação = -1f;
            transform.Translate(new Vector3(0, velocidadeElevação, 0) * Time.deltaTime);
            suporteElevador.transform.Translate(new Vector3(0, velocidadeSuporteElevador, 0) * Time.deltaTime);

           
          

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "sensorParent")
        {
            Debug.Log("Colidir com o objeto");
            caixote = other.gameObject;

           // caixote.transform.parent = this.gameObject.transform  ;

          //  caixote.gameObject.GetComponent<Rigidbody>().isKinematic = true;
          //  caixote.gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "sensorParent")
        {
            Debug.Log("Colidir com o objeto");
            caixote = other.gameObject;

            //caixote.transform.parent = null;

           // caixote.gameObject.GetComponent<Rigidbody>().isKinematic = false;
         //   caixote.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
