using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractuable
{
    [SerializeField]
    private EventManagerSO eventManager;

    [SerializeField]
    private MisionSO misionAsociada;

    [SerializeField] 
    private DialogoSO dialogo1;

    [SerializeField] 
    private DialogoSO dialogo2;

    [SerializeField] 
    private Transform cameraPoint;

    [SerializeField] 
    private float tiempoRotacion;


    private Outline outline;

    private Texture2D cursorInteraccion;

    private Texture2D cursorPorDefecto;

    private DialogoSO dialogoActual;
    private void Awake()
    {
        outline = GetComponent<Outline>();
        dialogoActual = dialogo1;

    }

    private void OnEnable()
    {
        eventManager.OnTerminarMision += CambiarDialogo;
    }

    private void CambiarDialogo(MisionSO misionTerminada)
    {
        if (misionTerminada== misionAsociada)
        {
            dialogoActual = dialogo2;
        }
    }

    // Start is called before the first frame update
    public void Interactuar(Transform interactuador)
    {
        transform.DOLookAt(interactuador.position, tiempoRotacion, AxisConstraint.Y).OnComplete(() => SistemaDeDialogo.sistema.IniciarDialogo(dialogoActual, cameraPoint));
        
    }

    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursorInteraccion, Vector2.zero, CursorMode.Auto);
        outline.enabled = true;
    }
    private void OnMouseExit()
    {
        Cursor.SetCursor(cursorPorDefecto, Vector2.zero, CursorMode.Auto);
        outline.enabled = false;
    }
}
