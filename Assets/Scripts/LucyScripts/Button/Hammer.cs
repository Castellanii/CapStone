using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour, IButton
{
    private Vector3 origSize;
    private float scaleChange = 1.1f;

    private void Awake()
    {
        origSize = transform.localScale;
    }

    public void OnClickEnter()
    {
        // The mouse clicked on this object
        //Debug.Log("Mouse clicked on hammer!");

        PlayerPrefs.SetInt("gameStatus", (int)GameStatus.GameExit);
        SceneChanger.instance.ExitGame();
    }
    public void OnHoverEnter()
    {
        //Debug.Log("Mouse hovered on hammer!");
         
        transform.localScale = origSize * scaleChange;

    }

    public void OnHoverExit()
    {
        //Debug.Log("Mouse hoveredEXIT on hammer!");
        transform.localScale = origSize;
    }


}
