using UnityEngine;
using UnityEngine.UI;

public class Mover : MonoBehaviour
{
    public float radius = 10f;
    public Button moveButton;

    void Start()
    {
        if (moveButton != null)
        {
            moveButton.onClick.AddListener(MoveToRandomPosition);
        }
    }

    void MoveToRandomPosition()
    {
        Vector3 randomOffset = new Vector3(Random.Range(-radius, radius), 0, Random.Range(-radius, radius));
        transform.position += randomOffset;
    }
}