// 本番のシナリオを提示する。

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RealScenario : MonoBehaviour
{
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

        rb = GetComponent<Rigidbody>();
        offset = new Vector3(0.0f, 0.3f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + scene.name + "'.");

        if (Time.time >= 10.0f && begin == true)
        {
            begin = false;
            Vector3 racket_position = Respawnpoint.transform.position;
            Shuttle.transform.position = racket_position + offset;
            rb.velocity = Vector3.zero;
        }
    }
    public IEnumerator Display()
    {
        Scene scene = SceneManager.GetActiveScene();
        this.GetComponent<TextMeshPro>().text = scene.name + "\nそれでは本番です.";
        yield return new WaitForSeconds(3.0f);

        this.GetComponent<TextMeshPro>().text = "1分間ボールを落とさずに\nリフティングしましょう！";
        yield return new WaitForSeconds(3.0f);

        this.GetComponent<TextMeshPro>().text = "3";
        yield return new WaitForSeconds(1.0f);

        this.GetComponent<TextMeshPro>().text = "2";
        yield return new WaitForSeconds(1.0f);

        this.GetComponent<TextMeshPro>().text = "1";
        yield return new WaitForSeconds(1.0f);

        this.GetComponent<TextMeshPro>().text = "本番開始！";
        yield return new WaitForSeconds(1.0f);

        this.GetComponent<TextMeshPro>().text = "　";
        yield return new WaitForSeconds(52.0f);

        this.GetComponent<TextMeshPro>().text = "リフティング終了.\nすばらしい結果でした！";
        yield return new WaitForSeconds(3.0f);

    }
}
