using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    [ExecuteInEditMode]
    Transform cam;
    Vector3 targetAngel =  Vector3.zero;

    void Start()
    {
        cam = Camera.main.transform;
    }

     void Update()
    {
        transform.LookAt(cam);
        targetAngel = transform.localEulerAngles;
        targetAngel.x = 0;
        targetAngel.y = 0;
        transform.localEulerAngles = targetAngel;
    }
}
