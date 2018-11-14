using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerWave5 : MonoBehaviour

{

    public GameObject enemyPrefab;

    public float width;
    public float height;

    public float horizontalspeed;
    public float verticalspeed;
    public float spawnDelay;

    private float minXEdge, maxXEdge;
    private float minYEdge, maxYEdge;
    private float rightEdgeOfFormation;
    private float lowerEdgeOfFormation;
    private bool movingRight = true;
    private bool movingDown = true;

    // Use this for initialization
    void Start()
    {
        // Debug.Log("TutorialSetting is false");

        CalculatePlaySpace();



    }




    // Update is called once per frame
    void Update()

    {
        EnemyDance();
        DetermineNextSpawn();
    }

    public void CalculatePlaySpace()
    {
        // Calculate size of the playspace for our ship
        float distance2 = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftEdge2 = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance2));
        Vector3 rightEdge2 = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance2));
        minXEdge = leftEdge2.x;
        maxXEdge = rightEdge2.x;
        Vector3 topEdge2 = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distance2));
        Vector3 bottomEdge2 = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance2));
        minYEdge = bottomEdge2.y;
        maxYEdge = topEdge2.y;
      //  Debug.Log("Lower limit   " + minYEdge);
     //   Debug.Log("Top limit   " + maxYEdge);
    }

    public void OnDrawGizmos()
    {

        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
    }

    void DetermineNextSpawn()
    {

        if (DifficultyManager.waveFiveAllowed == true)
        {
            if (AllEnemiesareDead())
            {

                SpawnUntilFull();
            }
        }



    }




    void EnemyDance()
    {
        // horizontal dance
        if (movingRight)
        {
            transform.position += Vector3.right * horizontalspeed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * horizontalspeed * Time.deltaTime;
        }

        float rightEdgeOfFormation = transform.position.x + (0.5f * width);
        if (rightEdgeOfFormation > maxXEdge)
        {
            movingRight = false;
        }

        float leftEdgeOfFormation = transform.position.x - (0.5f * width);
        if (leftEdgeOfFormation < minXEdge)
        {
            movingRight = true;
        }



        // vertical dance
        if (movingDown)
        {
            transform.position += Vector3.down * verticalspeed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.up * verticalspeed * Time.deltaTime;
        }

        float lowerEdgeOfFormation = transform.position.y - (0.5f * height);
        if (lowerEdgeOfFormation < minYEdge)
        {
            movingDown = false;
        }

        float topEdgeOfFormation = transform.position.y + (0.5f * height);
        if (topEdgeOfFormation > maxYEdge)
        {
            movingDown = true;
        }
    }


    void SpawnUntilFull()
    {

        Transform freePosition = NextFreePosition();
        if (freePosition)
        {
            GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = freePosition;
        }
        if (NextFreePosition())
        {
            Invoke("SpawnUntilFull", spawnDelay);
        }


    }



    Transform NextFreePosition()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount == 0)
            {
                return childPositionGameObject;
            }

        }
        return null;
    }

    bool AllEnemiesareDead()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount > 0)
            {
                return false;
            }

        }
        return true;
    }





}

