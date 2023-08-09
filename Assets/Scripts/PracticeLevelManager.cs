using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeLevelManager : MonoBehaviour
{

    public static int Hitcount = 0;
    public static int MaxHit = 0;
    public static int Failedcount = 0;

    public static int begin_Hitcount = 0;
    public static int begin_MaxHit = 0;
    public static int begin_Failedcount = 0;

    public static int last_Hitcount = 0;
    public static int last_MaxHit = 0;
    public static int last_Failedcount = 0;

    public static int begintime = 20;
    public static int lasttime = 40;

    public int hitcount;
    public int maxhit;
    public int failedcount;

    public int begin_hitcount;
    public int begin_maxHit;
    public int begin_failedcount;

    public int last_hitcount;
    public int last_maxhit;
    public int last_failedcount;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        hitcount=Hitcount;
        maxhit=MaxHit;
        failedcount=Failedcount;

        begin_hitcount=begin_Hitcount;
        begin_maxHit=begin_MaxHit;
        begin_failedcount=begin_Failedcount;

        last_hitcount=last_Hitcount;
        last_maxhit=last_MaxHit;
        last_failedcount=last_Failedcount;
}
}
