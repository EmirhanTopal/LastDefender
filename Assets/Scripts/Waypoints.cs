using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// [serializefield] attribute: bir değişkenin private olmasına rağmen Unity'nin Inspector panelinde görünmesini sağlar.
public class Waypoints : MonoBehaviour
{
    [SerializeField] private bool placeable;
    [SerializeField] private bool isEmpty = true;
    [SerializeField] private GameObject tower;
    private TowerManager _towerManager;
    private BankManager _bank;
    private bool _canBuy;
    private void Start()
    {
        _towerManager = FindObjectOfType<TowerManager>();
        _bank = FindObjectOfType<BankManager>();
    }

    // aynısı. getter properties.
    public bool IsEmpty { get { return isEmpty; } }
    // public bool GetIsPlaceable()
    // {
    //     return isEmpty;
    // }
    
    
    //This event is sent to all scripts of the GameObject with Collider. Scripts of the parent or child objects do not receive this event.
    private void OnMouseDown()
    {
        _canBuy = _towerManager.HaveMoney();
        if (placeable && isEmpty && _canBuy)
        {
            Vector3 towerPosition = new Vector3(transform.position.x, transform.position.y + 1.53f, transform.position.z);
            tower = Instantiate(tower, towerPosition, Quaternion.identity);
            isEmpty = false; // grid space control
            //Debug.Log(isEmpty);
        }
    }
}
