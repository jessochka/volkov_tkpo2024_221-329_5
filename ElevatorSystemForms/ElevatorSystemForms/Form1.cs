namespace ElevatorSystemForms
{
    using System;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        private Lift lift;

        public Form1()
        {
            InitializeComponent();
            lift = new Lift(500, 0.1); // ������������� ����� � ������������ ����������������� 500 �� � ������������ ���������� ������� 10%
        }

        // ����� ����� �� ����
        private void buttonCallToFloor_Click(object sender, EventArgs e)
        {
            int floor = int.Parse(textBoxFloor.Text);  // ��������� ����� �� ���������� ����
            lift.CallToFloor(floor);
        }

        // �������� �����
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            double weight = double.Parse(textBoxWeight.Text); // ��������� ���� �� ���������� ����
            lift.Load(weight);
        }

        // �������� �����
        private void buttonUnload_Click(object sender, EventArgs e)
        {
            double weight = double.Parse(textBoxWeight.Text); // ��������� ���� �� ���������� ����
            lift.Unload(weight);
        }

        // �������������� �������
        private void buttonRestorePower_Click(object sender, EventArgs e)
        {
            lift.RestorePower(30); // �������������� 30% �������
        }

        private void textBoxWeight_TextChanged(object sender, EventArgs e)
        {

        }
    }

    // ��������� ���������
    public interface ILiftState
    {
        void CallToFloor(Lift lift, int floor);
        void Load(Lift lift, double weight);
        void Unload(Lift lift, double weight);
    }

    // ����
    public class Lift
    {
        public ILiftState CurrentState { get; set; }
        public int CurrentFloor { get; private set; }
        public double MaxCapacity { get; }
        public double CurrentWeight { get; private set; }
        public double EnergyLevel { get; private set; }
        public double PowerOutageProbability { get; }

        public Lift(double maxCapacity, double powerOutageProbability)
        {
            MaxCapacity = maxCapacity;
            CurrentWeight = 0;
            CurrentFloor = 1;
            EnergyLevel = 100;
            PowerOutageProbability = powerOutageProbability;
            CurrentState = new WaitingState();
        }

        public void SetFloor(int floor)
        {
            CurrentFloor = floor;
        }

        public void AddWeight(double weight)
        {
            CurrentWeight += weight;
        }

        public void RemoveWeight(double weight)
        {
            CurrentWeight -= weight;
        }

        public void CallToFloor(int floor) => CurrentState.CallToFloor(this, floor);
        public void Load(double weight) => CurrentState.Load(this, weight);
        public void Unload(double weight) => CurrentState.Unload(this, weight);

        public void RestorePower(double amount)
        {
            EnergyLevel += amount;
            if (EnergyLevel > 100) EnergyLevel = 100;
            MessageBox.Show($"������� �������������. ������� ������� �������: {EnergyLevel}%.", "�������������� �������");
        }
    }

    // ��������� ��������
    public class WaitingState : ILiftState
    {
        public void CallToFloor(Lift lift, int floor)
        {
            if (lift.EnergyLevel == 0)
            {
                MessageBox.Show("��� �������! ���� �� ����� ���������.", "������");
                lift.CurrentState = new PowerOffState();
            }
            else
            {
                lift.SetFloor(floor);
                MessageBox.Show($"���� ������ �� ���� {floor}.", "�����������");
                lift.CurrentState = new WaitingState();
            }
        }

        public void Load(Lift lift, double weight)
        {
            if (lift.CurrentWeight + weight > lift.MaxCapacity)
            {
                MessageBox.Show($"����������! ��������: {lift.MaxCapacity} ��.", "������");
                lift.CurrentState = new OverloadState();
            }
            else
            {
                lift.AddWeight(weight);
                MessageBox.Show($"��������� {weight} ��. ������� ���: {lift.CurrentWeight} ��.", "��������");
            }
        }

        public void Unload(Lift lift, double weight)
        {
            if (weight > lift.CurrentWeight)
            {
                MessageBox.Show("������! �� ��������� ��������� ������, ��� ���������.", "������");
            }
            else
            {
                lift.RemoveWeight(weight);
                MessageBox.Show($"������ {weight} ��. ������� ���: {lift.CurrentWeight} ��.", "��������");
            }
        }
    }

    // ��������� ����������
    public class OverloadState : ILiftState
    {
        public void CallToFloor(Lift lift, int floor)
        {
            MessageBox.Show("���� ����������! �� ���� ���������.", "������");
        }

        public void Load(Lift lift, double weight)
        {
            MessageBox.Show("����������! ������� ����� �����, ����� ����������.", "������");
        }

        public void Unload(Lift lift, double weight)
        {
            lift.RemoveWeight(weight);
            MessageBox.Show($"������ {weight} ��. ������� ���: {lift.CurrentWeight} ��.", "��������");
            if (lift.CurrentWeight <= lift.MaxCapacity)
            {
                MessageBox.Show("���������� ���������. ���� ������������ � ����� ��������.", "����������");
                lift.CurrentState = new WaitingState();
            }
        }
    }

    // ��������� ��� �������
    public class PowerOffState : ILiftState
    {
        public void CallToFloor(Lift lift, int floor)
        {
            MessageBox.Show("��� �������! ���� �� ����� ���������.", "������");
        }

        public void Load(Lift lift, double weight)
        {
            MessageBox.Show("��� �������! ���������� ��������� ����.", "������");
        }

        public void Unload(Lift lift, double weight)
        {
            MessageBox.Show("��� �������! ���������� ��������� ����.", "������");
        }
    }
    // ����� Windows Forms

}
