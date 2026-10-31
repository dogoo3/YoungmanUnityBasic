using UnityEngine;

public class TankObject : MonoBehaviour
{
    public Rigidbody rigidbody;

    private void Awake()
    {
        Debug.Log("AwakeAwkae");
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        Debug.Log("OnEnableonEnable");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
