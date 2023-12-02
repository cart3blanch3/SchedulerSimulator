namespace SchedulerSimulator
{
    public partial class SchedulingAlgorithm : Form
    {
        private int processId = 1;  // Уникальный идентификатор процесса
        private List<Process> processes = new List<Process>();  // Список процессов
        private SchedulingAlgorithms selectedAlgorithm = SchedulingAlgorithms.FCFS;  // Выбранный алгоритм планирования
        private Process currentProcess;  // Текущий выполняющийся процесс

        // Конструктор формы
        public SchedulingAlgorithm()
        {
            InitializeComponent(); // Инициализация компонентов формы
            radioButtonFCFS.Checked = true;  // Устанавливаем SJF как алгоритм по умолчанию
            timer.Start();  // Запускаем таймер
        }

        // Обработчик события таймера
        private void timer_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString();  // Обновляем отображение текущего времени

            // Проверяем, что есть процесс для выполнения
            if (currentProcess != null)
            {
                currentProcess.State = "Исполнение";  // Устанавливаем состояние "Исполнение" для текущего процесса
                currentProcess.BurstTime--; // Уменьшаем оставшееся время выполнения

                // Если время выполнения текущего процесса исчерпано
                if (currentProcess.BurstTime == 0)
                {
                    processes.Remove(currentProcess);  // Удаляем завершенный процесс из списка

                    // Если есть еще процессы в списке, выбираем следующий процесс
                    if (processes.Count > 0)
                    {
                        currentProcess = processes[0];
                    }
                }
            }

            UpdateListView();  // Обновляем отображение списка процессов в интерфейсе
        }

        // Обработчик события кнопки "Добавить"
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            DateTime arrivalTime = DateTime.Now; // Получаем текущее время как время прибытия для нового процесса
            int burstTime = (int)numericBurstTime.Value; // Извлекаем значение длительности выполнения процесса из числового элемента 

            // Создаем новый процесс с текущим временем как временем прибытия
            Process newProcess = new Process(processId++, arrivalTime, burstTime, "Готовность");

            // Проверяем какой выбран алгоритм планирования, если это вытесняющий SJF, то сравниваем новый процесс с текущим
            if (selectedAlgorithm == SchedulingAlgorithms.SJFPreemptive)
            {
                // Проверяем, имеет ли новый процесс меньшее время выполнения, чем текущий выполняющийся
                if (currentProcess == null || newProcess.BurstTime < currentProcess.BurstTime)
                {
                    // Новый процесс вытесняет текущий процесс
                    newProcess.State = "Исполнение";

                    // Если есть текущий процесс, возвращаем его в состояние "Готовность"
                    if (currentProcess != null)
                    {
                        currentProcess.State = "Готовность";
                        processes.Insert(0, newProcess);  // Вставляем в начало списка
                    }

                    // Устанавливаем новый процесс в качестве текущего
                    currentProcess = newProcess;
                }
                else
                {
                    // Новый процесс не вытесняет текущий процесс
                    newProcess.State = "Готовность";
                    BinaryInsert(newProcess);  // Вставляем в соответствии с приоритетом без вытеснения
                }
            }
            else
            {
                // FCFS не использует бинарный поиск, просто вставляем в конец списка
                processes.Add(newProcess);
            }

            UpdateListView();  // Обновляем отображение списка процессов в интерфейсе
        }

        // Бинарная вставка процесса
        private void BinaryInsert(Process newProcess)
        {
            // Выполняем бинарный поиск позиции для нового процесса в отсортированном списке процессов
            int index = processes.BinarySearch(newProcess, Comparer<Process>.Create((p1, p2) =>
            {
                // Сравниваем процессы по времени выполнения
                int burstTimeComparison = p1.BurstTime.CompareTo(p2.BurstTime);
                if (burstTimeComparison == 0)
                {
                    // При равенстве времен выполнения используем временем прибытия для упорядочивания (FIFO)
                    return p1.ArrivalTime.CompareTo(p2.ArrivalTime);
                }
                return burstTimeComparison;
            }));

            // Если процесс не найден, конвертируем битовое дополнение в положительный индекс
            if (index < 0) index = ~index;

            // Вставляем новый процесс в соответствующую позицию в списке
            processes.Insert(index, newProcess);
        }

        // Обновление отображения списка процессов в интерфейсе
        private void UpdateListView()
        {
            // Обновляем ListView (список процессов) в соответствии с текущим состоянием процессов
            listView1.Items.Clear();
            foreach (Process process in processes)
            {
                ListViewItem item = new ListViewItem(process.Id.ToString());
                item.SubItems.Add(process.ArrivalTime.ToString());
                item.SubItems.Add(process.BurstTime.ToString());
                item.SubItems.Add(process.State);
                listView1.Items.Add(item);
            }
        }

        // Обработчик события кнопки выбора алгоритма
        private void buttonSelect_Click(object sender, EventArgs e)
        {
            if (radioButtonSJFPreemptive.Checked)
            {
                selectedAlgorithm = SchedulingAlgorithms.SJFPreemptive;
            }
            else
            {
                selectedAlgorithm = SchedulingAlgorithms.FCFS;
            }

            SortProcessList();  // Сортируем список процессов в соответствии с новым алгоритмом

            if (processes.Count > 0)
            {
                currentProcess = processes[0];  // Устанавливаем первый процесс в списке как текущий
            }
        }

        // Сортировка списка процессов в соответствии с выбранным алгоритмом
        private void SortProcessList()
        {
            switch (selectedAlgorithm)
            {
                case SchedulingAlgorithms.FCFS:
                    // Сортировка для FCFS (First-Come-First-Serve)
                    processes.Sort((p1, p2) => p1.ArrivalTime.CompareTo(p2.ArrivalTime));
                    break;

                case SchedulingAlgorithms.SJFPreemptive:
                    // Сортируем список в соответствии с алгоритмом SJF Non-Preemptive
                    processes.Sort((p1, p2) =>
                    {
                        int burstTimeComparison = p1.BurstTime.CompareTo(p2.BurstTime);
                        if (burstTimeComparison == 0)
                        {
                            // При равенстве времен выполнения используем временем прибытия (FIFO)
                            return p1.ArrivalTime.CompareTo(p2.ArrivalTime);
                        }
                        return burstTimeComparison;
                    });
                    break;
            }

            // Обновляем State на "Готовность" после сортировки
            foreach (var process in processes)
            {
                process.State = "Готовность";
            }

            // Обновляем ListView после сортировки
            UpdateListView();
        }
    }
}
