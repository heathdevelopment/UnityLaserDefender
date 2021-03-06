using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
    public float health = 150;

    void OnTriggerEnter2D(Collider2D col)
    {
        Projectile missle = col.gameObject.GetComponent<Projectile>();
        if (missle)
        {
            health -= missle.GetDamage();
            missle.Hit();
            if(health <= 0)
            {

                Destroy(gameObject);
            }
            
        }
    }
}
