
using UnityEngine;
//using UnityEngine.UIElements;

[DefaultExecutionOrder(-100)]
public class PlayerInput : MonoBehaviour
{
    public float horizontal { get; private set; }


    public bool jumpPressed { get; private set; }
    public bool activatePressed { get; private set; }


    public bool clear; //clear all the input

    private static PlayerInput instance;


    public bool isActive { private set; get; }
    public static PlayerInput GetInstance()
    {
        return instance;
    }
   
private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;

        isActive = true;
    }

    /// <summary>
    /// Enable/Disable player input.
    /// </summary>
    /// <param name="value"></param>
    public void SetInputStatus(bool value)
    {
        isActive = value;
    }

    // Update is called once per frame
    void Update()
    {
        ClearInputs();
        if (isActive)
        {
            ProcessInputs();
        }

    }

    void ProcessInputs()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            horizontal = Input.GetAxis("Horizontal");
        }
        
        //Debug.Log("horizontal" + horizontal);
   
        jumpPressed = jumpPressed || Input.GetButtonDown("Jump");

        //Debug.Log("jumpPressed" + jumpPressed);
        activatePressed = activatePressed || Input.GetKeyDown(KeyCode.E);
        //Debug.Log("activatePressed" + activatePressed);

    }

    private void FixedUpdate()
    {
        clear = true;
    }
    void ClearInputs()
    {
        if (!clear) return;
        horizontal = 0;

        jumpPressed = false;

        activatePressed = false;
    }

    public void SetCursor(bool status)
    {
        if (status)
        {
            //Show Mouse
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            //Hide Mouse
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}