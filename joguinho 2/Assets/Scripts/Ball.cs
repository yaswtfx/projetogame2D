using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 direcao;
    public int velocidade = 10;

    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out rb);
        direcao = Random.insideUnitCircle;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bloco"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Chao"))
        {
            GameManager.instance.GameOver();
            Destroy(this.gameObject);
        }

        direcao = Vector2.Reflect(direcao, collision.contacts[0].normal);
    }

    // Update is called once per frame
    void FixedUpdate() //valor fixo independente da maquina
    {
        rb.velocity = direcao.normalized * velocidade;
    }
}
