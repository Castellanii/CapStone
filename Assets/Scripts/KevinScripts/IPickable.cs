using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IPickable
{
    public void OnTriggerEnter(Collider other);
}
