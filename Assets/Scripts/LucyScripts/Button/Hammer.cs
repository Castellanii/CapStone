using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : ButtonObject
{
    private Vector3 origSize;
    private float scaleChange = 1.1f;

    private void Awake()
    {
        origSize = transform.localScale;
        Name = "Exit";
    }

    public override void OnClickEnter()
    {
        // The mouse clicked on this object
        //Debug.Log("Mouse clicked on hammer!");
        base.OnClickEnter();
        PlayerPrefs.SetInt("gameStatus", (int)GameStatus.GameExit);
        SceneChanger.instance.ExitGame();
    }

    public override void OnHoverEnter()
    {
        //Debug.Log("Mouse hovered on hammer!");
        base.OnHoverEnter();
        transform.localScale = origSize * scaleChange;
    }

    public override void OnHoverExit()
    {
        //Debug.Log("Mouse hoveredEXIT on hammer!");
        base.OnHoverExit();
        transform.localScale = origSize;
    }
}
