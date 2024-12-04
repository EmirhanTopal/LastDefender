using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    public bool _variatySpaces = false;

    public void PlaceActive()
    {
            _variatySpaces = !_variatySpaces;
    }
}
