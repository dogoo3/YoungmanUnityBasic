using UnityEngine;

public class WaterReflection : MonoBehaviour
{
    [Header("메인 카메라 연결")]
    public Camera mainCamera;

    private Camera reflectionCamera;
    private RenderTexture reflectionTexture;
    private Material waterMaterial;

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        // 1. 거울 카메라(서브 카메라) 동적 생성
        GameObject camObj = new GameObject("ReflectionCamera");
        reflectionCamera = camObj.AddComponent<Camera>();
        reflectionCamera.enabled = false; // LateUpdate에서 수동으로 찍을 것이므로 꺼둡니다.
        reflectionCamera.transform.SetParent(transform); // 물 오브젝트 하위에 정리

        // 메인 카메라의 설정(배경색, 컬링 마스크 등)을 그대로 복사
        reflectionCamera.CopyFrom(mainCamera);

        // 2. 화면 해상도와 동일한 크기의 RenderTexture 생성 및 할당
        reflectionTexture = new RenderTexture(Screen.width, Screen.height, 24);
        reflectionCamera.targetTexture = reflectionTexture;

        // 3. 물 오브젝트의 머티리얼 가져오기
        waterMaterial = GetComponent<Renderer>().sharedMaterial;
    }

    void LateUpdate()
    {
        if (mainCamera == null || waterMaterial == null) return;

        // 4. 위치 대칭 계산 (호수 수면 Y축을 기준으로 메인 카메라 위치 반전)
        Vector3 camPos = mainCamera.transform.position;
        Vector3 waterPos = transform.position;

        camPos.y = waterPos.y - (camPos.y - waterPos.y);
        reflectionCamera.transform.position = camPos;

        // 5. 회전 대칭 계산 (X축 회전(고개 숙임/들음) 반전)
        Vector3 camEuler = mainCamera.transform.eulerAngles;
        reflectionCamera.transform.eulerAngles = new Vector3(-camEuler.x, camEuler.y, camEuler.z);

        // 6. 거울 카메라 촬영 및 쉐이더로 텍스처 전송
        reflectionCamera.Render();

        // 주의: Shader Graph의 ReflectionTex 프로퍼티 Reference 이름과 정확히 일치해야 합니다.
        waterMaterial.SetTexture("_ReflectionTex", reflectionTexture);
    }

    void OnDestroy()
    {
        // 씬 전환이나 오브젝트 삭제 시 RenderTexture 메모리 누수 방지
        if (reflectionTexture != null)
        {
            reflectionTexture.Release();
            Destroy(reflectionTexture);
        }
    }
}