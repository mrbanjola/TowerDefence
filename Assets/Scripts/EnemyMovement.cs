using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyMovement : MonoBehaviour
{

    [SerializeField] ParticleSystem endParticles;
    [SerializeField] EnemySpawner enemySpawner;

    PathFinder pathFinder;
    List<Vector3Int> path;
    float stepDelay = .02f;


    [SerializeField] ParticleSystem moveParticles;


    void Start()
    {
        pathFinder = FindObjectOfType<PathFinder>();
        path = pathFinder.getPath();
        

        StartCoroutine(MovePlayer(path));

    }

    IEnumerator MovePlayer(List<Vector3Int> path)
    {
        transform.position = path[0] * 10;

        foreach (Vector3Int step in path)
        {

            Vector3 currentPosition = transform.position;

            Vector3Int startPositionInt, nextStep;
            DivideMovement(step, currentPosition, out startPositionInt, out nextStep);

            for (int i = 1; i <= 10; i++)
            {

                Moveto(startPositionInt + (nextStep * i));

               

                yield return new WaitForSeconds(stepDelay);
            }








        }

        SelfDestruct();

    }

    private static void DivideMovement(Vector3Int step, Vector3 currentPosition, out Vector3Int startPositionInt, out Vector3Int nextStep)
    {
        startPositionInt = new Vector3Int(Mathf.RoundToInt(currentPosition.x), Mathf.RoundToInt(currentPosition.y), Mathf.RoundToInt(currentPosition.z));
       
        Vector3Int direction = (step * 10) - startPositionInt;
        direction.y = 0;

        
        nextStep = new Vector3Int(direction.x / 10, 0, direction.z / 10);
        
    }


    private void Moveto(Vector3Int step)
    {
        gameObject.transform.position = step;

        moveParticles.Play();
    }

    private void SelfDestruct()
    {
        Instantiate(endParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
       
    }




} 
