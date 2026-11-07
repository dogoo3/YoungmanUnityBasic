using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 이동속도
    // 몇 초 뒤에 사라지는지
    // Rigidbody

    private Rigidbody rigidbody;

    public float speed = 20.0f;
    public float livetime = 5.0f;

    private float _elapsedTime = 0;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // 시간이 지나면 파괴
        if(_elapsedTime > livetime)
        {
            Destroy(gameObject);
        }
        _elapsedTime += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Move(speed);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("AttackObject"))
        {
            Debug.Log("맞았다!");
            Destroy(collision.gameObject); // 총알을 없애준다
            Destroy(gameObject);
        }
    }

    private void Move(float p_speed = 15.0f)
    {
        rigidbody.MovePosition(rigidbody.position + transform.forward * speed * Time.fixedDeltaTime);
    }
}
