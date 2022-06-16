using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Environment")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Tank")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
          
        }
    }

}