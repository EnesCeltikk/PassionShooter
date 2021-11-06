using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeDruation = 1f;
    private float lifeTimer;
    public GameObject explosionFx;
    public static bool isExplosive = false;

    void Start()
    {
        lifeTimer = lifeDruation;
    }
    void Update()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isExplosive && collision.gameObject.layer != 8 && this.tag == "PlayerBullet" && explosionFx != null && collision.gameObject.tag != "PlayerBullet")//8=Player
        {
            Destroy(Instantiate(explosionFx, transform.position, transform.rotation), 2f);
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject?.GetComponent<EnemyAi>().TakeDamage(40);
        }
    }

}
