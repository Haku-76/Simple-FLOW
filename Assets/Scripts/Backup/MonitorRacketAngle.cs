// ラケットの角度を画面に表示する。

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MonitorRacketAngle : MonoBehaviour
{
    public GameObject monitortext;
    public GameObject Racket;

    private Vector3 thisworldrotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ラケットの角度を画面に表示
        thisworldrotation = this.transform.eulerAngles; 
        monitortext.GetComponent<TextMeshPro>().text = thisworldrotation.x.ToString("f0")+", "+thisworldrotation.y.ToString("f0")+", "+thisworldrotation.z.ToString("f0");
        Racket.GetComponent<GammaFunction>().xr = thisworldrotation.x;
        Racket.GetComponent<GammaFunction>().yr = thisworldrotation.y;
        Racket.GetComponent<GammaFunction>().zr = thisworldrotation.z;

    }
}
