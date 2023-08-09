// ラケットとシャトルが衝突する時に、コントローラーが振動し、音が再生する。
// シャトルがケーブル、あるいは地面と衝突する3秒後にリスポーンする。

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealCollisionEvent : MonoBehaviour
{
    AudioSource pingpong_audio;
    Rigidbody rb;
    public Vector3 offset;
    public GameObject PingpongRacket;
    public GameObject Table;
    public GameObject Floor;
    public GameObject Respawnpoint;

    private float starttime;

    private bool once;

    // Start is called before the first frame update
    void Start()
    {
        pingpong_audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        offset = new Vector3(0.0f, 0.3f, 0.0f);
        starttime = Time.time;
    }
    void Update()
    {
        if (Time.time - starttime >= 10 && Time.time - starttime <= 66)
        {
            //Respawn();
            rb.useGravity = true;
        }
        else
        {
            rb.useGravity = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == PingpongRacket)
        {
            StartCoroutine(Vibrate(duration:0.05f, controller:OVRInput.Controller.RTouch));
            pingpong_audio.Play();
            //Debug.Log("Audio play");
        }

        if (collision.gameObject == Table)
        {
            if(once == false){
                StartCoroutine(WaitandRespawn());
                once = true;
            }              
        }

        if (collision.gameObject == Floor)
        {
            if(once == false){
                StartCoroutine(WaitandRespawn());
                once = true;
            }          
        }

    }

    public static IEnumerator Vibrate(float duration = 0.1f, float frequency = 0.1f, float amplitude = 0.1f, OVRInput.Controller controller = OVRInput.Controller.Active) 
    {
        //コントローラーを振動させる
        OVRInput.SetControllerVibration(frequency, amplitude, controller);

        //指定された時間待つ
        yield return new WaitForSeconds(duration);

        //コントローラーの振動を止める
        OVRInput.SetControllerVibration(0, 0, controller);
    }

    public IEnumerator WaitandRespawn() 
    {
       
        //指定された時間待つ
        yield return new WaitForSeconds(1.0f);
        Respawn();    
        
    }

    public void Respawn(){
        Vector3 racket_position = Respawnpoint.transform.position;
        this.transform.position = racket_position + offset;
        rb.velocity = Vector3.zero;

        once = false;
    }
}
