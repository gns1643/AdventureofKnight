using UnityEngine;

public class Scanner : MonoBehaviour
{
    public float scanRange;
    public LayerMask targetLayer;
    public RaycastHit2D[] targets;
    public Transform nearestTarget;

    private void FixedUpdate()
    {
        targets = Physics2D.CircleCastAll( //원탐색
            transform.position, // 캐스팅 시작위치 = 자신위치
            scanRange,// 원의 반지름
            Vector2.zero, //방향성 없음
            0, // 쏘는 방향의 길이
            targetLayer); //적용 레이어마스크
        nearestTarget = GetNearest();
    }

    Transform GetNearest()
    {
        Transform result = null;
        float diff = 100; //거리

        foreach(RaycastHit2D target in targets)
        {
            Vector3 myPos = transform.position;
            Vector2 targetPos = target.transform.position;
            float curDiff = Vector3.Distance(myPos, targetPos); //두 벡터의 거리를 구하는 함수
            if (curDiff < diff){
                diff = curDiff;
                result = target.transform; //가장 가까운 target의 위치반환
            }
        }
;        return result;
    }
}
