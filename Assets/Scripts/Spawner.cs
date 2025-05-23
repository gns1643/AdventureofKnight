using JetBrains.Annotations;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform player; // �ν����Ϳ��� Player ������Ʈ ����
    public Transform[] spawnpoint;

    float timer;

    private void Awake()
    {
        spawnpoint = GetComponentsInChildren<Transform>();
    }
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 0.2f)
        {
            timer = 0;
            GameObject enemy = Gamemanager.instance.pool.Get(0);
            enemy.transform.position = spawnpoint[Random.Range(1, spawnpoint.Length)].position;
            Enemy_Movement em = enemy.GetComponent<Enemy_Movement>();
        }
    }
    
}
