// コントローラーのA/Xボタンを押すと、シャトルはコントローラー上0.5mのところに戻る。

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuttleRespawn : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 offset;
    public GameObject Respawnpoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        offset = new Vector3(0.0f, 0.3f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject racket = GameObject.Find("OVRControllerPrefab");
        //Vector3 racket_position = racket.transform.position;
        Vector3 racket_position = Respawnpoint.transform.position;
        //Debug.Log("Racket Position = " + racket_position);

        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            this.transform.position = racket_position + offset;
            rb.velocity = Vector3.zero;
        }
        else if (OVRInput.GetDown(OVRInput.RawButton.X))
        {
            this.transform.position = racket_position + offset;
            rb.velocity = Vector3.zero;
        }
    }
}
