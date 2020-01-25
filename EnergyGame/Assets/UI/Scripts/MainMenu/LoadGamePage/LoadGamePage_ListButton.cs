using System;
using System.Text;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace EnergyGame.UI.MainMenu
{
    public class LoadGamePage_ListButton : MonoBehaviour
    {
        public void Set(string name, DateTime dateTime, int index, UnityAction<int> clickAction)
        {
            Text text = GetComponentInChildren<Text>();

            StringBuilder str = new StringBuilder();
            str.Append(name);
            str.Append(" (");
            str.Append(dateTime.Hour);
            str.Append(":");
            str.Append(dateTime.Minute);
            str.Append(" ");
            str.Append(dateTime.Day);
            str.Append(".");
            str.Append(dateTime.Month);
            str.Append(".");
            str.Append(dateTime.Year);
            str.Append(")");

            text.text = str.ToString();

            Button btn = GetComponent<Button>();
            btn.onClick.AddListener(delegate { clickAction(index); });
        }

        public void Remove()
        {
            Destroy(gameObject);
        }
    }
}
