// 練習のシナリオを提示する。

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PracticeScenario : MonoBehaviour
{
    private float starttime;

    Rigidbody rb;
    public Vector3 offset;
    public GameObject Respawnpoint;
    public GameObject Shuttle;

    private bool begin = true;

    // Start is called before the first frame update
    void Start()
    {
        //文字を表示する関数
        StartCoroutine(Display());
        starttime = Time.time;

        rb = GetComponent<Rigidbody>();
        offset = new Vector3(0.0f, 0.3f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time - starttime >= 16 && Time.time - starttime <= 66)
        {
            this.GetComponent<TextMeshPro>().text = (66 - Mathf.FloorToInt(Time.time - starttime)).ToString();
        }


        if (Time.time >= 16.0f && begin == true)
        {
            begin = false;
            Vector3 racket_position = Respawnpoint.transform.position;
            Shuttle.transform.position = racket_position + offset;
            rb.velocity = Vector3.zero;      
        }

    }

    public IEnumerator Display()
    {
        this.GetComponent<TextMeshPro>().text = "お手軽FLOWへようこそ！";
        yield return new WaitForSeconds(3.0f);

        this.GetComponent<TextMeshPro>().text = "本体験は練習 瞑想 本番 \nという流れになっています.";
        yield return new WaitForSeconds(3.0f);

        this.GetComponent<TextMeshPro>().text = "ボールは地面に落ちてから\n1秒後にリスポーンします.";
        yield return new WaitForSeconds(3.0f);

        this.GetComponent<TextMeshPro>().text = "それでは\n練習してみましょう！";
        yield return new WaitForSeconds(3.0f);

        this.GetComponent<TextMeshPro>().text = "3";
        yield return new WaitForSeconds(1.0f);

        this.GetComponent<TextMeshPro>().text = "2";
        yield return new WaitForSeconds(1.0f);

        this.GetComponent<TextMeshPro>().text = "1";
        yield return new WaitForSeconds(1.0f);

        this.GetComponent<TextMeshPro>().text = "練習開始！";
        yield return new WaitForSeconds(1.0f);

        this.GetComponent<TextMeshPro>().text = "　";
        yield return new WaitForSeconds(50.0f);

        this.GetComponent<TextMeshPro>().text = "練習終わり.";
        yield return new WaitForSeconds(1.0f);

        this.GetComponent<TextMeshPro>().text = "それでは\n瞑想に移ります";
        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene("Meditation");//シーン遷移
    }
}
