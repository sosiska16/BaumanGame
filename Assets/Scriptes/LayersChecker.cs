using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGround : MonoBehaviour
{
    public static bool onGround, checkStairs;
    public Transform GroundCheck, CheckLadder;
    public float checkdRadius = 0.5f;
    public LayerMask Ground, LadderMask;
    private void Update()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkdRadius, Ground); // Проверяет на земле ли игрок
        checkStairs = Physics2D.OverlapCircle(CheckLadder.position, checkdRadius, LadderMask); // Проверяет находится ли игрок возле лестницы
    }
}
