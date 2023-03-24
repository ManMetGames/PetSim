using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using Slider = UnityEngine.UI.Slider;

public class StatTracker : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private Scrollbar scrollbar;
    [SerializeField] private Sprite[] Icons;
    [SerializeField] private Text[] Names;
    [SerializeField] private Gradient gradient;

    [Header("Penguin Variables")] 
    [SerializeField] private Image PenguinPic;
    [SerializeField] private TMP_Text PenguinName;
    [SerializeField] private TMP_Text PenguinHealth;
    [SerializeField] private TMP_Text PenguinHunger;
    [SerializeField] private TMP_Text PenguinHappy;
    [SerializeField] private Slider PenguinOverall;
    [SerializeField] private Image PenguinFill;
    [SerializeField] private TMP_Text PenguinPriority;
    [SerializeField] private Slider[] PenguinCurrentStats;
    
    [Header("Panda Variables")] 
    [SerializeField] private Image PandaPic;
    [SerializeField] private TMP_Text PandaName;
    [SerializeField] private TMP_Text PandaHealth;
    [SerializeField] private TMP_Text PandaHunger;
    [SerializeField] private TMP_Text PandaHappy;
    [SerializeField] private Slider PandaOverall;
    [SerializeField] private TMP_Text PandaPriority;
    [SerializeField] private Image PandaFill;
    [SerializeField] private Slider[] PandaCurrentStats;
    
    [Header("Coati Variables")] 
    [SerializeField] private Image CoatiPic;
    [SerializeField] private TMP_Text CoatiName;
    [SerializeField] private TMP_Text CoatiHealth;
    [SerializeField] private TMP_Text CoatiHunger;
    [SerializeField] private TMP_Text CoatiHappy;
    [SerializeField] private Slider CoatiOverall;
    [SerializeField] private TMP_Text CoatiPriority;
    [SerializeField] private Image CoatiFill;
    [SerializeField] private Slider[] CoatiCurrentStats;
    
    [Header("Meerkat Variables")] 
    [SerializeField] private Image MeerkatPic;
    [SerializeField] private TMP_Text MeerkatName;
    [SerializeField] private TMP_Text MeerkatHealth;
    [SerializeField] private TMP_Text MeerkatHunger;
    [SerializeField] private TMP_Text MeerkatHappy;
    [SerializeField] private Slider MeerkatOverall;
    [SerializeField] private TMP_Text MeerkatPriority;
    [SerializeField] private Image MeerkatFill;
    [SerializeField] private Slider[] MeerkatCurrentStats;
    
    [Header("Sloth Variables")] 
    [SerializeField] private Image SlothPic;
    [SerializeField] private TMP_Text SlothName;
    [SerializeField] private TMP_Text SlothHealth;
    [SerializeField] private TMP_Text SlothHunger;
    [SerializeField] private TMP_Text SlothHappy;
    [SerializeField] private Slider SlothOverall;
    [SerializeField] private TMP_Text SlothPriority;
    [SerializeField] private Image SlothFill;
    [SerializeField] private Slider[] SlothCurrentStats;
    // Start is called before the first frame update
    void Start()
    {
        scrollbar.value = 1f;
        StartCoroutine(ScrollLoop(scrollbar));

        PenguinPic.GetComponent<Image>().sprite = Icons[0];
        PandaPic.GetComponent<Image>().sprite = Icons[1];
        CoatiPic.GetComponent<Image>().sprite = Icons[2];
        MeerkatPic.GetComponent<Image>().sprite = Icons[3];
        SlothPic.GetComponent<Image>().sprite = Icons[4];

        PenguinName.text = Names[0].text;
        PandaName.text = Names[1].text;
        CoatiName.text = Names[2].text;
        MeerkatName.text = Names[3].text;
        SlothName.text = Names[4].text;

    }

    // Update is called once per frame
    void Update()
    {
        gradient.Evaluate(1f);
        PenguinHealth.text = ""+ PenguinCurrentStats[0].value;
        PenguinHunger.text = ""+ PenguinCurrentStats[1].value;
        PenguinHappy.text = ""+ PenguinCurrentStats[2].value;
        PenguinOverall.value =
            (PenguinCurrentStats[0].value + PenguinCurrentStats[1].value + PenguinCurrentStats[2].value)/3;
        PenguinFill.color = gradient.Evaluate(PenguinOverall.normalizedValue);
        
        PandaHealth.text = ""+ PandaCurrentStats[0].value;
        PandaHunger.text = ""+ PandaCurrentStats[1].value;
        PandaHappy.text = ""+ PandaCurrentStats[2].value;
        PandaOverall.value =
            (PandaCurrentStats[0].value + PandaCurrentStats[1].value + PandaCurrentStats[2].value)/3;
        PandaFill.color = gradient.Evaluate(PandaOverall.normalizedValue);
        
        CoatiHealth.text = ""+ CoatiCurrentStats[0].value;
        CoatiHunger.text = ""+ CoatiCurrentStats[1].value;
        CoatiHappy.text = ""+ CoatiCurrentStats[2].value;
        CoatiOverall.value =
            (CoatiCurrentStats[0].value + CoatiCurrentStats[1].value + CoatiCurrentStats[2].value)/3;
        CoatiFill.color = gradient.Evaluate(CoatiOverall.normalizedValue);
        
        MeerkatHealth.text = ""+ MeerkatCurrentStats[0].value;
        MeerkatHunger.text = ""+ MeerkatCurrentStats[1].value;
        MeerkatHappy.text = ""+ MeerkatCurrentStats[2].value;
        MeerkatOverall.value =
            (MeerkatCurrentStats[0].value + MeerkatCurrentStats[1].value + MeerkatCurrentStats[2].value)/3;
        MeerkatFill.color = gradient.Evaluate(MeerkatOverall.normalizedValue);
        
        SlothHealth.text = ""+ SlothCurrentStats[0].value;
        SlothHunger.text = ""+ SlothCurrentStats[1].value;
        SlothHappy.text = ""+ SlothCurrentStats[2].value;
        SlothOverall.value =
            (SlothCurrentStats[0].value + SlothCurrentStats[1].value + SlothCurrentStats[2].value)/3;
        SlothFill.color = gradient.Evaluate(SlothOverall.normalizedValue);
    }

    IEnumerator ScrollLoop(Scrollbar vertScroll)
    {
        while (vertScroll.value>(-1.6f))
        {
            yield return new WaitForSeconds(0.1f);
            vertScroll.value -= 0.025f;
            if (vertScroll.value <= (-1.555))
            {
                vertScroll.value = 2.55f;
            }
        }
    }

    /*public void ScrollReset()
    {
        if (scroller.GetComponentInChildren<Scrollbar>().value < 0.01)
        {
            scroller.GetComponentInChildren<Scrollbar>().value = 1;
        }
    }*/
}
