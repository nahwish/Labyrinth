using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform objectToFollow;
    [SerializeField]
    float smoothSpeed = 10.0f;

    Vector3 cameraOffset;
    Vector3 cameraPosition;

    [SerializeField] GameObject lookBackCamera;
    [SerializeField] GameObject regularCamera;
    [SerializeField] Animator anim;

    void Start()
    {
        cameraPosition = this.transform.position;
        cameraOffset = objectToFollow.position + cameraPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 smoothMoving = Vector3.Lerp(transform.position, objectToFollow.position + cameraOffset, smoothSpeed * Time.deltaTime);
        transform.position = smoothMoving;
        setCamBack();
    }

    void setCamBack()
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                if (regularCamera.activeSelf)
            {
                regularCamera.SetActive(false);
            }
                lookBackCamera.SetActive(true);
            }
            if(Input.GetKeyDown(KeyCode.Y))
            {
                if (lookBackCamera.activeSelf)
            {
                lookBackCamera.SetActive(false);
            }
                regularCamera.SetActive(true);
            }
        }
}
