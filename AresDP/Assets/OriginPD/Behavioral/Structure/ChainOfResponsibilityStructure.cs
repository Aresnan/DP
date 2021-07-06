//-------------------------------------------------------------------------------------
//职责链模式
//基本结构
//-------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainOfResponsibilityStructure : MonoBehaviour
{
    void Start()
    {
        Handler handler1 = new ConcreteHandler1();
        Handler handler2 = new ConcreteHandler2();
        Handler handler3 = new ConcreteHandler3();

        handler1.SetSuccessor(handler2);
        handler2.SetSuccessor(handler3);

        int[] request = { 0, -1, 4, 53, 11, 7, -87 };
        foreach (var item in request)
        {
            handler1.HandleRequest(item);
        }
    }

    void Update()
    {

    }
}
/// <summary>
/// DP 中类图中的 Handler 类
/// </summary>
abstract class Handler
{
    protected Handler successor;
    public void SetSuccessor(Handler successor)
    {
        this.successor = successor;
    }
    public abstract void HandleRequest(int request);
}
/// <summary>
/// 具体实现类1
/// </summary>
class ConcreteHandler1 : Handler
{
    public override void HandleRequest(int request)
    {
        if (request < 0)
        {
            Debug.Log(this.GetType() + ": Process this data : " + request);
        }
        else if (successor != null)
        {
            this.successor.HandleRequest(request);
        }
    }
}
/// <summary>
/// 具体实现类2
/// </summary>
class ConcreteHandler2 : Handler
{
    public override void HandleRequest(int request)
    {
        if (request >= 0 && request < 10)
        {
            Debug.Log(this.GetType() + ": Process this data : " + request);
        }
        else if (successor != null)
        {
            this.successor.HandleRequest(request);
        }
    }
}
/// <summary>
/// 具体实现类3
/// </summary>
class ConcreteHandler3 : Handler
{
    public override void HandleRequest(int request)
    {
        if (request >= 10)
        {
            Debug.Log(this.GetType() + ": Process this data : " + request);
        }
        else if (successor != null)
        {
            this.successor.HandleRequest(request);
        }
    }
}