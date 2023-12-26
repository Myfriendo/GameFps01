using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    public NavMeshAgent Agent { get => agent; }
    [SerializeField] private string currentState;
    public Path path;
    private GameObject player;
    public float sightDistance = 20f;
    public float fov = 85f;
    [SerializeField] public float eyeHeight;
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        stateMachine.Initialize();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        CanSeePlayer();
        currentState = stateMachine.activeState.ToString();
        Debug.Log(currentState);
    }

    public bool CanSeePlayer()
    {
        if (player!=null)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < sightDistance)
            {
                Vector3 targetDir = player.transform.position - transform.position - (Vector3.up * eyeHeight);
                float angleToPlayer = (Vector3.Angle(targetDir, transform.forward));
                if (angleToPlayer >= -fov && angleToPlayer <= fov)
                {
                    Ray ray = new Ray(transform.position+(Vector3.up*eyeHeight), targetDir);
                    RaycastHit hitInfo = new RaycastHit();

                    if (Physics.Raycast(ray, out hitInfo, sightDistance))
                    {
                        if (hitInfo.transform.gameObject==player)
                        {   
                            return true;
                        }
                    }
                    Debug.DrawRay(ray.origin, ray.direction * sightDistance);

                }
            }
        }
        return false;
    }

}
