
using UnityEngine;

public class Battery : MonoBehaviour, IButton
{
    private Vector3 origSize;
    private float scaleChange = 1.2f;

    private void Awake()
    {
        origSize = transform.localScale;
    }

    public void OnClickEnter()
    {
        // The mouse clicked on this object
        //Debug.Log("Mouse clicked on Battery!");

        GameManager.Instance.StartGame();
    }
    public void OnHoverEnter()
    {
        //Debug.Log("Mouse hovered on Battery!");

        transform.localScale = origSize * scaleChange;

    }

    public void OnHoverExit()
    {
        //Debug.Log("Mouse hoveredEXIT on Battery!");
        transform.localScale = origSize;
    }


}
