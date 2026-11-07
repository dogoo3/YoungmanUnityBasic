using UnityEngine;

public class Stump : Monster
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
        Debug.Log("스텀프가 죽었어요!");
    }
}
