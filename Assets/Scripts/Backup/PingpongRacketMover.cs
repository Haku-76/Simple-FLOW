// 卓球のラケットを制御する。

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingpongRacketMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //カメラから画面上のタッチポイントまで光線を出す
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //どの3Dオブジェクトが衝突される
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //衝突されるオブジェクトの名前を出力する
                Debug.Log(hit.transform.name);

                if (hit.transform.name == "pingpong racket")
                {
                    //現在のオブジェクトの画面座標を取得する
                    Vector3 position = Camera.main.WorldToScreenPoint(hit.transform.position);
                    //マウスの画面座標のZ軸を現在のオブジェクトの画面座標のZ軸（距離）と等しくする
                    Vector3 MousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, position.z);
                    //正しいマウス画面座標をワールド座標に置き換えてオブジェクトに渡す
                    transform.position = Camera.main.ScreenToWorldPoint(MousePosition);
                }

            }
        }
    }
}
