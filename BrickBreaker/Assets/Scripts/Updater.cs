using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Updater : MonoBehaviour
{
    private TMPro.TextMeshPro textComponent;
    // Start is called before the first frame update
    void Awake()
    {
        textComponent = GetComponent<TMPro.TextMeshPro>();
    }

    public void DoUpdate(int Value)
    {
        textComponent.text = Value.ToString();
    }
}
