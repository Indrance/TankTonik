using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour
{
    public float speed;
    public GameObject m_smallExplosionPrefab;
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }



    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Environment")
        {
            Destroy(gameObject);
            GameObject smallExplosion = GameObject.Instantiate(m_smallExplosionPrefab, transform.position, transform.rotation) as GameObject;
            GameObject.Destroy(smallExplosion, 1f);
        }
    }
}