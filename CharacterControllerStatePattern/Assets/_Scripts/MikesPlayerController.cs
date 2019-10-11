using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MikesPlayerController : MonoBehaviour
{
    Context context;

    Dictionary<string, int> stuff;

    void Start()
    {
        ConcreteStateA csA = new ConcreteStateA();
        context = new Context(csA);

        stuff = new Dictionary<string, int>();
        stuff.Add("score", 100);
        Debug.Log(stuff["score"]);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            context.Request1();
        }
    }
}
