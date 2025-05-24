using UnityEngine;

public class Scanner : MonoBehaviour
{
    public float scanRange;
    public LayerMask targetLayer;
    public RaycastHit2D[] targets;
    public Transform nearestTarget;

    private void FixedUpdate()
    {
        targets = Physics2D.CircleCastAll( //��Ž��
            transform.position, // ĳ���� ������ġ = �ڽ���ġ
            scanRange,// ���� ������
            Vector2.zero, //���⼺ ����
            0, // ��� ������ ����
            targetLayer); //���� ���̾��ũ
        nearestTarget = GetNearest();
    }

    Transform GetNearest()
    {
        Transform result = null;
        float diff = 100; //�Ÿ�

        foreach(RaycastHit2D target in targets)
        {
            Vector3 myPos = transform.position;
            Vector2 targetPos = target.transform.position;
            float curDiff = Vector3.Distance(myPos, targetPos); //�� ������ �Ÿ��� ���ϴ� �Լ�
            if (curDiff < diff){
                diff = curDiff;
                result = target.transform; //���� ����� target�� ��ġ��ȯ
            }
        }
;        return result;
    }
}
