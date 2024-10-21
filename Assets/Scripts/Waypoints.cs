using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField] private bool placeable;
    [SerializeField] private bool isEmpty = true;
    [SerializeField] private GameObject tower;
    private void OnMouseDown()
    {
        if (placeable && isEmpty)
        {
            Vector3 towerPosition = new Vector3(transform.position.x, transform.position.y + 1.53f, transform.position.z);
            tower = Instantiate(tower, towerPosition, Quaternion.identity);
            isEmpty = false;
            Debug.Log(isEmpty);
            //Debug.Log(gameObject.name);
        }
    }
}
