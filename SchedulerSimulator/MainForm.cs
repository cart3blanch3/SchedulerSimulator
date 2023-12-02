namespace SchedulerSimulator
{
    public partial class SchedulingAlgorithm : Form
    {
        private int processId = 1;  // ���������� ������������� ��������
        private List<Process> processes = new List<Process>();  // ������ ���������
        private SchedulingAlgorithms selectedAlgorithm = SchedulingAlgorithms.FCFS;  // ��������� �������� ������������
        private Process currentProcess;  // ������� ������������� �������

        // ����������� �����
        public SchedulingAlgorithm()
        {
            InitializeComponent(); // ������������� ����������� �����
            radioButtonFCFS.Checked = true;  // ������������� SJF ��� �������� �� ���������
            timer.Start();  // ��������� ������
        }

        // ���������� ������� �������
        private void timer_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString();  // ��������� ����������� �������� �������

            // ���������, ��� ���� ������� ��� ����������
            if (currentProcess != null)
            {
                currentProcess.State = "����������";  // ������������� ��������� "����������" ��� �������� ��������
                currentProcess.BurstTime--; // ��������� ���������� ����� ����������

                // ���� ����� ���������� �������� �������� ���������
                if (currentProcess.BurstTime == 0)
                {
                    processes.Remove(currentProcess);  // ������� ����������� ������� �� ������

                    // ���� ���� ��� �������� � ������, �������� ��������� �������
                    if (processes.Count > 0)
                    {
                        currentProcess = processes[0];
                    }
                }
            }

            UpdateListView();  // ��������� ����������� ������ ��������� � ����������
        }

        // ���������� ������� ������ "��������"
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            DateTime arrivalTime = DateTime.Now; // �������� ������� ����� ��� ����� �������� ��� ������ ��������
            int burstTime = (int)numericBurstTime.Value; // ��������� �������� ������������ ���������� �������� �� ��������� �������� 

            // ������� ����� ������� � ������� �������� ��� �������� ��������
            Process newProcess = new Process(processId++, arrivalTime, burstTime, "����������");

            // ��������� ����� ������ �������� ������������, ���� ��� ����������� SJF, �� ���������� ����� ������� � �������
            if (selectedAlgorithm == SchedulingAlgorithms.SJFPreemptive)
            {
                // ���������, ����� �� ����� ������� ������� ����� ����������, ��� ������� �������������
                if (currentProcess == null || newProcess.BurstTime < currentProcess.BurstTime)
                {
                    // ����� ������� ��������� ������� �������
                    newProcess.State = "����������";

                    // ���� ���� ������� �������, ���������� ��� � ��������� "����������"
                    if (currentProcess != null)
                    {
                        currentProcess.State = "����������";
                        processes.Insert(0, newProcess);  // ��������� � ������ ������
                    }

                    // ������������� ����� ������� � �������� ��������
                    currentProcess = newProcess;
                }
                else
                {
                    // ����� ������� �� ��������� ������� �������
                    newProcess.State = "����������";
                    BinaryInsert(newProcess);  // ��������� � ������������ � ����������� ��� ����������
                }
            }
            else
            {
                // FCFS �� ���������� �������� �����, ������ ��������� � ����� ������
                processes.Add(newProcess);
            }

            UpdateListView();  // ��������� ����������� ������ ��������� � ����������
        }

        // �������� ������� ��������
        private void BinaryInsert(Process newProcess)
        {
            // ��������� �������� ����� ������� ��� ������ �������� � ��������������� ������ ���������
            int index = processes.BinarySearch(newProcess, Comparer<Process>.Create((p1, p2) =>
            {
                // ���������� �������� �� ������� ����������
                int burstTimeComparison = p1.BurstTime.CompareTo(p2.BurstTime);
                if (burstTimeComparison == 0)
                {
                    // ��� ��������� ������ ���������� ���������� �������� �������� ��� �������������� (FIFO)
                    return p1.ArrivalTime.CompareTo(p2.ArrivalTime);
                }
                return burstTimeComparison;
            }));

            // ���� ������� �� ������, ������������ ������� ���������� � ������������� ������
            if (index < 0) index = ~index;

            // ��������� ����� ������� � ��������������� ������� � ������
            processes.Insert(index, newProcess);
        }

        // ���������� ����������� ������ ��������� � ����������
        private void UpdateListView()
        {
            // ��������� ListView (������ ���������) � ������������ � ������� ���������� ���������
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

        // ���������� ������� ������ ������ ���������
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

            SortProcessList();  // ��������� ������ ��������� � ������������ � ����� ����������

            if (processes.Count > 0)
            {
                currentProcess = processes[0];  // ������������� ������ ������� � ������ ��� �������
            }
        }

        // ���������� ������ ��������� � ������������ � ��������� ����������
        private void SortProcessList()
        {
            switch (selectedAlgorithm)
            {
                case SchedulingAlgorithms.FCFS:
                    // ���������� ��� FCFS (First-Come-First-Serve)
                    processes.Sort((p1, p2) => p1.ArrivalTime.CompareTo(p2.ArrivalTime));
                    break;

                case SchedulingAlgorithms.SJFPreemptive:
                    // ��������� ������ � ������������ � ���������� SJF Non-Preemptive
                    processes.Sort((p1, p2) =>
                    {
                        int burstTimeComparison = p1.BurstTime.CompareTo(p2.BurstTime);
                        if (burstTimeComparison == 0)
                        {
                            // ��� ��������� ������ ���������� ���������� �������� �������� (FIFO)
                            return p1.ArrivalTime.CompareTo(p2.ArrivalTime);
                        }
                        return burstTimeComparison;
                    });
                    break;
            }

            // ��������� State �� "����������" ����� ����������
            foreach (var process in processes)
            {
                process.State = "����������";
            }

            // ��������� ListView ����� ����������
            UpdateListView();
        }
    }
}
