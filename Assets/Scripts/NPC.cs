using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private Outline outline;
    [SerializeField] private DialogoSO dialogo;
    private Texture2D cursorInteraccion;
    private Texture2D cursorPorDefecto;

    [SerializeField] private Transform cameraPoint;

    [SerializeField] private float tiempoRotacion;
    private void Awake()
    {
        outline = GetComponent<Outline>();
    }
    // Start is called before the first frame update
    public void Interactuar(Transform interactuador)
    {
        transform.DOLookAt(interactuador.position, tiempoRotacion, AxisConstraint.Y).OnComplete(() => SistemaDeDialogo.sistema.IniciarDialogo(dialogo, cameraPoint));
        SistemaDeDialogo.sistema.IniciarDialogo(dialogo, cameraPoint);
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
