using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]


public class EnemyMove : MonoBehaviour
{
    //[SerializeField] private PlayerController playerController;
    private NavMeshAgent _agent;
    private EnemyMove _status;
    public Animator anim;

    //// Start is called before the first frame update
    void Start() {
        _agent = GetComponent<NavMeshAgent>();  //NavMeshを保持しておく
        anim = gameObject.GetComponent<Animator>();
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    _agent.destination = playerController.transform.position;   //クエリちゃんを目指して進む（目標地点を設定する）
    //}

    public void OnDetectiveObject(Collider collider) {


        if (collider.CompareTag("Player")) {
                anim.SetBool("idou1", true);
                _agent.destination = collider.transform.position;
                //_agent.isStopped = true;
            
        }
        else
        {
            anim.SetFloat("idou", 0.0f);
        }
    }
}
