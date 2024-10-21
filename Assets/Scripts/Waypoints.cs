using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField] private bool placeable;
    [SerializeField] private GameObject tower;
    private void OnMouseDown()
    {
        if (placeable)
        {
            Vector3 towerPosition = new Vector3(transform.position.x, transform.position.y + 1.53f, transform.position.z);
            tower = Instantiate(tower, towerPosition, Quaternion.identity);
            Debug.Log(gameObject.name);
        }
    }
}
