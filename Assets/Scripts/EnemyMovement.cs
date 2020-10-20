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

    // Start is called before the first frame update 
    void Start()
    {
        pathFinder = FindObjectOfType<PathFinder>();
        path = pathFinder.getPath();
        

        StartCoroutine(MovePlayer(path));

    }

    IEnumerator MovePlayer(List<Vector3Int> path)
    {
        transform.position = path[0] * 10 + new Vector3Int(-10, 10, 0);

        foreach (Vector3Int step in path)
        {

            Vector3 currentPosition = transform.position;

           

            Vector3Int startPositionInt = new Vector3Int(Mathf.RoundToInt(currentPosition.x), Mathf.RoundToInt(currentPosition.y), Mathf.RoundToInt(currentPosition.z));

            print(string.Format("I am at: {0}", startPositionInt));

            Vector3Int direction = (step * 10) - startPositionInt;
            direction.y = 0;

            print(string.Format("New direction: {0}", direction));

            Vector3Int nextStep = new Vector3Int(direction.x / 10, 0, direction.z / 10);

            print(string.Format("New divided direction: {0}", nextStep));

            print(string.Format("I should probably go to: {0}",startPositionInt +  new Vector3Int(direction.x/10,direction.y/10,direction.z/10)));


            for (int i = 1; i <= 10; i++)
            {

                Moveto(startPositionInt + (nextStep * i));

                print(string.Format("After {0} stahps, I am at {1}", i, transform.position));

                yield return new WaitForSeconds(stepDelay);
            }



                




        }

        SelfDestruct();

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


    // todo Make less stupid way to increase money
    public void EnemyDied()
    {
        SendMessageUpwards("IncreaseMoney"); // todo Make less stupid way to increase money
    }


} 
