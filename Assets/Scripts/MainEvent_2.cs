//２個用 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEvent_2 : MonoBehaviour
{
    public GameObject PingpongRacket;
    public GameObject Shuttle_1;
    public GameObject Shuttle_2;
    public GameObject Respawnpoint;

    Rigidbody rb_1;
    Rigidbody rb_2;
    public Vector3 offset_1;
    public Vector3 offset_2;
    public static bool begin;
    
    // 開始時間
    private float starttime;

    // ラケットと時間の変化
    [SerializeField] public float level_time;
    private float interval_time;
    [SerializeField] public float racket_scale;
    [SerializeField] public float time_scale;

    public int level = 0;
    //1 初級
    //2 中級
    //3 高級

    // レベルのパラメータ
    private float racket_continue_time;
    private float racket_target;
    private float racket_count;
    private float racket_variety;

    private float speed_continue_time;
    private float speed_target;
    private float speed_count;
    private float speed_variety;

    // コントローラーの調整
    [SerializeField] private float frequency;
    [SerializeField] private float amplitude;
    [SerializeField] private float duration;
    [SerializeField] private float feedback_changer;
    [SerializeField] private float force_changer;

    // Start is called before the first frame update
    void Start()
    {

        starttime = Time.time;

        rb_1 = Shuttle_1.GetComponent<Rigidbody>();
        rb_1.useGravity = false;
        offset_1 = new Vector3(-0.05f, 0.5f, 0.0f);

        rb_2 = Shuttle_2.GetComponent<Rigidbody>();
        rb_2.useGravity = false;
        offset_2 = new Vector3(0.05f, 0.5f, 0.0f);

        begin = false;

        Invoke("Level_Judger", 25);

        frequency = 0.1f;
        amplitude = 0.1f;
        duration = 0.1f;
        feedback_changer = (0.1f - 0.03f) / 60.0f;
        force_changer = 0.000005f / 20.0f;

        InvokeRepeating("Feedback_Change", 10, 1.0f);
        InvokeRepeating("Force_Change", 10, 1.0f);

        Time.timeScale = 0.9f;
        interval_time = 0.2f;
        racket_scale = PingpongRacket.transform.localScale.x;
        time_scale = Time.timeScale;

        InvokeRepeating("Racket_Variety_Change", 25, interval_time); //25秒後に0.2秒ごとに関数を呼び出す
        InvokeRepeating("Speed_Variety_Change", 25, interval_time); //25秒後に0.2秒ごとに関数を呼び出す

    }
    void Feedback_Change()
    {
        frequency -= feedback_changer;
        amplitude -= feedback_changer;
        duration -= feedback_changer;
        Shuttle_1.GetComponent<AudioSource>().volume -= feedback_changer * 10.0f;
    }

    void Force_Change()
    {
        Shuttle_1.GetComponent<OrbitCorrection>().CollectionForce += force_changer;
        // Shuttle_2.GetComponent<OrbitCorrection>().CollectionForce -= 1.0f;
    }

    void Level_Judger()
    {

        level = 2;

        //if (PracticeLevelManager.Failedcount >= 6)
        //{
        //    level = 1;
        //} else if (PracticeLevelManager.Failedcount <= 1)
        //{
        //    level = 3;

        //} else {
        //    level = 2;
        //}

    }
        
    void Racket_Variety_Change()
    {

        if (level == 1)
        {
            racket_continue_time = 20.0f;
            racket_target = 1.4f;

            // racket_count = racket_continue_time / interval_time;
            racket_count = 100;
            racket_variety = (racket_target - 1.1f) / racket_count;

        }
        else if (level == 2)
        {
            racket_continue_time = 20.0f;
            racket_target = 1.3f;

            // racket_count = racket_continue_time / interval_time;
            racket_count = 100;
            racket_variety = (racket_target - 1.1f) / racket_count;

        }
        else if (level == 3)
        {
            racket_continue_time = 20.0f;
            racket_target = 1.2f;

            // racket_count = racket_continue_time / interval_time;
            racket_count = 100;
            racket_variety = (racket_target - 1.1f) / racket_count;

        }

        if (level_time >= 0 && racket_scale <= racket_target)
        {
            racket_scale += racket_variety;
            PingpongRacket.transform.localScale = new Vector3(racket_scale, racket_scale, racket_scale);
        }

    }

    void Speed_Variety_Change()
    {

        if (level == 1)
        {
            speed_continue_time = 20.0f;
            speed_target = 0.6f;

            // speed_count = speed_continue_time / interval_time;
            speed_count = 100;
            speed_variety = (speed_target - 0.9f) / speed_count;

        }
        else if (level == 2)
        {
            speed_continue_time = 20.0f;
            speed_target = 0.75f;

            // speed_count = speed_continue_time / interval_time;
            speed_count = 100;
            speed_variety = (speed_target - 0.9f) / speed_count;

        }
        else if (level == 3)
        {
            speed_continue_time = 20.0f;
            speed_target = 0.75f;

            // speed_count = speed_continue_time / interval_time;
            speed_count = 100;
            speed_variety = (speed_target - 0.9f) / speed_count;

        }

        if (level_time >= 0 && time_scale >= speed_target)
        {
            time_scale += speed_variety;
            Time.timeScale = time_scale;
        }

    }

    void Update()
    {

        level_time = Time.time - starttime - 25.0f;

        if (Time.time - starttime <= 10.0f)
        {
            Vector3 racket_position = Respawnpoint.transform.position;
            Shuttle_1.transform.position = racket_position + offset_1;
            Shuttle_2.transform.position = racket_position + offset_2;
        }

        else {

            rb_1.useGravity = true;

            Vector3 racket_position = Respawnpoint.transform.position;

            if (begin == false)
            {
                Shuttle_2.transform.position = racket_position + offset_2;
            }
            //rb_2.useGravity = true;
        }

        if (Shuttle_1.GetComponent<OrbitCorrection>().CollectionForce >= 0.000005f)
        {
            force_changer = 0.0f;
        }

    }

    public IEnumerator Vibrate(OVRInput.Controller controller = OVRInput.Controller.Active) 
    {    
        //コントローラーを振動させる
        OVRInput.SetControllerVibration(frequency, amplitude, controller);

        //指定された時間待つ
        yield return new WaitForSeconds(duration);

        //コントローラーの振動を止める
        OVRInput.SetControllerVibration(0, 0, controller);
    }

}
