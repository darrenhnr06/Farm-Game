using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchZoom : MonoBehaviour
{
    public float perspectiveZoomSpeed = .5f;
    public float panSpeed = .5f;

    private void Update()
    {
        if(Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaDistance = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaDistance = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudedistance = prevTouchDeltaDistance - touchDeltaDistance;
            Camera camera = GetComponent<Camera>();

            camera.fieldOfView += deltaMagnitudedistance * perspectiveZoomSpeed;
       
            if(camera.fieldOfView < 5f)
            {
                camera.fieldOfView = 5f;
            }
            else if(camera.fieldOfView > 64f)
            {
                camera.fieldOfView = 64f;
            }
        }

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(-touchDeltaPosition.x * panSpeed, -touchDeltaPosition.y * panSpeed, 0);

            
            if (transform.position.x < -20f)
            {
                Vector3 vector3 = transform.position;
                vector3.x = -20f;
                transform.position = vector3;
            }
            else if (transform.position.x > 41f)
            {
                Vector3 vector3 = transform.position;
                vector3.x = 41f;
                transform.position = vector3;
            }

            if (transform.position.z < 82f)
            {
                Vector3 vector3 = transform.position;
                vector3.z = 82f;
                transform.position = vector3;
            }
            else if (transform.position.z > 85f)
            {
                Vector3 vector3 = transform.position;
                vector3.z = 85f;
                transform.position = vector3;
            }

            if (transform.position.y < 51f)
            {
                Vector3 vector3 = transform.position;
                vector3.y = 51f;
                transform.position = vector3;
            }
            else if (transform.position.y > 151f)
            {
                Vector3 vector3 = transform.position;
                vector3.y = 151f;
                transform.position = vector3;
            }

        }
    }
}
