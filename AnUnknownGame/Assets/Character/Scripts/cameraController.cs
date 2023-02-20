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

    Vector3 objRot;
    public Transform chBody;
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
        if (mouseY >= 25) mouseY = 25;
        if (mouseY <= -40) mouseY = -40;
        
        
        this.transform.eulerAngles = new Vector3(-mouseY,mouseX,0);
        target.transform.eulerAngles= new Vector3(0, mouseX, 0);

        Vector3 temp = this.transform.eulerAngles;
        temp = this.transform.eulerAngles;
        temp.z = 0;
      
       // temp.y = this.transform.localEulerAngles.y;   karýþma
        temp.x = this.transform.localEulerAngles.x + 10;
        objRot = temp;
        chBody.transform.eulerAngles = objRot;

    }
}
