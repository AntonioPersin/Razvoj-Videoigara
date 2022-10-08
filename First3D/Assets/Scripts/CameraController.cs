using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public GameObject target;

    public float rotationSpeed = 1.5f;

    private float rotationY;
    private Vector3 offset;

    void Start()
    {
        rotationY = transform.eulerAngles.y;
        offset = target.transform.position - transform.position;
    }

    void LateUpdate()
    {
        /*// Programski kod s rotacijom
        rotationY += Input.GetAxis("Mouse X") * rotationSpeed * 3;

        Quaternion rotation = Quaternion.Euler(0, rotationY, 0);
        transform.position = target.transform.position - (rotation * offset);
        transform.LookAt(target.transform);*/
        
        // Programski kod bez rotacije
       
        transform.position = target.transform.position - offset;
        transform.LookAt(target.transform);
        
    }

}
