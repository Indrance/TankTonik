using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShrinking : MonoBehaviour
{
    //Assign this Camera in the Inspector
    public Camera m_OrthographicCamera;
    public GameObject wallTop;

    private float startTime = 0f;
    public float shrinkingDuration = 60f;
    public float shrinkingDelay = 5f;
    public float endSize = 5f;
    public float startSize = 20f;
    public float startZPosition = -4.83f;
    public float endZPosition = 11.54f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Camera Srhinking");
        this.startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = this.getElapsedTime();

        if(t < this.shrinkingDelay ){ // Too early to start shrinking
            return;
        }

        if(!this.m_OrthographicCamera) { // No camera, no shrinking
            return;
        }

        if(this.m_OrthographicCamera.orthographicSize == this.endSize) { // No Neative Size
            return;
        }

        float newSize = linearShrinking(t, this.startSize, this.endSize);
        this.m_OrthographicCamera.orthographicSize = Mathf.Max(this.endSize, newSize);
        float newZ = linearShrinking(t, this.startZPosition, this.endZPosition);
        var pos = this.wallTop.transform.localPosition;
        this.wallTop.transform.localPosition = new Vector3(pos.x, pos.y, newZ);

        Debug.Log("Update");
        Debug.Log(t);
        Debug.Log(this.startZPosition);
        Debug.Log(this.endZPosition);
        Debug.Log(newZ);
        // Debug.Log(this.m_OrthographicCamera.orthographicSize);
    }
    // Return time since Start method is called
    float getElapsedTime()
    {
        return Time.time - this.startTime;
    }
    float linearShrinking(float time, float start, float end)
    {   
        return start + ((end - start) * (time - this.shrinkingDelay) / this.shrinkingDuration);
    }
}
