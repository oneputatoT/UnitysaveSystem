using UnityEngine;
using System;

namespace SaveSystemTutorial
{
    public class PlayerData : MonoBehaviour
    {
        #region Fields

        [SerializeField] string playerName = "Player Name";
        [SerializeField] int level = 0;
        [SerializeField] int coin = 0;

        #endregion


        [Serializable]
        class TestData
        {
            public string playerName;
            public int level;
            public int coin;
            public Vector3 curPositon;
        }

        #region Properties

        public string Name => playerName;

        public int Level => level;
        public int Coin => coin;

        public Vector3 Position => transform.position;

        #endregion

        #region Save and Load

        public void Save()
        {
            //SaveData();
            SaveWithJson();
        }

        public void Load()
        {
            //LoadData();
            LoadWithJson();
        }

        #endregion

        #region PlayerPrefs
        void SaveData()
        {
            //方法一，直接运用Playerprefs
            //PlayerPrefs.SetString("PlayerName", playerName);
            //PlayerPrefs.SetInt("Level", level);
            //PlayerPrefs.SetInt("Coin", coin);
            //PlayerPrefs.SetFloat("X", transform.position.x);
            //PlayerPrefs.SetFloat("Y", transform.position.y);
            //PlayerPrefs.SetFloat("Z", transform.position.z);
            //PlayerPrefs.Save();
            SaveSystem.SaveData("Data", CeateData());
        }
        void LoadData()
        {
            //方法一，直接运用Playerprefs
            //playerName = PlayerPrefs.GetString("PlayerName");
            //若无值则返回这个默认值
            //playerName = PlayerPrefs.GetString("PlayerName", "Nobody");  
            //level = PlayerPrefs.GetInt("Level");
            //coin = PlayerPrefs.GetInt("Coin");
            //transform.position =
            //    new Vector3( PlayerPrefs.GetFloat("X"), PlayerPrefs.GetFloat("Y", transform.position.y), PlayerPrefs.GetFloat("Z", transform.position.z));

            var json = SaveSystem.LoadData("Data");
            var loadData = JsonUtility.FromJson<TestData>(json);
            LoadAimData(loadData);
        }
        #endregion


        public void SaveWithJson()
        {
            SaveSystem.SaveJsonData("Test", CeateData());
            //SaveSystem.SaveJsonData($"{System.DateTime.Now:yyyy.dd.M HH-mm-ss}.sav", CeateData());

        }

        public void LoadWithJson()
        {
            var data = SaveSystem.LoadJsonData<TestData>("Test");
            LoadAimData(data);
        }


        TestData CeateData()
        {
            TestData Data = new TestData();
            Data.playerName = playerName;
            Data.level = level;
            Data.coin = coin;
            Data.curPositon = transform.position;
            return Data;
        }


        void LoadAimData(TestData loadData)
        {
            this.playerName = loadData.playerName;
            this.level = loadData.level;
            this.coin = loadData.coin;
            this.transform.position = loadData.curPositon;
        }

        //编写工具菜单
        [UnityEditor.MenuItem("Developer/Delete All PlayerData")]
        public static void DeletePlayerData()
        {
            PlayerPrefs.DeleteAll();
        }

        [UnityEditor.MenuItem("Developer/Delete JsonData")]
        public static void DeleteJsonData()
        {
            SaveSystem.DeleteFile("Test");
        }
    }
}