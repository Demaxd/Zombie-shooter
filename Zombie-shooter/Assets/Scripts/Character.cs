using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Character : MonoBehaviour
{
    protected bool isDead;

    public event UnityAction Died;
    protected virtual void Die() 
    {
        Died?.Invoke();
    }
}
