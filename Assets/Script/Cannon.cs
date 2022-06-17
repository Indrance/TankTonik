using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Cannon : MonoBehaviourPunCallbacks
{
    public float shootRate;
    private float m_shootRateTimeStamp;
    private float ScrollWheelChange;
    public float maxAngle;
    public float minAngle;

    public GameObject m_shotPrefab;
    void Update()
    {
        if (transform.eulerAngles.x < 315 && transform.eulerAngles.x > 157.5f)
        {
            Vector3 temp = transform.rotation.eulerAngles;
            temp.x = -45.0f;
            transform.rotation = Quaternion.Euler(temp);
        }

        if (transform.eulerAngles.x > 0 && transform.eulerAngles.x < 157.5f)
        {
            Vector3 temp = transform.rotation.eulerAngles;
            temp.x = 0;
            transform.rotation = Quaternion.Euler(temp);
        }

        ScrollWheelChange = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(ScrollWheelChange) > 0)
        {
            if (ScrollWheelChange < 0)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x - 1, transform.eulerAngles.y, transform.eulerAngles.z);
            }
            else if(ScrollWheelChange > 0)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x + 1, transform.eulerAngles.y, transform.eulerAngles.z);
            }
        }
        if (photonView.IsMine){
            if (Input.GetKeyDown("space"))
            {
                if (Time.time > m_shootRateTimeStamp)
                {
                    //shoot();
                    PhotonView photonView = PhotonView.Get(this);
                    photonView.RPC("shoot", RpcTarget.All);
                    m_shootRateTimeStamp = Time.time + shootRate;
                }
            }
        }
    }

    [PunRPC]
    void shoot()
    {
        GameObject shell = GameObject.Instantiate(m_shotPrefab, transform.position, transform.rotation) as GameObject;
    }
}
