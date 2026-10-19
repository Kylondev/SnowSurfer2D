using System.Collections;
using UnityEngine;

public class ScoreMult : MonoBehaviour
{
    [SerializeField] ParticleSystem pwrUpParticle;
    [SerializeField] ScoreManager scoreManager;

    SpriteRenderer pwrUpSpriteRenderer;
    // int mult = 10;

    private void Start()
    {
        pwrUpSpriteRenderer = GetComponentInChildren<SpriteRenderer>();

    }


    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     scoreManager.AddScore(int score * 10 );
    // }

}
