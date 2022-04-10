using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnRateSeconds;
    [SerializeField] private GameObject[] objects;
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
        var spawnObject = Instantiate(obj, transform.position, Quaternion.identity);
    }
}
