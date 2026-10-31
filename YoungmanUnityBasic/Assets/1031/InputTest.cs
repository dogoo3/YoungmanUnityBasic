using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void OnCheckObject(InputValue p_value)
    {
        Debug.Log(p_value.isPressed);
    }

    void Update()
    {
    }
}
