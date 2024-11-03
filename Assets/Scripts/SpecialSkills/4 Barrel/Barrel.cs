using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{

	public int explosionDamage = 100;
	public float explosionRadius = 2f;
	public float explosionDelay = 2f;
	public GameObject explosionEffect;

	private void Start()
	{
		Invoke("Explode", explosionDelay);
	}

	void Explode()
	{
		if(explosionEffect != null)
		{
			Instantiate(explosionEffect, transform.position, Quaternion.identity);

		}

		Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
		foreach(Collider2D hit in hits)
		{
			if (hit.CompareTag("Enemy"))
			{
				hit.GetComponent<Bee>().TakeDamage(explosionDamage);
			}
		}

		Destroy(gameObject);

	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, explosionRadius);
	}
}
