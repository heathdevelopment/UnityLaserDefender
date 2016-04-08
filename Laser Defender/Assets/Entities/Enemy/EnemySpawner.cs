using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemyPrefab;

    public float width = 10f;
    public float height = 5f;
    // Use this for initialization
    private bool movingRight = true;
    public float speed = 5f;

    private float xmin;
    private float xmax;



    void Start () {
        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));
        xmax = rightEdge.x;
        xmin = leftBoundary.x;

        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
	}

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position,new Vector3(width, height, 0));
    }

    // Update is called once per frame
    void Update(){
        if(movingRight){
            transform.position += Vector3.right * speed * Time.deltaTime;
        }else{
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        float rightEdgeOfFormation = transform.position.x + (0.5f * width);
        float leftEdgeOfFormation = transform.position.x - (0.5f * width);

        if (leftEdgeOfFormation < xmin)
        {
            movingRight = true;
        }else if(rightEdgeOfFormation > xmax)
        {
            movingRight = false;
        }
    }
}
