
using UnityEngine;

public class Book : ButtonObject
{
    private Vector3 origSize;
    private float scaleChange = 1.2f;

    [SerializeField] MenuUI menuUI;
    [SerializeField] MenuInteractor menu;

    
    private void Awake()
    {
        origSize = transform.localScale;
        Name = "Tutorial";
    }

    public override void OnClickEnter()
    {
        // The mouse clicked on this object
        //Debug.Log("Mouse clicked on Book!");
        base.OnClickEnter();
        menu.SetEnabled(false);
        menuUI.EnableInstructionUI();
    }

    public override void OnHoverEnter()
    {
        //Debug.Log("Mouse hovered on Book!");
        base.OnHoverEnter();
        transform.localScale = origSize * scaleChange;
    }

    public override void OnHoverExit()
    {
        //Debug.Log("Mouse hoveredEXIT on Book!");
        base.OnHoverExit();
        transform.localScale = origSize;
    }
}
