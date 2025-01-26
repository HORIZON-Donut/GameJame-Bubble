using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    [SerializeField] float randomDistance = 50;
    float distance;
    void Start()
    {
        distance = Random.Range(10, randomDistance);


    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(enemy.transform.position, Camera.main.transform.position) < distance)
        {
            enemy.SetDestination(Camera.main.transform.position);
        } else
        {
            enemy.isStopped = true;
            enemy.ResetPath();
        }   
    }
}
