using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRotation : MonoBehaviour
{
    public GameObject Cannon;
    void Update()
    {
        transform.rotation = Cannon.transform.rotation;
    }
}
