using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private HashSet<string> keys =
        new HashSet<string>();

    private bool hasFlashlight;

    public bool HasAnyKey()
    {
        return keys.Count > 0;
    }

    public void AddKey(string keyID)
    {
        if (!keys.Contains(keyID))
        {
            keys.Add(keyID);

            Debug.Log("Key Added: " + keyID);
        }
    }

    public bool HasKey(string keyID)
    {
        return keys.Contains(keyID);
    }

    public void AddFlashlight()
    {
        hasFlashlight = true;

        Debug.Log("Flashlight Added");
    }

    public bool HasFlashlight()
    {
        return hasFlashlight;
    }
}