using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public GameObject m_bigExplosionPrefab;
    public CharacterController controller;

    private Vector3 v_movement;
    private Vector3 velocity;
    public float gravity = -9.81f;
    public float speed = 6f;
    private AudioSource mAudioExplosion;

    private void Start()
    {
        mAudioExplosion = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        v_movement = controller.transform.forward * vertical;

        controller.transform.Rotate(Vector3.up * horizontal * (100f * Time.deltaTime));
        controller.Move(v_movement * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Shot")
        {
            Destroy(hit.gameObject);
            Destroy(gameObject);
            GameObject bigExplosion = GameObject.Instantiate(m_bigExplosionPrefab, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
            mAudioExplosion.Play();
            GameObject.Destroy(bigExplosion, 1.6f);
        }
    }
}
