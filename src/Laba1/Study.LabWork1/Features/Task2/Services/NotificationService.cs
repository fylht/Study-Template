using System;
using System.Collections.Generic;
using System.Text;
using Study.LabWork1.Features.Task2.Abstractions;

namespace Study.LabWork1.Features.Task2.Services
{
    internal class NotificationService : INotification
    {
        public void SendNotifications(string emale) {
            Console.WriteLine("Отправка уведомления покупателю...");
        } 
    }
}
