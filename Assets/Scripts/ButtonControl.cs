using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    public bool _variatySpaces = false;
    [SerializeField] private List<ButtonControl> buttonList;

    public void PlaceActive()
    {
        foreach (var button in buttonList)
        {
            button._variatySpaces = false;
        }
        _variatySpaces = !_variatySpaces;
    }
}
