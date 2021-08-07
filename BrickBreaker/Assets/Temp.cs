using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer),typeof(MeshFilter))]
public class Temp : MonoBehaviour
{

    void Start()
    {
        Debug.Log($"{gameObject.name} has global position {transform.position}");
        Debug.Log($"{gameObject.name} has local position {transform.localPosition}");
    }
}
