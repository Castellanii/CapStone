
using UnityEngine;

public class Battery : ButtonObject
{
    private Vector3 origSize;
    private float scaleChange = 1.2f;

    private void Awake()
    {
        origSize = transform.localScale;
        Name = "Start Game";
    }

    public override void OnClickEnter()
    {
        base.OnClickEnter();
        // The mouse clicked on this object
        //Debug.Log("Mouse clicked on Battery!");
        GameManager.Instance.StartGame();
    }

    public override void OnHoverEnter()
    {
        base.OnHoverEnter();
        //Debug.Log("Mouse hovered on Battery!");
        transform.localScale = origSize * scaleChange;
    }

    public override void OnHoverExit()
    {
        base.OnHoverExit();
        //Debug.Log("Mouse hoveredEXIT on Battery!");
        transform.localScale = origSize;
    }
}
