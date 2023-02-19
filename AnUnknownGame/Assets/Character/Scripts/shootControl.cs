using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootControl : MonoBehaviour
{
    public Camera cam;
    public LayerMask enemy;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
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
