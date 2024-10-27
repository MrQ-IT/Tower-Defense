using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{

	public int level = 1;
	public int baseDamage = 50;
	public float duration = 2f;

    private int damage;
	// Start is called before the first frame update
	void Start()
    {
		damage = baseDamage * level;
		Destroy(gameObject, duration);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Enemy")){
			other.GetComponent<Bee>().TakeDamage(damage);
		}
	}
}
