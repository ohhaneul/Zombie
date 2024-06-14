using UnityEngine;

public class ZombieParttest : MonoBehaviour
{
    public enum PartType { Body, Arm, Head }
    public PartType partType;
    public int scoreValue = 1;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManagertest.Instance.CollectPart(this);
            Destroy(gameObject);
        }
    }
}
