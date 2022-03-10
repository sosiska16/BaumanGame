using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFalling : MonoBehaviour
{
    // Включение скрипта
    public void Start()
    {
        Physics2D.IgnoreLayerCollision(9, 10, true);
        Invoke("IgnoreLayerCollisionOff", 0.5f);
    }

    //Выключение скрипта
    private void IgnoreLayerCollisionOff()
    {
        Physics2D.IgnoreLayerCollision(9, 10, false);
    }
}
