
using System.Collections;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayerPosition : MonoBehaviour
{
    [SerializeField] private float changeDuration = 1f;
    //Left, middle, right position
    [SerializeField] private float[] Positions;

   

    private int currPosIndex = 1;

    private Coroutine moveCoroutine;
    private int oldValue;

    private int oldPosIndex;



    private void Update()
    {
       
        if (PlayerInput.GetInstance().left)
        {
            ChangePosition(-1);
        }
        else if (PlayerInput.GetInstance().right)
        {
            ChangePosition(1);
        }


    }
    /// <summary>
    /// -1: left, 1: right
    /// </summary>
    /// <param name="value"></param>
    public void ChangePosition(int value)
    {
        
        if (currPosIndex == 0 && value == -1) return;
        if (currPosIndex == 2 && value == 1) return;
        

        //if (moveCoroutine != null)
        //{
        //    StopCoroutine(MoveToPosition(oldValue));
        //    Debug.Log($"stop the previous and move to {value + oldPosIndex}");
        //    transform.position = new Vector3(Positions[value + oldPosIndex], 0, 0);
        //}
        moveCoroutine = StartCoroutine(MoveToPosition(value));
        

        oldPosIndex = currPosIndex;
        currPosIndex = value + currPosIndex;
    }

   


    private IEnumerator MoveToPosition(int value)
    {
        oldValue = value;
        Vector3 endPos = new Vector3(Positions[value + currPosIndex], 0, 0);
        //Debug.Log($"end point: {value + currPosIndex}");
        Vector3 startPos = new Vector3(Positions[currPosIndex], 0, 0);

        float elapsedTime = 0f;

        while (elapsedTime < changeDuration)
        {
            
            transform.position = Vector3.Lerp(startPos, endPos, elapsedTime/changeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endPos;

        moveCoroutine = null;
    }

}
