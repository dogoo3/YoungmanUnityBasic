using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class Character : MonoBehaviour
{
    public Transform shootTransform; // 총알 생성 위치
    public GameObject bulletPrefab; // 총알 프리팹
    
    private Rigidbody rigidbody;
    private Vector3 moveValue;
    private bool isJump; // 이렇게 선언하면 기본값이 false
    private float jumpPower;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnJump(InputValue inputvalue)
    {
        if(inputvalue.isPressed)
        {
            Debug.Log("키를 누름");
            jumpPower = 0;
            isJump = true;
        }
        else
        {
            Debug.Log("키를 뗌");
            isJump = false;
            rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    private void OnMove(InputValue inputvalue)
    {
        moveValue = inputvalue.Get<Vector3>();
    }

    private void OnShoot(InputValue inputvalue)
    {
        Instantiate(bulletPrefab, shootTransform.position, Quaternion.identity); // (오브젝트 프리팹, 생성 위치, 생성되는 오브젝트 회전값)
    }

    private void OnShootRay(InputValue inputvalue)
    {
        //Ray ray = new Ray(shootTransform.position, transform.forward); // 광선 그 자체

        //RaycastHit hit; // 맞았을 때 맞은 오브젝트&광선과 관련된 무언가

        //Debug.DrawRay(shootTransform.position, transform.forward * 10.0f, Color.blue, 2.0f);

        //int layermask_test = 1 << LayerMask.NameToLayer("Test"); // Test라는 Layer를 가진 친구만 감지
        //int layermask_water = 1 << LayerMask.NameToLayer("Water"); // Water라는 "

        //if(Physics.Raycast(ray, out hit, 10.0f, layermask_test | layermask_water))
        //{
        //    Debug.Log(hit.collider.name);
        //}

        // 게임화면 정중앙에서 Ray 쏘는 법
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        Debug.Log(new Vector2(Screen.width / 2, Screen.height / 2));

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 20.0f))
        {
            Debug.Log(hit.collider.name);
        }
    }

    private void Update()
    {
        // transform.Translate(moveValue * 10.0f * Time.deltaTime);

        if(isJump)
        {
            //if(jumpPower < 5)
            //    jumpPower += 0.004f;

            jumpPower = Mathf.Clamp(jumpPower + 0.04f, 0, 5.0f); // (계산식, 최소값, 최댓값
            Debug.Log(jumpPower);
        }
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + moveValue * 10.0f * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if(collision.collider.tag == "Wall")
        //{

        //}

        if(collision.collider.CompareTag("Wall"))
        {
            Debug.Log(collision.collider.name);
        }

        if(collision.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            Debug.Log($"layer : {collision.collider.name}");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        // Debug.Log($"충돌중인 오브젝트 : {collision.collider.name}");
    }

    private void OnCollisionExit(Collision collision)
    {
        // Debug.Log($"떨어진 오브젝트 : {collision.collider.name}");
    }

    private void OnTriggerEnter(Collider other)
    {

    }
}
