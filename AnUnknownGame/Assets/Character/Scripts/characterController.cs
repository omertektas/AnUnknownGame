using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class characterController : MonoBehaviour
{
    [SerializeField] private float characterSpeed;
    Animator anim;

    void Start()
    {
        anim=this.GetComponent<Animator>();
    }

    void Update()
    {
        move();
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
