
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (!this.GetComponent<PlayerJump>().isGrounded) return;

        if (Input.GetButtonDown("Horizontal"))
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                //Debug.Log("A");
                this.GetComponent<PlayerPosition>().ChangePosition(-1);
            }
            else
            {
                //Debug.Log("D");
                this.GetComponent<PlayerPosition>().ChangePosition(1);
            }
        }
        else if (Input.GetButtonDown("Jump"))
        {
            this.GetComponent<PlayerJump>().Jump();
        }
    }
}
