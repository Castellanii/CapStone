
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    [SerializeField] private float changeDuration = 1f;
    //Left, middle, right position
    [SerializeField] private float[] Positions;
    


    private int currPosIndex = 1;

    /// <summary>
    /// -1: left, 1: right
    /// </summary>
    /// <param name="value"></param>
    public void ChangePosition(int value)
    {
        if (currPosIndex == 0 && value == -1) return;
        if (currPosIndex == 2 && value == 1) return;

        if ((value + currPosIndex) == 1)
        {
            this.transform.position = Vector3.zero;
        }
        else
        {
            this.transform.position = Vector3.Lerp(new Vector3(Positions[currPosIndex], 0, 0), new Vector3(Positions[value + currPosIndex], 0, 0), changeDuration);
        }
        //Debug.Log(new Vector3(Positions[value + currPosIndex], 0, 0));
        currPosIndex = value + currPosIndex;
    }

}
