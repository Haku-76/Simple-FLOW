// ラケットとシャトルが衝突する時に、コントローラーが振動し、音が再生する。
// シャトルがケーブル、あるいは地面と衝突する3秒後にリスポーンする。

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCollisionEvent : MonoBehaviour
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

    private float freq;

    private float amp;

    private float dur;

    public int selectmode = 0;
    //0 1.0x
    //1 0.8x
    //2 0.6x

    // Start is called before the first frame update
    void Start()
    {
        pingpong_audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        offset = new Vector3(0.0f, 0.3f, 0.0f);
        starttime = Time.time;
        freq = 0.1f;
        amp = 0.1f;
        if (selectmode == 0){
            Time.timeScale = 1.0f;
            freq = 0.1f;
            amp = 0.1f;
            dur = 0.1f;
            this.GetComponent<AudioSource>().volume = 1.0f;
        }
        if (selectmode == 1){
            Time.timeScale = 0.8f;
            freq = 0.07f;
            amp = 0.07f;
            dur = 0.07f;
            this.GetComponent<AudioSource>().volume = 0.7f;
        }
        if (selectmode == 2){
            Time.timeScale = 0.6f;
            freq = 0.03f;
            amp = 0.03f;
            dur = 0.03f;
            this.GetComponent<AudioSource>().volume = 0.3f;
        }

    }

    void Update()
    {
       
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == PingpongRacket)
        {
            StartCoroutine(Vibrate(duration:0.05f, controller:OVRInput.Controller.RTouch));
            pingpong_audio.Play();
            //Debug.Log("Audio play");
            if(Time.time - starttime >=16&&Time.time - starttime<=66){
                PracticeLevelManager.Hitcount += 1;
                if(PracticeLevelManager.Hitcount>PracticeLevelManager.MaxHit){
                    PracticeLevelManager.MaxHit = PracticeLevelManager.Hitcount;
                }
            }
        }

        if (collision.gameObject == Table)
        {
            if(once == false){
                StartCoroutine(WaitandRespawn());
                once = true;
                if(Time.time - starttime >=16&&Time.time - starttime<=66){
                    PracticeLevelManager.Failedcount += 1;
                    PracticeLevelManager.Hitcount = 0;
                }
            }              
        }

        if (collision.gameObject == Floor)
        {
            if(once == false){
                StartCoroutine(WaitandRespawn());
                once = true;
                if(Time.time - starttime >=16&&Time.time - starttime<=66){
                    PracticeLevelManager.Failedcount += 1;
                    PracticeLevelManager.Hitcount = 0;
                    
                }
            }  
        }
        /*
        if(PracticeLevelManager.Hitcount>=20){
            Time.timeScale = 0.6f;
            freq = 0.06f;
            amp = 0.06f;
        }
        else if(PracticeLevelManager.Hitcount>=10){
            Time.timeScale = 0.8f;
            freq = 0.08f;
            amp = 0.08f;
        }
        else{
            Time.timeScale = 1.0f;
            freq = 0.1f;
            amp = 0.1f;
        }
        */

    }

    public IEnumerator Vibrate(float duration = 0.1f, float frequency = 0.1f, float amplitude = 0.1f, OVRInput.Controller controller = OVRInput.Controller.Active) 
    {
        
        //コントローラーを振動させる
        OVRInput.SetControllerVibration(freq, amp, controller);

        //指定された時間待つ
        yield return new WaitForSeconds(dur);

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
