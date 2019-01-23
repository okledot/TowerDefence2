using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    private float damage;

    public float speed = 70f;

    public GameObject impactEffect;

    public void Seek(Transform _target, float _damage)
    {
        target = _target;
        damage = _damage;
    }

	void Update ()
    {
		if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

	}

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        Destroy(gameObject);

        Enemy enemy = target.GetComponent<Enemy>();
        if (enemy != null)
            enemy.TakeDamage(damage);
        

        //Destroy(target.gameObject);
        
    }
}
