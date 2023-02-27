using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;

public class characterController : MonoBehaviour
{
    public static characterController Instance;
    [SerializeField] private float characterSpeed;
    [SerializeField] private GameObject car;
    [SerializeField] private GameObject carCamera; 
    [SerializeField] private GameObject fText;
    Animator anim;
    public static bool carActive=false;

    void Start()
    {
        Instance = this;
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        move();
        getInThecar();
       
        
    }

    void move()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        anim.SetFloat("Horizontal",hor);
        anim.SetFloat("Vertical",ver);
        this.gameObject.transform.Translate(hor * characterSpeed*Time.deltaTime, 0, ver * characterSpeed*Time.deltaTime);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="damage")
        {
            Debug.Log("Hasar");
        }
    }

    private void getInThecar()
    {      
        if (Vector3.Distance(this.transform.position, car.transform.position)<=4)
        {
            fText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                carCamera.SetActive(true);               
                Debug.Log("Arabaya binildi");
                carActive = true;
            }
        }
        else
        {
            fText.SetActive(false);
            carActive = false;
        }
    }
}
