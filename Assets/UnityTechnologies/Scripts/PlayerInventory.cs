using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Collect : MonoBehaviour
{
public int NumberOfLemons { get; private set; }
public UnityEvent<Collect> OnLemonCollected;
public void LemonCollected()
{
    NumberOfLemons++;
    OnLemonCollected.Invoke(this);
}
}
