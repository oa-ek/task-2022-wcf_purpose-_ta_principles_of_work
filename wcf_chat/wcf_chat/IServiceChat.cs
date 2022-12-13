using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace wcf_chat
{
    // ПРИМЕЧАНИЕ. Можно использовать команду "Переименовать" в меню "Рефакторинг", чтобы изменить имя интерфейса "IServiceChat" в коде и файле конфигурации.
    [ServiceContract(CallbackContract = typeof(IServerChatCallback))]
    public interface IServiceChat
    {
        [OperationContract]//Метод в якого є, атрибут "OperationContract" буде видний зі сторони клієнта, щоб ми потом використовували його клієнтом
        int Connect(string name); //Метод для підключення до сервісу

        [OperationContract]
        void Disconnect(int id); //Метод для відключення з сервісу

        [OperationContract(IsOneWay = true)]
        void SendMsg(string mgs, int id); //Метод для приймання сповіщення, та вказування, від кого


    }


    public interface IServerChatCallback //Вертає повідомлення
    {
        [OperationContract(IsOneWay = true)]
        void MsgCallback(string msg);
    }
}
