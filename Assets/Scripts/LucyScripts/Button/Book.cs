
using UnityEngine;

public class Book : MonoBehaviour, IButton
{
    private Vector3 origSize;
    private float scaleChange = 1.2f;

    [SerializeField] MenuUI menuUI;
    private void Awake()
    {
        origSize = transform.localScale;
    }

    public void OnClickEnter()
    {
        // The mouse clicked on this object
        //Debug.Log("Mouse clicked on Book!");

        menuUI.EnableInstructionUI();
    }
    public void OnHoverEnter()
    {
        //Debug.Log("Mouse hovered on Book!");

        transform.localScale = origSize * scaleChange;

    }

    public void OnHoverExit()
    {
        //Debug.Log("Mouse hoveredEXIT on Book!");
        transform.localScale = origSize;
    }


}
