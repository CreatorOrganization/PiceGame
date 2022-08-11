using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patternScripts : MonoBehaviour
{
    public const int MOVE_PATTERN_STAY = 0;
    public const int MOVE_PATTERN_LEFT = 1;
    public const int MOVE_PATTERN_RIGHT = 2;

    private int movePattern;

    public float moveSpeed;
    private float deltaSpeed = 2;
    private float delaTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
