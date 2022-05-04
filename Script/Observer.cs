using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IPlayerAction
{
    //Eventos que se van a "escuchar" los observer

    event Action<int> ExpUpdated;  //Aumento de experiencia del player

    event Action<int> LvlUpdated; //Aumento de nive del player
}
//como hacer por herencia
/*public abstract class Observer : MonoBehaviour
{

  
    public abstract void OnNotify(object value, IEnumerator notifactionType);
   
}

public abstract class Subject : MonoBehaviour
{
    private List<Observer> _observer = new List<Observer>();

    public void RegisterObserver(Observer observer)
    {
        _observer.Add(observer);

    }

    public void Notify(object value, IEnumerator notificationType)
    {
        foreach (var observer in _observer)
            observer.OnNotify(value, notificationType);
    }

  
}*/
