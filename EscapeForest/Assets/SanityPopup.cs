//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;
//using System.Dynamic;

//public class SanityPopup : MonoBehaviour
//{

//    [SerializeField] private Transform sanityPopupPrefab;
//    private TextMeshPro textMesh;

//    public static SanityPopup Create(int sanityCost) {

//        Transform sanityPopupTransform = Instantiate(sanityPopupPrefab, Vector3.zero, Quaternion.identity);
//        SanityPopup sanityPopup = sanityPopupTransform.GetComponent<SanityPopup>();
//        sanityPopup.Setup(sanityCost);

//        return sanityPopup;
//    }

//    private void Awake() {
//        textMesh = transform.GetComponent<TextMeshPro>();
//    }

//    // Start is called before the first frame update
//    public void Setup(int sanityCost)
//    {
//        textMesh.SetText(sanityCost.ToString());
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//}
