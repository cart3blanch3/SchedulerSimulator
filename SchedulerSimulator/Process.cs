using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerSimulator
{
    public class Process
    {
        public int Id { get; set; }  // Уникальный идентификатор процесса
        public DateTime ArrivalTime { get; set; }  // Время появления процесса
        public int BurstTime { get; set; }  // Время выполнения процесса
        public string State { get; set; }  // Текущее состояние процесса ("Готовность", "Выполнение")

        // Конструктор класса, инициализирующий свойства объекта Process
        public Process(int id, DateTime arrivalTime, int burstTime, string state)
        {
            Id = id;
            ArrivalTime = arrivalTime;
            BurstTime = burstTime;
            State = state;
        }
    }

}
