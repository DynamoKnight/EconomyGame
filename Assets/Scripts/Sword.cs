using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Sword : MonoBehaviour
{
    private SpriteRenderer sr;
    public int damage = 25;
    private Quaternion originalRotation;
    
    private List<Enemy> enemiesInRange = new List<Enemy>();

    void Start(){
        sr = GetComponent<SpriteRenderer>();
        originalRotation = transform.localRotation;
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
            StartCoroutine(Rotate());
        }
    }

    void Attack()
    {
        foreach (Enemy enemy in new List<Enemy>(enemiesInRange))
        {
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }

    IEnumerator Rotate(){
        transform.localRotation = originalRotation * Quaternion.Euler(0, 0, -30f);
        yield return new WaitForSeconds(0.1f);
        transform.localRotation = originalRotation;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null && !enemiesInRange.Contains(enemy))
            {
                enemiesInRange.Add(enemy);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemiesInRange.Remove(enemy);
            }
        }
    }

    public void SetSword(SwordData swordData){
        this.damage = swordData.damage;
        sr.color = swordData.color;
    }
}