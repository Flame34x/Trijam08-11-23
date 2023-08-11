using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public TeamData team;

    public GameObject bullet;
    public float attackSpeed;
    public float attackDamage;
    public float lastShot;

    SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    public void Update()
    {
        if (Time.time - lastShot > attackSpeed)
        {
            Shoot();
            lastShot = Time.time;
        }
        sr.color = team.teamColor;

    }

    public void Shoot()
    {
        GameObject _bullet = Instantiate(bullet, transform.position, Quaternion.identity);
        _bullet.GetComponent<Bullet>().team = team;
    }
}
