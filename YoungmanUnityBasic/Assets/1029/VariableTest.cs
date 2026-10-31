using UnityEngine;

public class VariableTest : MonoBehaviour
{
    public GameObject[] tankObject = new GameObject[5]; // 탱크 오브젝트 저장

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //for (int i = 0; i < tankObject.Length; i++)
        //{
        //    if (i % 2 == 1)
        //    {
        //        continue;
        //    }
        //    Debug.Log(tankObject[i].name);
        //}

        //int i = 0;
        //int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        //while(i < 30)
        //{
        //    Debug.Log(i);
        //    i += numbers[i];
        //}

        //int sum = 0;
        //int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //foreach(int elements in numbers)
        //{
        //    sum += elements;
        //}
        //Debug.Log(sum);

        //int num = 300;
        //if(num > 150)
        //{
        //    Debug.Log("num은 150이상");
        //}

        //int value = 120;
        //switch(value)
        //{
        //    case 150:
        //    case 120:
        //        Debug.Log("120");
        //        break;
        //    default:
        //        break;
        //}

        for(int x = 2;x<=9;x++)
        {
            if(x % 2 == 0)
            {
                for(int y = 1;y<=9;y++)
                {
                    Debug.Log(string.Format("{0} X {1} = {2}", x, y, x * y));
                }
            }
            else
            {
                Debug.Log("홀수단이라 연산 안 함");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
