using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float bombTime = 3.0f;

    // [Range] 어트리뷰트를 사용하면 Inspector에 슬라이더가 생성됩니다. (최소/최대값은 원하는 대로 조절하세요)
    [Range(0f, 15f)]
    public float bombrange = 3.0f;

    private bool isBomb;
    private float _elapsedTime;

    void Start()
    {
    }

    void Update()
    {
        if (_elapsedTime > bombTime && !isBomb)
        {
            Collider[] t_hitColliders = Physics.OverlapSphere(transform.position, bombrange);

            foreach (Collider hit in t_hitColliders)
            {
                // Monster targetMonster = hit.GetComponent<Monster>();

                //// 몬스터 스크립트가 있는 오브젝트만 파괴하도록 null 체크 추가
                //if (targetMonster != null)
                //{
                //    Destroy(targetMonster.gameObject);
                //}

                ITest obj = hit.GetComponent<ITest>();

                obj.Jump();
            }
            isBomb = true;
        }
        _elapsedTime += Time.deltaTime;
    }

    // 오브젝트를 선택했을 때 씬 뷰(Scene View)에 기즈모를 그려주는 메서드
    private void OnDrawGizmosSelected()
    {
        // 기즈모의 색상을 빨간색으로 설정
        Gizmos.color = Color.red;

        // 현재 오브젝트의 위치에 bombrange(반지름)만큼의 와이어 스피어(선으로 된 구)를 그립니다.
        Gizmos.DrawWireSphere(transform.position, bombrange);
    }
}