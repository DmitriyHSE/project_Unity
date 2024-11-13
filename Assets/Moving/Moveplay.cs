using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveplay : MonoBehaviour
{
    public float speed;
    private Vector3 input;
    public SpriteRenderer sprite;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), 0);
        transform.position += input * speed * Time.deltaTime;

        if (input.x != 0)
        {
            if (input.x > 0)
            {
                sprite.flipX = false;
            }
            else
            {
                sprite.flipX = true;
            }
        }
    }
}
