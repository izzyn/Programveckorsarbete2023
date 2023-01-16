using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMG_weapons : MonoBehaviour
{
    [SerializeField]
    private int dmg_spear;
    [SerializeField]
    private int dmg_axe;
    Dictionary<string, int> dmg = new Dictionary<string, int>();

    // Start is called before the first frame update
    void Start()
    {
        dmg.Add("spear", dmg_spear);
        dmg.Add("axe", dmg_axe);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
