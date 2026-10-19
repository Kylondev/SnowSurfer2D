using System.Collections;
using UnityEngine;

public class TimeSlow : MonoBehaviour
{

    [SerializeField] ParticleSystem powerUpParticle;
    SpriteRenderer yarnSpriteRenderer;



    private void Start()
    {
        yarnSpriteRenderer = GetComponentInChildren<SpriteRenderer>();

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && yarnSpriteRenderer.enabled)
        {
            yarnSpriteRenderer.enabled = false;
            powerUpParticle.Play();
                    StartCoroutine(timeSlow());

        }
    }


    IEnumerator timeSlow()
    {
        Time.timeScale = .5f;
        yield return new WaitForSecondsRealtime(3f);
        Time.timeScale = 1f;

    }
    
}
