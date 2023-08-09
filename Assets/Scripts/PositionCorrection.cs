using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionCorrection : MonoBehaviour
{
    public GameObject shuttle;
    
    public Vector3 racket_pos_last;
    public Vector3 racket_pos_now;
    public Vector3 shuttle_pos;

    private bool check = false;
    private float distance;

    public float error_x;
    public float error_z;
    private float error;

    private float KP_x = 0.1f;
    private float KP_z = 0.1f;
    public float correction_x;
    public float correction_z;



    // Start is called before the first frame update
    void Start()
    {
        racket_pos_last = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        racket_pos_now = this.transform.position;
        shuttle_pos = shuttle.transform.position;

        //error_x = Mathf.Pow(racket_pos_now.x - shuttle_pos.x, 2);
        //error_z = Mathf.Pow(racket_pos_now.z - shuttle_pos.z, 2);
        error_x = Mathf.Abs(racket_pos_now.x - shuttle_pos.x);
        error_z = Mathf.Abs(racket_pos_now.z - shuttle_pos.z);
        error = Mathf.Sqrt(Mathf.Pow(error_x,2) + Mathf.Pow(error_z,2));

        correction_x = error_x * KP_x;
        correction_z = error_z * KP_z;
 
        checkmove();
        if(check == true && shuttle_pos.y > racket_pos_now.y)
        {
            assist_x();
            assist_z();
        }

        racket_pos_last = racket_pos_now;
    }

    void checkmove()
    {
        distance = Vector3.Distance(racket_pos_last, racket_pos_now);
        if (distance > 0.01f)
        {
            check = true;
        }
        else
        {
            check = false;
        }

    }
    void assist_x()
    {
        if(shuttle_pos.x > racket_pos_now.x)
        {
            this.transform.position += new Vector3(correction_x, 0, 0);
        }
        else if(shuttle_pos.x  < racket_pos_now.x)
        {
            this.transform.position -= new Vector3(correction_x, 0, 0);
        }
    }

    void assist_z()
    {
        this.transform.position += new Vector3(0, 0, correction_z);
    }

}
