using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnRateSeconds = 1f;
    [SerializeField] private GameObject[] objects;
    [SerializeField] private float maxOffsetX = 0f;

    private float leftEdge;



    void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRateSeconds, spawnRateSeconds);
    }

    void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        var obj = objects[Random.Range(0, objects.Length)];

        var position = transform.position + Vector3.left * Random.Range(0f, maxOffsetX);
        var spawnObject = Instantiate(obj, position, Quaternion.identity);
    }
}
