using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AzureManager : MonoBehaviour
{
    public string MobileAppUri = "http://yas-unity-easytables.azurewebsites.net";
    protected MobileServiceClient Client;

    public Rope rope;
    public GameObject enterHighScore;
    public GameObject buttonsRoot;
    public Button leaderboardButton;
    public InputField inputField;
    public Button submitButton;
    public GameObject leaderboard;
    public Text leaderboardText;

    // Use this for initialization
    public List<KitaazuJumpHighScoreInfo> list;
    public int maxScoreCount = 10;
    void Start()
    {
#if UNITY_ANDROID
		// Android builds fail at runtime due to missing GZip support, so build a handler that uses Deflate for Android
		var handler = new HttpClientHandler { AutomaticDecompression = DecompressionMethods.Deflate };
		Client = new MobileServiceClient(MobileAppUri, handler);
#else
        Client = new MobileServiceClient(MobileAppUri);
#endif

        submitButton.onClick.AddListener(() => InsertHighScore());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public async Task SetHighScore()
    {
        IMobileServiceTable<KitaazuJumpHighScoreInfo> tbl = Client.GetTable<KitaazuJumpHighScoreInfo>();

        try
        {
            list = await tbl.ToListAsync();
            list = list.OrderByDescending(x => x.Score).ToList();

            if(list.Count < maxScoreCount || rope.score > list[maxScoreCount - 1].Score)
            {
                enterHighScore.SetActive(true);
            }
            else
            {
                buttonsRoot.SetActive(true);
                leaderboardButton.interactable = true;
            }
            //await tbl.InsertAsync(new TodoItem { Text = "New item" });

            //WriteLine("Getting unfinished items");
            //List<TodoItem> list = await tbl.Where(i => i.Complete == false).ToListAsync();
            //foreach (TodoItem item in list)
            //    WriteLine($"{item.Id} - {item.Text} - {item.Complete}");

            //WriteLine("Updating first item");
            //list[0].Complete = true;
            //await tbl.UpdateAsync(list[0]);

            //WriteLine("Deleting first item");
            //await tbl.DeleteAsync(list[0]);
        }
        catch (Exception e)
        {
            buttonsRoot.SetActive(true);
            Debug.Log(e.ToString());
        }
    }

    public async Task InsertHighScore()
    {
        IMobileServiceTable<KitaazuJumpHighScoreInfo> tbl = Client.GetTable<KitaazuJumpHighScoreInfo>();

        try
        {
            string name = inputField.text == "" ? "NoName" : inputField.text;

            await tbl.InsertAsync(new KitaazuJumpHighScoreInfo { Name = name, Score = rope.score });

            list = await tbl.ToListAsync();
            list = list.OrderByDescending(x => x.Score).ToList();

            enterHighScore.SetActive(false);
            buttonsRoot.SetActive(true);
            leaderboardButton.interactable = true;
        }
        catch (Exception e)
        {
            enterHighScore.SetActive(false);
            buttonsRoot.SetActive(true);
            Debug.Log(e.ToString());
        }
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void ShowLeaderboard()
    {
        buttonsRoot.SetActive(false);
        leaderboard.SetActive(true);

        string text = "";
        for(int i=0; i<list.Count; i++)
        {
            text += "Rank" + string.Format("{0:D2}", i+1) + " " + string.Format("{0:D4}", list[i].Score) + " " + list[i].Name + "\n";
        }

        leaderboardText.text = text;
    }

    public void HideLeaderboard()
    {
        buttonsRoot.SetActive(true);
        leaderboard.SetActive(false);
    }
}
