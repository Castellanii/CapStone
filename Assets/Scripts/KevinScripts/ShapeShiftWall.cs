using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeShiftWall : MonoBehaviour
{
    private Collider wallCollider;
    private Shape TargetShape;

    private PlayerCondition playerCondition;
    private void Awake()
    {
        wallCollider = GetComponent<Collider>();
        playerCondition = GameObject.FindGameObjectWithTag("PlayerMain").GetComponent<PlayerCondition>();
    }

    public void UpdateTargetShape(Shape _targetShape)
    {
        
        TargetShape = _targetShape;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log(TargetShape.ToString());
            if (playerCondition.currShape == TargetShape)
            {
                //ToDo pass through wall
                Debug.Log($"You passed through the {TargetShape.ToString()} with {playerCondition.currShape.ToString()}");
                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log($"You failed passed through the {TargetShape.ToString()} with {playerCondition.currShape.ToString()}");
                
                LivesCounter.Instance.LoseLife();
                Destroy(this.gameObject);

            }
        }
    }



}
