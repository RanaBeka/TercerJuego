using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour, IInteractuable
{
    private Outline outline;

    private Texture2D cursorInteraccion;
    private Texture2D cursorPorDefecto;
    private void Awake()
    {
        outline = GetComponent<Outline>();
    }
    public void Interactuar()
    {

    }

    public void Interactuar(Transform interactuador)
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
