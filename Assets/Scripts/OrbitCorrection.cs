using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCorrection : MonoBehaviour
{

    public GameObject Ball;
    public GameObject RacketPosition;
    public float CollectionForce = 0.000001f;
    private float begin_time; 

    private Rigidbody BallRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        begin_time = Time.time;
        BallRigidBody = Ball.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time - begin_time >= 25.0f)
        {
            if (Ball.transform.position.y > RacketPosition.transform.position.y)
            {
                if (BallRigidBody.velocity.y < 0)
                {
                    Vector3 forceVector = new Vector3(RacketPosition.transform.position.x - Ball.transform.position.x, 0, RacketPosition.transform.position.z - Ball.transform.position.z);
                    BallRigidBody.AddForce(forceVector * CollectionForce);
                }
            }
        }
        
    }
}
