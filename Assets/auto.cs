//using UnityEngine;
//using UnityEngine.UI;

//public class AutoTriggerButtonOnStart : MonoBehaviour
//{
//    public Button targetButton; // Tombol yang ingin ditekan otomatis

//    void Start()
//    {
//        // Memeriksa apakah tombol sudah pernah dipicu pada sesi aplikasi ini
//        if (targetButton != null && !PlayerPrefs.HasKey("ButtonTriggered"))
//        {
//            targetButton.onClick.Invoke(); // Menjalankan fungsi onClick pada tombol
//            PlayerPrefs.SetInt("ButtonTriggered", 1); // Menyimpan status bahwa tombol sudah ditekan
//            PlayerPrefs.Save(); // Menyimpan data ke penyimpanan
//        }
//    }

//    void OnApplicationQuit()
//    {
//        // Menghapus kunci ketika aplikasi ditutup, sehingga tombol akan dipicu lagi saat aplikasi dijalankan ulang
//        PlayerPrefs.DeleteKey("ButtonTriggered");
//    }
//}
