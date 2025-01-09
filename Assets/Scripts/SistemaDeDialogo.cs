using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SistemaDeDialogo : MonoBehaviour
{

    public static SistemaDeDialogo sistema;
    [SerializeField] private GameObject marcos;
    [SerializeField] private TMP_Text textoDialogo;
    private bool escribiendo; //determina si el sistema esta escribiendo o no
    private int indiceFraseActual; //Marca la frase por la q voy
    [SerializeField] private Transform npcCamera;

    private void Awake()
    {
        if (sistema == null)
        {
            sistema = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void IniciarDialogo(DialogoSO dialogo)
    {
        Time.timeScale = 0f;

        //npcCamera.transform.SetPositionAndRotation(cameraPoint.transform.position, cameraPoint.rotation);
        //dialogoActual = dialogo;
        marcos.SetActive(true);
        //StartCoroutine(EscribirFrase());
    }

    //private IEnumerator EscribirFrase()
    //{
        //escribiendo = true;

        //textoDialogo.text = "";
        //char[] fraseEnLetras = dialogoActual.frases[indiceFraseActual].ToCharArray;
        //foreach (char letra in fraseEnLetras)
        //{
            //textoDialogo.text += letra;
           // yield return new WaitForSecondsRealtime(dialogoActual.tiempoEntreLetras);
        //}
        //escribiendo = false;
    //}

    private void SiguienteFrase()
    {

    }
    private void TerminarDialogo()
    {

    }
}
