using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public TeamData team;

    SpriteRenderer sr;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Destroy(gameObject, 5);
    }
    private void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * 10);
        if (team != null)
        {
            sr.color = team.teamColor;
        }

    }
}
