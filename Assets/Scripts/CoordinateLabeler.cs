using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteInEditMode] // hem play hem play off moduna çalıştırması için ayarlayabiliriz
// [ExecuteAlways] sadece play off mode da çalışır edit modunda
public class CoordinateLabeler : MonoBehaviour
{
    private TextMeshPro _label;
    private Vector2Int _v2Int = new Vector2Int(); // sadece v2 int değerleriyle çalışmak için - vector2 float değerlerde alabilr
    void Awake()
    {
        _label = GetComponent<TextMeshPro>();
    }
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            DisplayNameCoordinates();
        }
        else
        {
            DisplayCoordinates();
            DisplayNameCoordinates();
        }
    }

    void DisplayCoordinates()
    {
        //Parent pozisyonuna erişmeye çalışmamızın sebebi onun koordinatları üzerinden işlem yapacağız.
        _v2Int.x = (Mathf.RoundToInt(_label.transform.position.x / UnityEditor.EditorSnapSettings.move.x)); // mathf.roundtoint float değerleri int a convert için kullanılır
        _v2Int.y = (Mathf.RoundToInt(_label.transform.position.z / UnityEditor.EditorSnapSettings.move.z)); // 2d düzlemde çalışıyoruz fakat 3 boyutlu çalıştığımız için y değeri aslında z ekseni üzerinde ki değişimden referans alır

        _label.text = _v2Int.x.ToString() + "," +  _v2Int.y.ToString();
    }

    void DisplayNameCoordinates()
    {
        _label.transform.parent.name = _v2Int.ToString();
    }
}
