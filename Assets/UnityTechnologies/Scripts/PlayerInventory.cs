using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
public int NumberOfDiamonds { get; private set; }
public void DiamonCollected()
{
    NumberOfDiamonds++;
}
}
