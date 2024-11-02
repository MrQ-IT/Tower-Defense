using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
	private int explosionDamage = 150;
	private float explosionRadius = 2f;
	private float explosionDelay = 2f;
	public GameObject explosionEffect;

	private void Start()
	{
		Invoke("Explode", explosionDelay);
	}

	public void Explode()
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
