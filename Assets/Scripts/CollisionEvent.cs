//１個用 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollisionEvent : MonoBehaviour
{
    // 衝突用
    AudioSource pingpong_audio;
    Rigidbody rb;
    public Vector3 offset;
    public GameObject PingpongRacket;
    public GameObject Table;
    public GameObject Floor;
    public GameObject Respawnpoint;
    public GameObject Event;


    // 開始時間
    private float starttime;
    private float collisiontime;

    private bool once;

    // Start is called before the first frame update
    void Start()
    {
        starttime = Time.time;
        pingpong_audio = this.GetComponent<AudioSource>();
        rb = this.GetComponent<Rigidbody>();
        offset = new Vector3(0.0f, 0.5f, 0.0f);

    }

    void Update()
    {

        if (Time.time - starttime >= 70.0f)
        {
            this.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown("r"))
        {
            StartCoroutine(WaitandRespawn());
            //Another.GetComponent<CollisionEvent_2>().miss = false;
        }

        //if(miss == true && Another.GetComponent<CollisionEvent_2>().miss == true)
        //{
        //    Respawn(Another);
        //    Another.GetComponent<CollisionEvent_2>().miss = false;
        //}

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == PingpongRacket)
        {

            StartCoroutine(Event.GetComponent<MainEvent_1>().Vibrate(controller: OVRInput.Controller.RTouch));
            pingpong_audio.Play();

            if (Time.time - starttime >= 5.0f && Time.time - starttime <= 65.0f)
            {
                PracticeLevelManager.Hitcount += 1;
                if (PracticeLevelManager.Hitcount > PracticeLevelManager.MaxHit)
                {
                    PracticeLevelManager.MaxHit = PracticeLevelManager.Hitcount;
                }
            }
            if (Time.time - starttime >= 5.0f && Time.time - starttime <= PracticeLevelManager.begintime + 5.0f)
            {
                PracticeLevelManager.begin_Hitcount += 1;
                if (PracticeLevelManager.begin_Hitcount > PracticeLevelManager.begin_MaxHit)
                {
                    PracticeLevelManager.begin_MaxHit = PracticeLevelManager.begin_Hitcount;
                }
            }
            if (Time.time - starttime >= 65.0f - PracticeLevelManager.lasttime && Time.time - starttime <= 65.0f)
            {
                PracticeLevelManager.last_Hitcount += 1;
                if (PracticeLevelManager.last_Hitcount > PracticeLevelManager.last_MaxHit)
                {
                    PracticeLevelManager.last_MaxHit = PracticeLevelManager.last_Hitcount;
                }
            }

        }

        if (collision.gameObject == Table)
        {
            if (once == false)
            {
                StartCoroutine(WaitandRespawn());
                once = true;

                if (Time.time - starttime >= 5.0f && Time.time - starttime <= 65.0f)
                {
                    PracticeLevelManager.Failedcount += 1;
                    PracticeLevelManager.Hitcount = 0;
                }
                if (Time.time - starttime >= 5.0f && Time.time - starttime <= PracticeLevelManager.begintime + 5.0f)
                {
                    PracticeLevelManager.begin_Failedcount += 1;
                    PracticeLevelManager.begin_Hitcount = 0;
                }
                if (Time.time - starttime >= 65.0f - PracticeLevelManager.lasttime && Time.time - starttime <= 65.0f)
                {
                    PracticeLevelManager.last_Failedcount += 1;
                    PracticeLevelManager.last_Hitcount = 0;
                }

            }
        }

        if (collision.gameObject == Floor)
        {
            if (once == false)
            {
                StartCoroutine(WaitandRespawn());
                once = true;

                if (Time.time - starttime >= 5.0f && Time.time - starttime <= 65.0f)
                {
                    PracticeLevelManager.Failedcount += 1;
                    PracticeLevelManager.Hitcount = 0;
                }
                if (Time.time - starttime >= 5.0f && Time.time - starttime <= PracticeLevelManager.begintime + 5.0f)
                {
                    PracticeLevelManager.begin_Failedcount += 1;
                    PracticeLevelManager.begin_Hitcount = 0;
                }
                if (Time.time - starttime >= 65.0f - PracticeLevelManager.lasttime && Time.time - starttime <= 65.0f)
                {
                    PracticeLevelManager.last_Failedcount += 1;
                    PracticeLevelManager.last_Hitcount = 0;
                }

            }
        }
    }

    public IEnumerator WaitandRespawn()
    {
        if (Time.time - starttime <= 70.0f)
        {
            //指定された時間待つ
            yield return new WaitForSeconds(1.0f);

            Respawn();
        }
    }

    public void Respawn()
    {

        Vector3 racket_position = Respawnpoint.transform.position;
        this.transform.position = racket_position + offset;
        rb.velocity = Vector3.zero;

        once = false;
    }


}
