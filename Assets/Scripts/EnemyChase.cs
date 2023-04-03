using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float speed;
    public float checkRadius;
    public float attackRadius;

    public bool shouldRotate;

    public LayerMask whatIsPlayer;

    private Transform target;
    private Rigidbody2D rb;
    private Vector2 movement;
    public Vector3 dir;
    private Animator anim;

    private bool isInChaseRange;
    private bool isInAttackRange;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    private void Update()
    {
        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
        isInAttackRange= Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);

        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;
        if(shouldRotate){
            anim.SetFloat("X", dir.x);
            anim.SetFloat("Y", dir.y);
        }
    }
    private void FixedUpdate(){
        if(isInChaseRange && !isInAttackRange){
            MoveCharacter(movement);
        }
        if(isInAttackRange){
            rb.velocity = Vector2.zero;
        }
    }
    private void MoveCharacter(Vector2 dir){
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            other.gameObject.GetComponent<PlayerLife>().ReceberDanoArmadilha();
        }
    }
}
