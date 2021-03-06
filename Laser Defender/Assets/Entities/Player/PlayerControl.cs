using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {


   
    public float speed = 1.0f;
    public float padding = 1f;
    public GameObject ammoRound;

    public float projectileSpeed;
    public float firingRate = 0.2f;

    float xmin = -5;
    float xmax = 5;

	void Start () {
       float distance = transform.position.z - Camera.main.transform.position.z;
       Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
       Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));

        xmin = leftmost.x + padding; 
        xmax = rightmost.x - padding;
    }

    void Fire()
    {
        GameObject beam = Instantiate(ammoRound, transform.position, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0.00001f, firingRate);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");

        }
        //restrict our space within the game space
        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);

        transform.position = new Vector3(newX,transform.position.y, transform.position.z);
	
	}
}
