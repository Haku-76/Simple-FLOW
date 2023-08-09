// 瞑想のシナリオを提示する。

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class MeditationScenario : MonoBehaviour
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
        offset = new Vector3(0.0f, 0.05f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
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
        this.GetComponent<TextMeshPro>().text = "今から瞑想を始めます.";
        yield return new WaitForSeconds(3.0f);

        this.GetComponent<TextMeshPro>().text = "ラケットの上に\nボールを乗せ落とさないようにキープしよう.";
        yield return new WaitForSeconds(3.0f);

        this.GetComponent<TextMeshPro>().text = "3";
        yield return new WaitForSeconds(1.0f);

        this.GetComponent<TextMeshPro>().text = "2";
        yield return new WaitForSeconds(1.0f);

        this.GetComponent<TextMeshPro>().text = "1";
        yield return new WaitForSeconds(1.0f);

        this.GetComponent<TextMeshPro>().text = "瞑想開始！";
        yield return new WaitForSeconds(1.0f);

        this.GetComponent<TextMeshPro>().text = "　";
        yield return new WaitForSeconds(39.0f);

        this.GetComponent<TextMeshPro>().text = "瞑想終わり";
        yield return new WaitForSeconds(1.0f);

        if(PracticeLevelManager.MaxHit >= 10){
            SceneManager.LoadScene("Level 5");
        }
        else if (PracticeLevelManager.MaxHit >= 5){
            SceneManager.LoadScene("Level 3");
        }
        else{
            SceneManager.LoadScene("Level 1");
        }
    }
}
