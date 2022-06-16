using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float shootRate;
    private float m_shootRateTimeStamp;

    public GameObject m_shotPrefab;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (Time.time > m_shootRateTimeStamp)
            {
                shoot();
                m_shootRateTimeStamp = Time.time + shootRate;
            }
        }
    }
    void shoot()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        GameObject shell = GameObject.Instantiate(m_shotPrefab, transform.position, transform.rotation) as GameObject;
    }
}
