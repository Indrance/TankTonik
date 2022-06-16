using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerController : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    void ProcessInputs()
    {
        if (photonView.IsMine)
        {
            float x = Input.GetAxis("Horizontal");
            Debug.Log(x);
            this.transform.position += new Vector3(x, 0,0);
        }
        else
        {
           // Debug.Log(Input.GetButtonDown("Horizontal"));
        }
    }
}
