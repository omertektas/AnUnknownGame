using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 targetDistance;
    [SerializeField]
    private float mouseSensivitiy;
    float mouseX,mouseY;    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position,target.position+targetDistance,Time.deltaTime*10);
        mouseX += Input.GetAxis("Mouse X") * mouseSensivitiy;
        mouseY += Input.GetAxis("Mouse Y") * mouseSensivitiy;
        this.transform.eulerAngles = new Vector3(-mouseY,mouseX,0);
        target.transform.eulerAngles= new Vector3(0, mouseX, 0);

    }
}
