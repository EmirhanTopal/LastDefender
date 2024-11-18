using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField] List<Waypoints> waypoints = new List<Waypoints>();
    [SerializeField] [Range(0f, 10f)] float speed;
    [SerializeField] private int duration;

    private Enemy _enemy;
    private Vector3 _wpVector3;
    
    /*OnEnable kullanmamızın sebebi: pool içindeki gameobject ler disable ve enable olmakta,
    bu sebepten dolayı disable olan objemiz tekrar enable olduğunda path i bulmasını ve start noktasına geri dönmesini sağlıyoruz.*/
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(DisplayWaypointsName());
    }

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    void FindPath()
    {
        waypoints.Clear();
        
        GameObject pathObjects = GameObject.FindGameObjectWithTag("Path");
        /* Her bir path nesnesinin içinde bir (component) olarak bulunan Waypoints script'ini alıyor. GetComponent
        <Waypoints>() fonksiyonu, bu path nesnesinde Waypoints adlı (script) arar.
        Eğer bu nesneye atanmış bir Waypoints script'i varsa, onu alıp waypoints adlı listeye ekliyor.*/
        
        /* foreach (Transform path in pathObject.transform) ifadesi,
        pathObject nesnesinin child nesneleri üzerinde döngü oluşturur.*/
        foreach (Transform path in pathObjects.transform)
        {
            waypoints.Add(path.GetComponent<Waypoints>());
        }
    }

    void ReturnToStart() // başlangıçta enemy i start position a götürmek için (rastgele yerlerden gelmemesi için)
    {
        transform.position = waypoints[0].transform.position;
    }
    IEnumerator DisplayWaypointsName()
    {
        int index = -1;
        foreach (Waypoints waypoint in waypoints)
        {
            float timeElapsed = 0; // geçen süre
            Vector3 startPoint = this.transform.position;
            Vector3 endPoint = waypoint.transform.position;
            float t = 0f;
            index += 1;
            
            transform.LookAt(endPoint);
            
            // Bu döngüde hareket, belirlenen bir süre (duration) boyunca orantılı olarak gerçekleşir.
            //Yani, sürenin sonunda nesne kesinlikle endPoint noktasına ulaşır.
            //FPS düşük ya da yüksek olsa bile, bu süre boyunca hareket düzgün bir şekilde tamamlanır.
            while (timeElapsed < duration)
            {
                t = timeElapsed / duration; 
                transform.position = Vector3.Lerp(startPoint, endPoint, t);
                timeElapsed += Time.deltaTime * speed; 
                //Debug.Log(Time.deltaTime);
                yield return null;
            }
            
            //Burada t değeri sabit bir hızla artar ve 1 değerine ulaşınca durur.
            //Ancak bu artış, sürenin ne kadar sürdüğüne bağlı değildir; sadece her frame'deki deltaTime artışına bağlıdır.
            //Bu yüzden, FPS (Frame Per Second) değerine göre hız değişebilir. FPS düşükse, hareket yavaş olabilir; FPS yüksekse hareket hızlanabilir.
            
            // while (t < 1f)
            // {
            //     t += Time.deltaTime;
            //     transform.position = Vector3.Lerp(startPoint, endPoint, t);
            //     yield return new WaitForEndOfFrame();
            // }
        }
        _enemy.Theif();
        gameObject.SetActive(false);
    }

}
