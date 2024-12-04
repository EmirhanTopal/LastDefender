using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// [serializefield] attribute: bir değişkenin private olmasına rağmen Unity'nin Inspector panelinde görünmesini sağlar.
public class Waypoints : MonoBehaviour
{
    [SerializeField] private bool greenPlace;
    [SerializeField] private bool blackPlace;
    [SerializeField] private bool isEmpty = true;
    [SerializeField] private GameObject tower;
    [SerializeField] private GameObject gunTower;
    private TowerManager _towerManager;
    private bool _canBuy;
    private void Start()
    {
        _towerManager = FindObjectOfType<TowerManager>();
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
        if (isEmpty && _canBuy)
        {
            if (greenPlace)
            {
                Vector3 towerPosition = new Vector3(transform.position.x, transform.position.y + 1.53f, transform.position.z);
                tower = Instantiate(tower, towerPosition, Quaternion.identity);
                isEmpty = false; // grid space control
                
            }
            if (blackPlace)
            {
                Vector3 gunTowerPosition = new Vector3(transform.position.x + 2, transform.position.y + 7.45f, transform.position.z + 2);
                Instantiate(gunTower, gunTowerPosition, Quaternion.identity);
                isEmpty = false;
            }
        }
    }
}
