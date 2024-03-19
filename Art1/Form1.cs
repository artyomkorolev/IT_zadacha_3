using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Art1
{
    public partial class Form1 : Form
    {
        private Stack myStack = new Stack();

        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            // Инициализация стека
            myStack = new Stack();

            // Добавление элементов в стек для демонстрации
            myStack.Push(5);
            myStack.Push(10);
            myStack.Push(15);

            // Обновление информации о стеке
            UpdateStackInformation();
        }

        private void UpdateStackInformation()
        {
            textBoxCurrentElement.Text = myStack.IsEmpty ? "N/A" : myStack.Peek().ToString();
            labelCount.Text = $"Число элементов: {myStack.Count}";
            labelIsEmpty.Text = $"Пуст?: {myStack.IsEmpty}";
        }
        

        private void buttonPop_Click_Click(object sender, EventArgs e)
        {
            if (!myStack.IsEmpty)
            {
                int poppedItem = myStack.Pop();
                MessageBox.Show($"Удаленный элемент: {poppedItem}");
                UpdateStackInformation();
            }
            else
            {
                MessageBox.Show("Стек пуст.");
            }
        }

        private void buttonClear_Click_Click(object sender, EventArgs e)
        {
            myStack.Clear();
            UpdateStackInformation();
        }

        class Stack
        {
            private List<int> elements = new List<int>();

            public void Push(int item)
            {
                elements.Add(item);
            }

            public int Pop()
            {
                if (elements.Count == 0)
                {
                    throw new InvalidOperationException("Cannot pop from an empty stack.");
                }

                int poppedItem = elements[elements.Count - 1];
                elements.RemoveAt(elements.Count - 1);
                return poppedItem;
            }

            public int Peek()
            {
                if (elements.Count == 0)
                {
                    throw new InvalidOperationException("Cannot peek an empty stack.");
                }

                return elements[elements.Count - 1];
            }

            public void Clear()
            {
                elements.Clear();
            }

            public bool IsEmpty
            {
                get { return elements.Count == 0; }
            }

            public int Count
            {
                get { return elements.Count; }
            }

            public IEnumerable<int> GetAllItems()
            {
                return elements;
            }
        }

        private void buttonShowItems_Click_Click(object sender, EventArgs e)
        {
            string allItems = GetAllItemsInStack();
            MessageBox.Show("All Items in Stack: \n" + allItems);
        }
        private string GetAllItemsInStack()
        {
            return string.Join(", ", myStack.GetAllItems());
        }

        private void buttonPush_Click_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxCurrentElement.Text, out int newItem))
            {
                myStack.Push(newItem);
                UpdateStackInformation();
            }
            else
            {
                MessageBox.Show("Please enter a valid integer value in the text box.");
            }
        }
    }
}
