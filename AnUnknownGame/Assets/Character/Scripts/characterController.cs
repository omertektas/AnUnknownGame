using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public static characterController Instance;
    [SerializeField] private float characterSpeed;
    Animator anim;
    public bool shootControl=false;

    void Start()
    {
        Instance = this;
        anim=this.GetComponent<Animator>();
    }

    void Update()
    {

        move();

        if (Input.GetKeyDown("x"))
        {
            if (shootControl==false)
            {
                anim.SetBool("shoot", true);
                shootControl=true;

            }
            else
            {
                anim.SetBool("shoot", false);
                shootControl=false;
                

            }
        }
        
    }

    void move()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        anim.SetFloat("Horizontal",hor);
        anim.SetFloat("Vertical",ver);
        this.gameObject.transform.Translate(hor * characterSpeed*Time.deltaTime, 0, ver * characterSpeed*Time.deltaTime);
    }
}
