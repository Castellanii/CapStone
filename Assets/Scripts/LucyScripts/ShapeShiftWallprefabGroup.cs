
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Rendering;

public class ShapeShiftWallprefabGroup : MonoBehaviour
{

    [SerializeField] private List<GameObject> PickUps;
    [SerializeField] private ShapeShiftWall shapeShiftWall;
    [SerializeField] private Material[] ShapeWallMaterials;


    public void GenerateShapeShiftWallprefabGroup(float[] lanePositionList)
    {
        GeneratePickUps(lanePositionList);
        GenerateShapeShiftWall();

    }

    /// <summary>
    /// 2 pick ups and 1 empty spot in lanes of 3.
    /// </summary>
    /// <param name="lanePositionList"></param>
    public void GeneratePickUps(float[] lanePositionList)
    {
        List<float> PositionList = new List<float>(lanePositionList);

        //Confirm empty spot position
        int Spot = Random.Range(0, PositionList.Count);
        PositionList.RemoveAt(Spot);

        //Confirm the Patrick Pick up position and enable it
        Spot = Random.Range(0, PositionList.Count);
        PickUps[0].transform.localPosition = new Vector3(0, 0, PositionList[Spot]);
        PickUps[0].SetActive(true);
        PositionList.RemoveAt(Spot);

        //Confirm the Gary pick up Position and enable it
        PickUps[1].transform.localPosition = new Vector3(0, 0, PositionList[0]);
        PickUps[1].SetActive(true);
    }

    public void GenerateShapeShiftWall()
    {
        int rand = Random.Range(0, ShapeWallMaterials.Length);
        shapeShiftWall.GetComponent<Renderer>().material = ShapeWallMaterials[rand];
        shapeShiftWall.gameObject.SetActive(true);
        shapeShiftWall.UpdateTargetShape((Shape)rand+1);
    }

}
