using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SistemaDeDialogo : MonoBehaviour
{
    [SerializeField] private EventManagerSO eventManager;
    public static SistemaDeDialogo sistema;
    [SerializeField] private GameObject marcos;
    [SerializeField] private TMP_Text textodialogo;
    private bool escribiendo; //determina si el sistema esta escribiendo o no
    private int indiceFraseActual; //Marca la frase por la q voy
    [SerializeField] private Transform npcCamera;
    private DialogoSO dialogoactual;
    [SerializeField] NPC npc;
    
    
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

    public void IniciarDialogo(DialogoSO dialogo, Transform cameraPoint)
    {
        Time.timeScale = 0f;

        npcCamera.SetPositionAndRotation(cameraPoint.position, cameraPoint.rotation);
        dialogoactual = dialogo;
        marcos.SetActive(true);
        StartCoroutine(escribirfrase());
        
    }

    private IEnumerator escribirfrase()
    {
        escribiendo = true;

        textodialogo.text = "";
        char[] fraseenletras = dialogoactual.frases[indiceFraseActual].ToCharArray();
        foreach (char letra in fraseenletras)
        {
            textodialogo.text += letra;
            yield return new WaitForSecondsRealtime(dialogoactual.tiempoEntreLetras);
        }
        escribiendo = false;
    }

    public void SiguienteFrase()
    {

        if (escribiendo)
        {
            CompletarFrase();

        }
        else
        {
            indiceFraseActual++;
            if (indiceFraseActual < dialogoactual.frases.Length)
            {

                StartCoroutine(escribirfrase());

            }
            else
            {
                TerminarDialogo();
                
            }
        }


    }
    public void CompletarFrase()
    {
        StopAllCoroutines();
        textodialogo.text = dialogoactual.frases[indiceFraseActual];
        escribiendo = false;
    }
    private void TerminarDialogo()
    {
        
        marcos.SetActive(false);
        StopAllCoroutines();
        indiceFraseActual = 0;
        escribiendo = false;
        Time.timeScale = 1f;

        if(dialogoactual.tieneMision)
        {
            eventManager.NuevaMision(dialogoactual.mision);
        }
        if (npc.dialogoActual == npc.dialogo2)
        {
            SceneManager.LoadScene(1);
        }

        dialogoactual = null;
    }

    
}
