using UnityEngine;

public class FinishLine : MonoBehaviour
{
void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has reached the finish line!");
            //TODO: miau
        }
    }
}
