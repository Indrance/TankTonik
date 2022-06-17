using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShrinking : MonoBehaviour
{
    private float startTime = 0f;
    public float shrinkingDuration = 60f;
    public float shrinkingDelay = 30f;

    // Camera size
    public Camera m_OrthographicCamera;
    public float endSize = 5f;
    public float startSize = 20f;
    // Top wall
    public GameObject wallTop;
    public float startTopPosition = -4.83f;
    public float endTopPosition = 11.54f;
    // Left wall
    public GameObject wallLeft;
    public float startLeftPosition = 0f;
    public float endLeftPosition = -15f;
    // Bottom wall
    public GameObject wallBottom;
    public float startBottomPosition = 34.83f;
    public float endBottomPosition = 18.6f;
    // Right wall
    public GameObject wallRight;
    public float startRightPosition = -40f;
    public float endRightPosition = -25f;

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


        //  Top Wall
        float topZ = linearShrinking(t, this.startTopPosition, this.endTopPosition);
        var topPos = this.wallTop.transform.localPosition;
        this.wallTop.transform.localPosition = new Vector3(topPos.x, topPos.y, Mathf.Min(this.endTopPosition,topZ));
        //  Left Wall
        float leftX = linearShrinking(t, this.startLeftPosition, this.endLeftPosition);
        var leftPos = this.wallLeft.transform.localPosition;
        this.wallLeft.transform.localPosition = new Vector3(Mathf.Max(this.endLeftPosition,leftX), leftPos.y, leftPos.z);
        //  Bottom Wall
        float bottomZ = linearShrinking(t, this.startBottomPosition, this.endBottomPosition);
        var bottomPos = this.wallBottom.transform.localPosition;
        this.wallBottom.transform.localPosition = new Vector3(bottomPos.x, bottomPos.y, Mathf.Max(this.endBottomPosition,bottomZ));
        //  Left Wall
        float rightX = linearShrinking(t, this.startRightPosition, this.endRightPosition);
        var rightPos = this.wallRight.transform.localPosition;
        this.wallRight.transform.localPosition = new Vector3(Mathf.Min(this.endRightPosition,rightX), rightPos.y, rightPos.z);

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
