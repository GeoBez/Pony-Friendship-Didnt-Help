﻿
namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        public bool isFirstSession = true;
        public string language = "ru";

        // Ваши сохранения
        public int money = 1;
        public string newPlayerName = "Hello!";
        public bool[] openLevels = new bool[3];
    }
}
