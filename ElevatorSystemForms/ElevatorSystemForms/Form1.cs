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
            lift = new Lift(500, 0.1); // Инициализация лифта с максимальной грузоподъемностью 500 кг и вероятностью отключения энергии 10%
        }

        // Вызов лифта на этаж
        private void buttonCallToFloor_Click(object sender, EventArgs e)
        {
            int floor = int.Parse(textBoxFloor.Text);  // Получение этажа из текстового поля
            lift.CallToFloor(floor);
        }

        // Загрузка лифта
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            double weight = double.Parse(textBoxWeight.Text); // Получение веса из текстового поля
            lift.Load(weight);
        }

        // Выгрузка лифта
        private void buttonUnload_Click(object sender, EventArgs e)
        {
            double weight = double.Parse(textBoxWeight.Text); // Получение веса из текстового поля
            lift.Unload(weight);
        }

        // Восстановление энергии
        private void buttonRestorePower_Click(object sender, EventArgs e)
        {
            lift.RestorePower(30); // Восстановление 30% энергии
        }

        private void textBoxWeight_TextChanged(object sender, EventArgs e)
        {

        }
    }

    // Интерфейс состояния
    public interface ILiftState
    {
        void CallToFloor(Lift lift, int floor);
        void Load(Lift lift, double weight);
        void Unload(Lift lift, double weight);
    }

    // Лифт
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
            MessageBox.Show($"Энергия восстановлена. Текущий уровень энергии: {EnergyLevel}%.", "Восстановление энергии");
        }
    }

    // Состояние ожидания
    public class WaitingState : ILiftState
    {
        public void CallToFloor(Lift lift, int floor)
        {
            if (lift.EnergyLevel == 0)
            {
                MessageBox.Show("Нет питания! Лифт не может двигаться.", "Ошибка");
                lift.CurrentState = new PowerOffState();
            }
            else
            {
                lift.SetFloor(floor);
                MessageBox.Show($"Лифт прибыл на этаж {floor}.", "Перемещение");
                lift.CurrentState = new WaitingState();
            }
        }

        public void Load(Lift lift, double weight)
        {
            if (lift.CurrentWeight + weight > lift.MaxCapacity)
            {
                MessageBox.Show($"Перегрузка! Максимум: {lift.MaxCapacity} кг.", "Ошибка");
                lift.CurrentState = new OverloadState();
            }
            else
            {
                lift.AddWeight(weight);
                MessageBox.Show($"Добавлено {weight} кг. Текущий вес: {lift.CurrentWeight} кг.", "Загрузка");
            }
        }

        public void Unload(Lift lift, double weight)
        {
            if (weight > lift.CurrentWeight)
            {
                MessageBox.Show("Ошибка! Вы пытаетесь выгрузить больше, чем загружено.", "Ошибка");
            }
            else
            {
                lift.RemoveWeight(weight);
                MessageBox.Show($"Убрано {weight} кг. Текущий вес: {lift.CurrentWeight} кг.", "Выгрузка");
            }
        }
    }

    // Состояние перегрузки
    public class OverloadState : ILiftState
    {
        public void CallToFloor(Lift lift, int floor)
        {
            MessageBox.Show("Лифт перегружен! Не могу двигаться.", "Ошибка");
        }

        public void Load(Lift lift, double weight)
        {
            MessageBox.Show("Перегрузка! Уберите часть груза, чтобы продолжить.", "Ошибка");
        }

        public void Unload(Lift lift, double weight)
        {
            lift.RemoveWeight(weight);
            MessageBox.Show($"Убрано {weight} кг. Текущий вес: {lift.CurrentWeight} кг.", "Выгрузка");
            if (lift.CurrentWeight <= lift.MaxCapacity)
            {
                MessageBox.Show("Перегрузка устранена. Лифт возвращается в режим ожидания.", "Информация");
                lift.CurrentState = new WaitingState();
            }
        }
    }

    // Состояние без питания
    public class PowerOffState : ILiftState
    {
        public void CallToFloor(Lift lift, int floor)
        {
            MessageBox.Show("Нет питания! Лифт не может двигаться.", "Ошибка");
        }

        public void Load(Lift lift, double weight)
        {
            MessageBox.Show("Нет питания! Невозможно загрузить лифт.", "Ошибка");
        }

        public void Unload(Lift lift, double weight)
        {
            MessageBox.Show("Нет питания! Невозможно выгрузить лифт.", "Ошибка");
        }
    }
    // Форма Windows Forms

}
