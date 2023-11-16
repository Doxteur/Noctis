using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform followTransform;
    public BoxCollider2D mapBounds;
    public float lerpSpeed = 2f; // Vitesse d'interpolation

    private float xMin, xMax, yMin, yMax;
    private float camOrthsize;
    private float cameraRatio;
    private Camera mainCam;

    private void Start()
    {
        xMin = mapBounds.bounds.min.x;
        xMax = mapBounds.bounds.max.x;
        yMin = mapBounds.bounds.min.y;
        yMax = mapBounds.bounds.max.y;
        mainCam = GetComponent<Camera>();
        camOrthsize = mainCam.orthographicSize;
        cameraRatio = (xMax + camOrthsize) / 2.0f;
    }

    void LateUpdate()
    {
        float targetX = Mathf.Clamp(followTransform.position.x, xMin + cameraRatio, xMax - cameraRatio);
        float targetY = Mathf.Clamp(followTransform.position.y, yMin + camOrthsize, yMax - camOrthsize);

        // Interpolation linéaire de la position
        float newX = Mathf.Lerp(transform.position.x, targetX, lerpSpeed * Time.deltaTime);
        float newY = Mathf.Lerp(transform.position.y, targetY, lerpSpeed * Time.deltaTime);

        transform.position = new Vector3(newX, newY, transform.position.z);
    }
}
