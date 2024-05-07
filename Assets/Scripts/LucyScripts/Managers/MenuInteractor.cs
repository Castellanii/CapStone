using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class MenuInteractor : MonoBehaviour
{
    private bool isHover;
    private bool isClicked;

    private IButton lastButton;
    private bool isEnabled;

    public static MenuInteractor Instance;

    void Singleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;
    }
    private void Awake()
    {
        Singleton();
    }

    public void SetEnabled(bool _value)
    {
        //Debug.Log($"set enabled : {_value}");
        isEnabled = _value;
    }

    private void Update()
    {
        if (!isEnabled) { return; }
        if (Input.GetMouseButtonDown(0))
        {
            isClicked = true;
        }
        else
        {
            isClicked = false;
        }
        // Create a ray from the camera through the mouse cursor position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Check if the ray hits any object in the scene
        if (Physics.Raycast(ray, out hit))
        {
            // Check if the hit object has a collider
            if (hit.collider != null)
            {
                IButton button = hit.collider.gameObject.GetComponent<IButton>();
                // Check if the hit object is the object you're interested in
                if (button != null)
                {
                    if (isClicked)
                    {
                        isHover = false;
                        button.OnClickEnter();
                        return;
                    }
                    else
                    {
                        isHover = true;
                        lastButton = button;
                        button.OnHoverEnter();
                        return;
                    }
                }
                else if (isHover)
                {
                    isHover = false;
                    if (lastButton != null)
                        lastButton.OnHoverExit();
                    lastButton = null;
                    return;
                }
            }
        }

        isHover = false;
        if (lastButton != null)
            lastButton.OnHoverExit();
        lastButton = null;
        return;

    }
}
