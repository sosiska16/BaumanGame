using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCheck : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) { IgnoreLayerCollisionOn(); }
    }

    //Включение скрипта
    private void IgnoreLayerCollisionOn()
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
