using UnityEngine;



public class Ground_Reposition : MonoBehaviour
{
    Collider2D coll;

    private void Awake()
    {
        coll = GetComponent<Collider2D>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;

        Vector3 playerpos = Gamemanager.instance.player.transform.position;
        Vector3 mypos = transform.position;
        Vector3 playerDir = Gamemanager.instance.player.moveVec;
        
        switch (transform.tag) {
            case "Ground":
                float diffX = playerpos.x - mypos.x;
                float diffY = playerpos.y - mypos.y;
                float dirX = diffX < 0 ? -1 : 1;
                float dirY = diffY < 0 ? -1 : 1;
                diffX = Mathf.Abs(diffX);
                diffY = Mathf.Abs(diffY);

                if (Mathf.Abs(diffX - diffY) <= 0.1f)
                {
                    transform.Translate(Vector3.up * dirY * 64, Space.World);
                    transform.Translate(Vector3.right * dirX * 64, Space.World);
                }
                else if (diffX > diffY)
                {
                    transform.Translate(Vector3.right * dirX * 64, Space.World);
                }
                else if (diffX < diffY)
                {
                    transform.Translate(Vector3.up * dirY * 64, Space.World);
                }

                break;
            case "Enemy":
                if (coll.enabled)
                {
                    transform.Translate(playerDir * 32 + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0f));

                }
                break;
        }

    }
        
}




