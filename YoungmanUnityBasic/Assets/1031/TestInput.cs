using UnityEngine;

public class TestInput : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // 0 : 마우스 왼쪽
        // 1 : 마우스 오른쪽
        // 2 : 마우스 휠
        if(Input.GetMouseButtonDown(0)) // 마우스 왼쪽
        {
            Debug.Log("마우스 왼쪽 클릭!");
        }
        
        if(Input.GetMouseButton(0)) // 마우스를 누르는 중
        {
            Debug.Log("마우스 왼쪽 누르는 중!");
        }

        if(Input.GetMouseButtonUp(0)) // 마우스를 눌렀다 뗄 때
        {
            Debug.Log("마우스 왼쪽 뗌!");
        }

        if(Input.GetKeyDown(KeyCode.H)) // 키 눌렀을 때
        {
            Debug.Log("H키 눌렀음");
        }

        // 부드러운 멈춤을 구현할 때 
        // Horizontal(방향키 양옆, AD), Vertical(방향키 위아래, WS)
        // GetAxisRaw로 0 아니면 1도 구현 가능
        if(!Mathf.Approximately(Input.GetAxis("Horizontal"), 0))
        {
            Debug.Log(Input.GetAxis("Horizontal"));
        }
    }
}
