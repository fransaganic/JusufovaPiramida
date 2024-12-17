using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class InventoryManager : MonoBehaviour
{

   public static InventoryManager instance;
    public static List<Item> items = new List<Item>();
    public GameObject inventory;
    public bool state;
    public GameObject display;
    public GameObject infoButton;

    public Transform ItemContent;
    public GameObject InventoryItem;

    public GameObject vrata;

    public GameObject faraon;

    public Item JusufovSarkofag;

    public AudioSource source;
    public AudioClip clip;

    public AudioClip zmajZvuk;

    public Item artefakt1;
    public Item artefakt2;
    public Item artefakt3;

    public GameObject dragon;
    public Item amongus;

    private int pomoc;
    private int pomocni;
   private void Awake()
    {
        instance = this;
        state = false;
        pomoc = 0;
        pomocni = 0;
    }

    void Update()
    {
        
        if (!PauzaSkripta.isPaused){
            if (Input.GetKeyDown("i"))
            {
                if (!state)
                {
                    ListItems();
                }
                inventory.SetActive(!state);
                infoButton.SetActive(state);
                state = !state;
            }
        }

        if(items.Contains(JusufovSarkofag) && pomoc == 0){
            pomoc = 1;
            source.PlayOneShot(clip);
            faraon.transform.position = new Vector3 (faraon.transform.position.x, faraon.transform.position.y - 10, faraon.transform.position.z);
        }
        if(items.Contains(artefakt1) && items.Contains(artefakt2) && items.Contains(artefakt3))
            {
                 
                if(pomocni == 0){
                    
                    vrata.transform.position = new Vector3 (vrata.transform.position.x,vrata.transform.position.y - 20, vrata.transform.position.z);
                    pomocni = 1;
                    display.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
                

            }
    }

    public void Add(Item item)
    {
        items.Add(item);
        if (items.Count >= 3)
        {
            int counter = 0;
            foreach(var i in items)
            {
                if (i.id >= 1 && i.id <= 3)
                {
                    counter++;
                    
                }
            }
        }
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }

    public void ListItems()
    {
        foreach(Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach(var item in items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TMP_Text>();
            var itemIcon = obj.transform.Find("ItemImage").GetComponent<Image>();

            itemIcon.sprite = item.itemIcon;
            itemName.text = item.itemName;
            
        }
    }

    public int getItems(){
        Debug.Log(items.Count);
        return items.Count;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag("Player") && items.Contains(JusufovSarkofag)) {
            PlayerPrefs.SetInt("goodEnding", 1);

            if(PlayerPrefs.GetString("goodTimer") == "" ||
             ((float.Parse(PlayerPrefs.GetString("goodTimer").Split(char.Parse(":"))[0]) > Mathf.FloorToInt( MainMenu.currentTime / 60)) || 
             float.Parse(PlayerPrefs.GetString("goodTimer").Split(char.Parse(":"))[0]) == Mathf.FloorToInt( MainMenu.currentTime / 60)) &&
             float.Parse(PlayerPrefs.GetString("goodTimer").Split(char.Parse(":"))[1]) > Mathf.FloorToInt( MainMenu.currentTime % 60))
            {
                PlayerPrefs.SetString("goodTimer", string.Format("{0:00}:{1:00}", Mathf.FloorToInt( MainMenu.currentTime / 60), Mathf.FloorToInt( MainMenu.currentTime % 60)));
            }

            if(InventoryManager.items.Contains(amongus)) {
                PlayerPrefs.SetInt("susEnding", 1);

                if(PlayerPrefs.GetString("susTimer") == "" ||
                ((float.Parse(PlayerPrefs.GetString("susTimer").Split(char.Parse(":"))[0]) > Mathf.FloorToInt( MainMenu.currentTime / 60)) || 
                float.Parse(PlayerPrefs.GetString("susTimer").Split(char.Parse(":"))[0]) == Mathf.FloorToInt( MainMenu.currentTime / 60)) &&
                float.Parse(PlayerPrefs.GetString("susTimer").Split(char.Parse(":"))[1]) > Mathf.FloorToInt( MainMenu.currentTime % 60))
                {
                    PlayerPrefs.SetString("susTimer", string.Format("{0:00}:{1:00}", Mathf.FloorToInt( MainMenu.currentTime / 60), Mathf.FloorToInt( MainMenu.currentTime % 60)));
                }
            }
            SceneManager.LoadScene("GoodEnding");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (other.transform.CompareTag("Player") && items.Contains(artefakt1) && items.Contains(artefakt2) && items.Contains(artefakt3)) {
            if(!source.isPlaying && dragon.GetComponent<DragonScript>().GetHP() > 0) source.PlayOneShot(zmajZvuk);
        }
    }
}
