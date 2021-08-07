using System;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Health Pickup",menuName = "Health Pickup")]
public class HealthPickData : PickupData
{
    public int Health;
}
