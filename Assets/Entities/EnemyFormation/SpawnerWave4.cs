using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerWave4 : MonoBehaviour

{

    public GameObject enemyPrefab;

    public float width;
    public float height;

    public float speed;
    public float spawnDelay;

    private float minXEdge, maxXEdge;
    private float rightEdgeOfFormation;
    private bool movingRight = true;

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
    }

    public void OnDrawGizmos()
    {

        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
    }

    void DetermineNextSpawn()
    {

        if (DifficultyManager.waveFourAllowed == true)
        {
            if (AllEnemiesareDead())
            {

                SpawnUntilFull();
            }
        }


    }




    void EnemyDance()
    {
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
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

