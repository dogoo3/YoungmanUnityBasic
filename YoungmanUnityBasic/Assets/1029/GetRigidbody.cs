using UnityEngine;

public class GetRigidbody : MonoBehaviour
{
    public TankObject _tankobject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (_tankobject.rigidbody != null)
            Debug.Log(_tankobject.rigidbody.useGravity);
        else
            Debug.Log("탱크는 Null임");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
