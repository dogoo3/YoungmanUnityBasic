using UnityEngine;

interface ITest
{
    void Jump();
}

public class Slime : Monster, ITest
{
    public bool isJump;
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
        Debug.Log("슬라임이 죽었어요!");
    }

    public override void Attack()
    {
        Debug.Log("내 슬라임이 공격했어요!");
    }

    public void Jump()
    {
        Debug.Log("인터페이스로 구현한 슬라임 점프");
    }
}
