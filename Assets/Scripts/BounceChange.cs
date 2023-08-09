using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceChange : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private PhysicMaterial ShuttleMaterial;

    [SerializeField]
    private float Threshold = 0.0001f;

    [SerializeField]
    private GameObject Shuttle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var speed = Shuttle.GetComponent<Rigidbody>().velocity.y;
        if(speed < Threshold)
        {
            ShuttleMaterial.bounciness = 0.0f;
        }
        else{
            ShuttleMaterial.bounciness = 0.7f;
        }
    }
}
