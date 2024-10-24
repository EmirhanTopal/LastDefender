using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// [serializefield] attribute: bir değişkenin private olmasına rağmen Unity'nin Inspector panelinde görünmesini sağlar.
public class Waypoints : MonoBehaviour
{
    [SerializeField] private bool placeable;
    [SerializeField] private bool isEmpty = true;
    [SerializeField] private GameObject tower;
    
    // aynısı. getter properties.
    public bool IsEmpty { get { return isEmpty; } }
    // public bool GetIsPlaceable()
    // {
    //     return isEmpty;
    // }
    
    private void OnMouseDown()
    {
        if (placeable && isEmpty)
        {
            Vector3 towerPosition = new Vector3(transform.position.x, transform.position.y + 1.53f, transform.position.z);
            tower = Instantiate(tower, towerPosition, Quaternion.identity);
            isEmpty = false; // grid space control
            Debug.Log(isEmpty);
        }
    }
}
