using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerManager : MonoBehaviour
{
    [SerializeField] int costOfTower;
    public int CostOfTower
    {
        get { return costOfTower; }
    }
}
