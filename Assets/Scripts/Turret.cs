using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Vector3 sizeTurret;
    // Start is called before the first frame update
    void Start()
    {
        sizeTurret = GetComponent<BoxCollider2D>().size;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
