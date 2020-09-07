using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VectorValue : ScriptableObject
{
    [SerializeField] private Vector2 initialValue = new Vector2(0,0);

    [SerializeField] private PlayerDirection facing = PlayerDirection.Down;

    public Vector2 InitialValue { get { return initialValue; } set { initialValue = value; } }
    public PlayerDirection Facing { get { return facing; } set { facing = value; } }
}
