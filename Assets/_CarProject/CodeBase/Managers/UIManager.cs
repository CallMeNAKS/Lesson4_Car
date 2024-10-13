using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CodeBase.Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Button[] _buttons = Array.Empty<Button>();
        [SerializeField] private Light[] _lights = Array.Empty<Light>();

        private void OnEnable()
        {
            foreach (var light in _lights)
            {
                light.intensity = 0f;
            }

            foreach (var button in _buttons)
            {
                EventTrigger trigger = button.gameObject.GetComponent<EventTrigger>() ?? button.gameObject.AddComponent<EventTrigger>();

                AddTrigger(trigger, EventTriggerType.PointerEnter, (eventData) => OnCursorEvent(button, true));
                AddTrigger(trigger, EventTriggerType.PointerExit, (eventData) => OnCursorEvent(button, false));
                AddTrigger(trigger, EventTriggerType.PointerClick, (eventData) => OnButtonClick(button));
            }
        }

        private void OnDisable()
        {
            foreach (var button in _buttons)
            {
                var trigger = button.gameObject.GetComponent<EventTrigger>();
                trigger?.triggers.Clear();
            }
        }

        private void OnCursorEvent(Button button, bool isEntering)
        {
            //Debug.Log($"{(isEntering ? "Entered" : "Exited")} button: {button.name}");

            int index = Array.IndexOf(_buttons, button);
            if (index >= 0 && index < _lights.Length)
            {
                _lights[index].intensity = isEntering ? 3 : 0;
            }
        }

        private void OnButtonClick(Button button)
        {
            int index = Array.IndexOf(_buttons, button);
            GameManager.Instance.StartPlayMode(index);
        }

        private void AddTrigger(EventTrigger trigger, EventTriggerType eventType, Action<BaseEventData> action)
        {
            var entry = new EventTrigger.Entry { eventID = eventType };
            entry.callback.AddListener(new UnityEngine.Events.UnityAction<BaseEventData>(action));
            trigger.triggers.Add(entry);
        }


    }

}