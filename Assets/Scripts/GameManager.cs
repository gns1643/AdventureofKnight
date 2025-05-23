using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    public PlayerMovement player;
    public PoolManager pool;

    private void Awake()
    {
        instance = this;
    }
}
