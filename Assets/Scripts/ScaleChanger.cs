// コントローラーのB/Yボタンを押すと、ラケットのモデルとコライダーが変わる。

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChanger : MonoBehaviour
{
    private int counter = 0;
    public float stage1 = 1.0f;
    public float stage2 = 0.8f;
    public float stage3 = 0.6f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            counter += 1;
        }
        else if (OVRInput.GetDown(OVRInput.RawButton.Y))
        {
            counter += 1;
        }

        if (counter % 3 == 0)
        {
            this.transform.localScale = new Vector3(stage1, stage1, stage1);
        }
        else if (counter % 3 == 1)
        {
            this.transform.localScale = new Vector3(stage2, stage2, stage2);
        }
        else if (counter % 3 == 2)
        {
            this.transform.localScale = new Vector3(stage3, stage3, stage3);
        }
    }
}
