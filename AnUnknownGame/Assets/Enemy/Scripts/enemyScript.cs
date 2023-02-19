using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    [SerializeField] private float health=100;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    
    void Update()
    {
        if (health<=0)
        {
            anim.SetBool("dead",true);
            StartCoroutine(deadFunc()); 
        }
    }

    public void takeDamage()
    {
        health -= Random.Range(15,30);
    }

    private IEnumerator deadFunc()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}
