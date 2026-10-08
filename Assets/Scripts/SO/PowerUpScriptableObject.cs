using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp", menuName = "PowerUps/PowerUp Data")]
public class PowerUpScriptableObject : ScriptableObject
{
    [SerializeField] private string powerUpType;
    [SerializeField] private float timeLimit;
    [SerializeField] private float powerUpValue;

    public string PowerUpType { get => powerUpType; set => powerUpType = value; }
    public float TimeLimit { get => timeLimit; set => timeLimit = value; }
    public float PowerUpValue { get => powerUpValue; set => powerUpValue = value; }
}
