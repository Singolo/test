using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public float maxPower = 100.0f, radius = 10.0f;
    private Animator animator;

    
    void Start()
    {
        Invoke("Detonate", 0.5f);
        
    }
        
    void Update ()
    {
		
	}
    
    private void Detonate()
    {
        TurnOnAnimation();
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (var hit in colliders)
        {
            Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.AddForce(CalculateForce(rb.transform.position));
        }
        Destroy(gameObject, 1f);
    }

    private void TurnOnAnimation()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.enabled = true;
    }

    private Vector3 CalculateForce(Vector3 objectPosition)
    {
        Vector3 direction = objectPosition - transform.position;
        Vector3 absDirection = new Vector3(Mathf.Abs(direction.x), Mathf.Abs(direction.y));

        float power = maxPower;


        //Rewrite with direction.normalize
        if ((absDirection.x < radius * 0.33f) && (absDirection.y < radius * 0.33f))
            power = maxPower;
        else if ((absDirection.x < radius * 0.66f) && (absDirection.y < radius * 0.66f))
            power = maxPower * 0.33f / 3.0f;
        else if ((absDirection.x < radius) && (absDirection.y < radius))
            power = maxPower * 0.2f / 6.0f;
        else
            return Vector3.zero;
        
        return direction * power;
    }
}
