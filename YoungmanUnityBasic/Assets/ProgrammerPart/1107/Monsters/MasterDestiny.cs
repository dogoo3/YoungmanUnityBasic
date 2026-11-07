using UnityEngine;

public class MasterDestiny : Monster, ITest
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnDestroy()
    {
        Debug.Log("루디브리엄의 마스터 데스티니가 죽었어요!");
    }

    public void Jump()
    {
        Debug.Log("인터페이스로 구현한 데스티니 점프");
        Destroy(gameObject);
    }
}
