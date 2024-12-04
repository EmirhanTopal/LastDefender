using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


// [serializefield] attribute: bir değişkenin private olmasına rağmen Unity'nin Inspector panelinde görünmesini sağlar.
public class Waypoints : MonoBehaviour
{
    [SerializeField] private bool greenPlace;
    [SerializeField] private bool blackPlace;
    [SerializeField] private bool isEmpty = true;
    [SerializeField] private GameObject tower;
    [SerializeField] private GameObject gunTower;
    [SerializeField] private GameObject button;
    [SerializeField] private bool canPlaceGreen;
    [SerializeField] private bool canPlaceBlack;
    private TowerManager _towerManager;
    private ButtonControl _buttonControl;
    private GunTowerManager _gunTowerManager;
    private bool _canBuy;
    private BankManager _bank;
    private void Start()
    {
        _buttonControl = button.GetComponent<ButtonControl>();
        _bank = FindObjectOfType<BankManager>();
        _gunTowerManager = FindObjectOfType<GunTowerManager>();
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
        _canBuy = _bank.HaveMoney();
        canPlaceGreen = _buttonControl._variatySpaces;
        canPlaceBlack = _buttonControl._variatySpaces;
        if (isEmpty && _canBuy)
        {
            if (greenPlace & canPlaceGreen)
            {
                Vector3 towerPosition = new Vector3(transform.position.x, transform.position.y + 1.53f, transform.position.z);
                tower = Instantiate(tower, towerPosition, Quaternion.identity);
                _bank.Withdraw(_towerManager.CostOfTower);
                isEmpty = false; // grid space control
                canPlaceGreen = false;
            }
            if (blackPlace && canPlaceBlack)
            {
                Vector3 gunTowerPosition = new Vector3(transform.position.x + 2, transform.position.y + 7.45f, transform.position.z + 2);
                Instantiate(gunTower, gunTowerPosition, Quaternion.identity);
                _bank.Withdraw(_gunTowerManager.CostOfGunTower);
                isEmpty = false;
                canPlaceBlack = false;
            }
        }
    }
}
