using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyPrefab01;
    public GameObject enemyPrefab02;

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
    CalculatePlaySpace();

}




// Update is called once per frame
void Update()

{
    EnemyDance();

    if (AllEnemiesareDead() && TutorialText.challengescompleted == 3)
        {
            Debug.Log("Alien is dead");
            TutorialSpawnEnemy02();
        }
    
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



public void TutorialSpawnEnemy01()
    {
             
            
                Transform freePosition = NextFreePosition();
                if (freePosition)
                {
            Debug.Log("Spawn 01");
            GameObject enemy = Instantiate(enemyPrefab01, freePosition.position, Quaternion.identity) as GameObject;
                    enemy.transform.parent = freePosition;
                }
                if (NextFreePosition())
                {
                    Invoke("TutorialSpawnEnemy01", spawnDelay);
                }
         


    }

    public void TutorialSpawnEnemy02()
    {
        Debug.Log("Step 1 TutorialSpawnEnemy02 wordt gestart ");
        Transform freePosition = NextFreePosition();
       
       if (freePosition)
        {
            Debug.Log("Step 4 TutorialSpawnEnemy02 inside if ");
            GameObject enemy = Instantiate(enemyPrefab02, freePosition.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = freePosition;
        }
        if (NextFreePosition())
        {
            Invoke("TutorialSpawnEnemy02", spawnDelay);
       }

     

    }

Transform NextFreePosition()
{
        Debug.Log("Step 2 Nextfreeposition ");
        foreach (Transform childPositionGameObject in transform)
    {
            Debug.Log("Step 3 Nextfreeposition inside foreach ");
            Debug.Log("Step 3 What is childCount? "  + childPositionGameObject.childCount);
            if (childPositionGameObject.childCount == 0)
        {
                Debug.Log("Step 4 Nextfreeposition childCount is blijkbaar 0 ");
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
