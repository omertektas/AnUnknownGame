using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootControl : MonoBehaviour
{
    public Camera cam;
    public LayerMask enemy;
    public GameObject aim;
    Animator anim;
    private bool shootCntrl = false;

    void Start()
    {
        aim.SetActive(false);
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(1) )
        {
            if (shootCntrl==false)
            {
                aim.SetActive(true);
                shootCntrl = true;
            }
            else if (shootCntrl==true)
            {
                aim.SetActive(false);
                shootCntrl = false; 

            }

        }
        if (Input.GetMouseButtonDown(0) && aim.activeInHierarchy)
            {
               
                anim.SetBool("shoot", true);
                shoot();
            }
        
        
        
    }

    public void shoot()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, enemy))
        {
            hit.collider.gameObject.GetComponent<enemyScript>().takeDamage();
        }
    }

    
}
