using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    public GameObject racket;
    private Vector3 lastPosition;

    public float velocity_y_max;

    //public GameObject shuttle;
    [SerializeField]
    private float SpeedThreshould = 0.5f;

    private Vector3 previouslocation;

    

    void Start()
    {
        velocity_y_max = 0.0f;
        lastPosition = transform.position;
        Time.fixedDeltaTime = 0.005f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //float currentspeed = Vector3.Distance(racket.transform.position,previouslocation);

        //if(currentspeed>SpeedThreshould){
        //    Vector3 changevector = (racket.transform.position - previouslocation)/currentspeed * SpeedThreshould;

        //    racket.transform.position = previouslocation + changevector;
        //}

        //previouslocation = racket.transform.position;

        racket.transform.localPosition = Vector3.zero;
        racket.transform.localRotation = Quaternion.identity; //回転が0になります
        racket.GetComponent<Rigidbody>().velocity = ((transform.position - lastPosition) / Time.fixedDeltaTime)/2.0f;
        lastPosition = transform.position;

        //if (racket.GetComponent<Rigidbody>().velocity.y >= 1.5f)
        //{
        //    racket.GetComponent<Rigidbody>().velocity = new Vector3(racket.GetComponent<Rigidbody>().velocity.x, 1.5f,racket.GetComponent<Rigidbody>().velocity.z);
        //}

        

    }

    

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject == shuttle)
    //    {
    //        shuttle.GetComponent<Rigidbody>().velocity = racket.GetComponent<Rigidbody>().velocity;
    //        Debug.Log(collision.gameObject.name);
    //    }

    //}
}