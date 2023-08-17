using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class limitLife : MonoBehaviour
{
    public int time = 2;
    void Start()
    {
        Destroy(this.gameObject, time);
    }
}
