// シナリオを提示する。

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayText : MonoBehaviour
{
    //表示する文字
    private string[] textarray = {"お手軽FLOWへようこそ！",
                                "本体験は 練習 瞑想 本番 という流れになっています",
                                "ボールは地面に落ちてから３秒後にリスポーンします",
                                "それでは練習してみましょう！"
    };
    // Start is called before the first frame update
    void Start()
    {
        //文字を表示する関数（引数は表示秒数)
        StartCoroutine(Display(3.0f,1.0f));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Display(float duration = 0.1f, float wait = 0.1f) 
    {
        yield return new WaitForSeconds(wait);

        int i;
        int time = textarray.Length; 

        for(i=0;i<time;i++){
            this.GetComponent<TextMeshPro>().text = textarray[i];
        
            //指定された時間待つ
            yield return new WaitForSeconds(duration);
        }
        

        
    }
}
