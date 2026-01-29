using System;
using System.Collections.Generic;
using Enums;
using Interfaces;
using UnityEngine;

namespace Systems
{
    public class GameUpdateManager : MonoBehaviour
    {
        public static GameUpdateManager Instance { get; private set; }
        
        private readonly List<IUpdateable> _highPriorityUpdates;
        private readonly List<IUpdateable> _mediumPriorityUpdates;
        private readonly List<IUpdateable> _lowPriorityUpdates;
        
       private const float MediumUpdateInterval = 0.15f;
       private const float LowUpdateInterval = 0.4f;
       private float _mediumTimer;
       private float _lowTimer;

       private void Iterate(List<IUpdateable> updates)
       {
           for (int i = 0; i < updates.Count; i++)
               updates[i].OnUpdate(Time.deltaTime);
       }

       private void HighPriorityUpdate()
       {
           Iterate(_highPriorityUpdates);
       }

       private void MediumPriorityUpdate()
       {
           _mediumTimer += Time.deltaTime;
           if(_mediumTimer < MediumUpdateInterval) return;
           Iterate(_mediumPriorityUpdates);
           _mediumTimer = 0f;
       }

       private void LowPriorityUpdate()
       {
           _lowTimer += Time.deltaTime;
           if(_lowTimer < LowUpdateInterval) return;
           Iterate(_lowPriorityUpdates);
           _lowTimer = 0f;
       }

       public void Register(IUpdateable update, UpdatePriority priority)
       {
           switch (priority)
           {
               case UpdatePriority.High:
                   _highPriorityUpdates.Add(update);
                   break;
               case UpdatePriority.Medium:
                   _mediumPriorityUpdates.Add(update);
                   break;
               case UpdatePriority.Low:
                   _lowPriorityUpdates.Add(update);
                   break;
               default:
                   throw new ArgumentOutOfRangeException(nameof(priority), priority, null);
           }
       }

       public void Unregister(IUpdateable update)
       {
           if(_highPriorityUpdates.Remove(update)) return;
           if(_mediumPriorityUpdates.Remove(update)) return;
           _lowPriorityUpdates.Remove(update);
       }

       private void Awake()
       {
           if (Instance != null && Instance != this)
           {
               Destroy(gameObject);
               return;
           }

           Instance = this;
           DontDestroyOnLoad(gameObject);
       }

       private void Update()
       {
           HighPriorityUpdate();
           MediumPriorityUpdate();
           LowPriorityUpdate();
       }
    }
}
