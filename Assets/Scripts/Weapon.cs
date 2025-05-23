using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;
    public int prefabId;
    public float damage;
    public int count;
    public float speed;
    // Update is called once per frame

    private void Start()
    {
        Init();
    }
    void Update()
    {
        
    }

    public void Init()
    {
        switch (id)
        {
            case 0:
                speed = -150;
                Batch();
                break;
            default:
                break;
        }
    }

    void Batch()
    {
        for(int i = 0; i < count;  i++)
        {
            Transform bullet = Gamemanager.instance.pool.Get(prefabId).transform;
            bullet.parent = transform;
            bullet.GetComponent<Bullet>().Init(damage, -1);

        }
    }
}
