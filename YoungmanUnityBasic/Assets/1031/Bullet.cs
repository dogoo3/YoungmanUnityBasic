using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rigidbody;

    private float livetime;
    private float elapsedtime; // 살아있는 시간을 누적해서 합산하는 변수

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        livetime = Random.Range(3, 5);
    }

    private void Update()
    {
        elapsedtime += Time.deltaTime;
        if(elapsedtime > livetime)
        {
            // Destroy(gameObject); // Hierarchy에서 없애버림
            gameObject.SetActive(false); // 오브젝트를 On/Off하는 형태. 
        }
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + Vector3.forward * 10.0f * Time.fixedDeltaTime);
    }
}
