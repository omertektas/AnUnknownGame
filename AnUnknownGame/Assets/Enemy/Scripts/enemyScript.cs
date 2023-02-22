using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyScript : MonoBehaviour
{
    [SerializeField] private float health=100;
    Animator anim;
    GameObject targetCharacter;
    
    public float targetFollowDistance;
    public float targetAttackDistance;
    NavMeshAgent enemyNavMesh;
    void Start()
    {
        anim = GetComponent<Animator>();
        targetCharacter = GameObject.Find("Tokyo");
        enemyNavMesh=this.GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        if (health<=0)
        {
            anim.SetBool("dead",true);
            StartCoroutine(deadFunc()); 
        }
        else
        {
            float targetDistance = Vector3.Distance(this.transform.position, targetCharacter.transform.position);
            if (targetDistance<= targetFollowDistance)
            {
                enemyNavMesh.isStopped=false;   
                enemyNavMesh.SetDestination(targetCharacter.transform.position);

            }
            if (targetDistance<= targetAttackDistance)
            {
                enemyNavMesh.isStopped=true;
            }
            else
            {
                //idle
            }
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
