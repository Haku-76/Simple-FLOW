// ゲームの時間進行を制御することにより、シャトルの速度を調整する。

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpeedChanger : MonoBehaviour
{

    public float timescale;

    // Start is called before the first frame update
    void Start()
    {
        //Scene scene = SceneManager.GetActiveScene();

        //if (scene.name == "Practice")
        //{
        //    timescale = 1.0f;
        //}
        //else if (scene.name == "Meditation")
        //{
        //    timescale = 0.9f;
        //}

        Time.timeScale = timescale;

    }

    // Update is called once per frame
    void Update()
    {
        //Scene scene = SceneManager.GetActiveScene();
        // Debug.Log("Active Scene is '" + scene.name + "'.");

        //if(Time.time >= 10)
        //{
        //    timescale = 0.9f;
        //    Time.timeScale = timescale;
        //}
        //if(Time.time >= 20)
        //{
        //    timescale = 1.0f;
        //    Time.timeScale = timescale;
        //}

    }
}
