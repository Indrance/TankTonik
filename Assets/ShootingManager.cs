using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ShootingManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cannon cannon = this.gameObject.transform.Find("Cannon").gameObject.GetComponent<Cannon>();
        if (photonView.IsMine)
        {
            if (Input.GetKeyDown("space"))
            {
                if (Time.time > cannon.m_shootRateTimeStamp)
                {
                    //cannon.GetComponent<Cannon>().shoot();
                    //shoot();
                    PhotonView photonView = PhotonView.Get(this);
                    photonView.RPC("rpcShoot", RpcTarget.All);
                    cannon.m_shootRateTimeStamp = Time.time + cannon.shootRate;
                }
            }
        }
    }

    [PunRPC]
    void rpcShoot()
    {
        Cannon cannon = this.gameObject.transform.Find("Cannon").gameObject.GetComponent<Cannon>();
        cannon.shoot();
    }
}
