using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainScript : MonoBehaviour
{
    public float speed;

    public float moveTime;

    private bool dirRight = true;

    private float timer;

    void Update()
    {
        if (dirRight)
        {
            // se [dirRight] vai para direita
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            // Se não [dirRight] vai para a esquerda
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        timer += Time.deltaTime;

        if (timer >= moveTime)
        {
            dirRight = !dirRight;
            timer = 0;
        }
    }
}
