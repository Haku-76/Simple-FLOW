// シナリオを提示する。

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainScenario : MonoBehaviour
{

    [SerializeField] private AudioSource text;
    [SerializeField] private AudioSource table;
    [SerializeField] private AudioClip clip1;
    [SerializeField] private AudioClip clip2;
    [SerializeField] private AudioClip clip3;

    private float starttime;

    // Start is called before the first frame update
    void Start()
    {

        //文字を表示する関数
        StartCoroutine(Display());
        starttime = Time.time;

    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time - starttime >= 10.0f && Time.time - starttime <= 70.0f)
        {
            this.GetComponent<TextMeshPro>().text = "Time left: " + (70 - Mathf.FloorToInt(Time.time - starttime)).ToString();
        }

    }

    public IEnumerator Display()
    {
        table.PlayOneShot(clip3);

        this.GetComponent<TextMeshPro>().text = "READY！";
        yield return new WaitForSeconds(6.0f);

        text.PlayOneShot(clip1);

        this.GetComponent<TextMeshPro>().text = "3";
        yield return new WaitForSeconds(1.0f);

        this.GetComponent<TextMeshPro>().text = "2";
        yield return new WaitForSeconds(1.0f);

        this.GetComponent<TextMeshPro>().text = "1";
        yield return new WaitForSeconds(1.0f);

        this.GetComponent<TextMeshPro>().text = "START";
        yield return new WaitForSeconds(1.0f);

        yield return new WaitForSeconds(60.0f);

        text.PlayOneShot(clip2);

        string line1 = "前半30秒の記録： " + PracticeLevelManager.begin_MaxHit + " 回\n";
        string line2 = "後半30秒の記録： " + PracticeLevelManager.last_MaxHit + " 回\n";
        string line3 = "歴代最高記録 " + PracticeLevelManager.MaxHit + " 回達成！！！";

        this.GetComponent<TextMeshPro>().text = line1 + line2 + line3;

    }
}
