using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCorrection_2 : MonoBehaviour
{

    public GameObject Ball;
    public GameObject RacketPosition;
    private float CollectionForce = 0.000005f;

    private Rigidbody BallRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        BallRigidBody = Ball.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Ball.transform.position.y > RacketPosition.transform.position.y){
            if(BallRigidBody.velocity.y < 0){
                Vector3 forceVector = new Vector3(RacketPosition.transform.position.x - Ball.transform.position.x,0,RacketPosition.transform.position.z - Ball.transform.position.z);
                BallRigidBody.AddForce(forceVector * CollectionForce);
            }
        }
    }
}
