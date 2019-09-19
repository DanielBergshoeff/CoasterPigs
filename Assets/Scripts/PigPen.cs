using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigPen : MonoBehaviour
{
    public bool Prodded;
    public bool BeingProdded;

    void Start()
    {
        RoomManager.AddPigPen(this);
    }
}
