using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // 스폰할 오브젝트
    public GameObject enemyPrefab;
    // 몇 초에 한번씩 스폰할건지
    public float spawnTick = 2.0f;
    // 스폰할 범위
    public float spawnrange = 2.5f;

    private float _elapsedTime; // 몇 초 지났는지 계산


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_elapsedTime > spawnTick) 
        {
            if (enemyPrefab != null)
            {
                Instantiate(enemyPrefab, new Vector3(Random.Range(-spawnrange, spawnrange), transform.position.y, transform.position.z), transform.rotation);
                _elapsedTime = 0;
            }
            else
            {
                Debug.Log("프리팹을 넣으세요!");
            }
        }
        _elapsedTime += Time.deltaTime;
    }
}
