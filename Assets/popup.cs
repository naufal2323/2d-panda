using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    public GameObject popupPanel;  // Panel yang akan menjadi pop-up

    // Fungsi untuk menampilkan pop-up
    public void ShowPopup()
    {
        popupPanel.SetActive(true);
    }

    // Fungsi untuk menyembunyikan pop-up
    public void HidePopup()
    {
        popupPanel.SetActive(false);
    }
}
