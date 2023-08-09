// バドミントンのラケットを制御する。

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadmintonRacketMover : MonoBehaviour
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
            //从摄像机开始，到屏幕触摸点，发出一条射线
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //撞击到了哪个3D物体
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //打印出碰撞到的节点的名字
                Debug.Log(hit.transform.name);

                if (hit.transform.name =="Badminton Racket")
                {
                    //获取到当前物体的屏幕坐标
                    Vector3 position = Camera.main.WorldToScreenPoint(hit.transform.position);
                    //让鼠标的屏幕坐标的Z轴等于当前物体的屏幕坐标的Z轴，也就是相隔的距离
                    Vector3 MousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, position.z);
                    //将正确的鼠标屏幕坐标换成世界坐标交给物体
                    transform.position = Camera.main.ScreenToWorldPoint(MousePosition);
                }

            }
        }
    }
}
