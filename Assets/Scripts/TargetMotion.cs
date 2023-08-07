using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMotion : MonoBehaviour
{
    [SerializeField] float _bounceBoard;
    Vector2 _dir = Vector2.up;
    private void Start()
    {
        if (transform.position.y > 0)
        {
            _dir = Vector2.down;
        }
    }
    void ChangeDir()
    {
        _dir = new Vector2(Random.Range(-0.6f, 0.6f),-_dir.y);
    }

    private void Update()
    {
        if (GameManager.Single.GameActive)
        {
            transform.Translate(GameManager.Single.Speed * Time.deltaTime * _dir);
        }

        if (_dir.y > 0 && transform.position.y > _bounceBoard ||
            _dir.y < 0 && transform.position.y < -_bounceBoard)
        {
            ChangeDir();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border"))
        {
            _dir = new Vector2(-_dir.x, _dir.y);
        }
    }
}
