using UnityEngine;

public struct TestStructrue
{
    public int level;
    public float experiencePoint;
}


public class MyClass
{
    public int level;
    public float experiencePoint;

    public void SetVariable(int p_level, float p_expPoint)
    {
        level = p_level;
        experiencePoint = p_expPoint;
    }

    public MyClass DeepCopy()
    {
        MyClass pasteClass = new MyClass();
        pasteClass.level = this.level;
        pasteClass.experiencePoint = this.experiencePoint;
        return pasteClass;
    }
}

public class ClassTest : MonoBehaviour
{
    private void Awake()
    {
        TestStructrue s1 = new TestStructrue();
        s1.level = 3;
        s1.experiencePoint = 100;
        TestStructrue s2 = s1;

        MyClass c1 = new MyClass();
        c1.SetVariable(5, 200);
        MyClass c2 = c1;
        
        Debug.Log($"S1 : {s1.level}, {s1.experiencePoint}");
        s1.level = 73;
        s1.experiencePoint = 123123.0f;
        Debug.Log($"바꾼 뒤 S1 : {s1.level}, {s1.experiencePoint}");
        Debug.Log($"S2 : {s2.level}, {s2.experiencePoint}");

        Debug.Log($"C1 : {c1.level}, {c1.experiencePoint}");
        c1.SetVariable(-1, -111);
        Debug.Log($"바꾼 뒤 C1 : {c1.level}, {c1.experiencePoint}");
        Debug.Log($"C2 : {c2.level}, {c2.experiencePoint}");

        // Deep copy
        MyClass c3 = c1.DeepCopy();

        c1.SetVariable(-123, -456456);
        Debug.Log($"바꾼 뒤 C1 : {c1.level}, {c1.experiencePoint}");
        Debug.Log($"C3 : {c3.level}, {c3.experiencePoint}");
    }
}
