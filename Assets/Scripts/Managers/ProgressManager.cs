using UnityEngine;

public static class ProgressManager
{
    public static int GetUnlockedLevel()
    {
        return PlayerPrefs.GetInt("UnlockedLevel", 1);
    }

    public static void UnlockNextLevel(int currentLevel)
    {
        int unlocked = GetUnlockedLevel();

        if (currentLevel >= unlocked)
        {
            PlayerPrefs.SetInt("UnlockedLevel", currentLevel + 1);
            PlayerPrefs.Save();
        }
    }

    public static bool IsLevelUnlocked(int level)
    {
        return level <= GetUnlockedLevel();
    }

    public static void ResetProgress()
    {
        PlayerPrefs.DeleteKey("UnlockedLevel");
    }
}