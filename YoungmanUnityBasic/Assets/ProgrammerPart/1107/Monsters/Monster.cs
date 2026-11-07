using UnityEngine;

public class Monster : MonoBehaviour 
{
    public float hp;
    public float movespeed;

    public virtual void Attack()
    {
        Debug.Log("공격했음");
    }
}
