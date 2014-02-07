using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace ExpertSystem
{
    public partial class Form1 : Form
    {
        string xmlFileName;                                 // Имя файла с вопросами
        XDocument xDocument;                                // Инструмент для работы с xml
        XNode node;                                         // Указатель на первый элемент в xml
        XElement questionEl;                                // Элемент, содержащий объект "вопрос"
        System.Windows.Forms.RadioButton[] radioButtons;    // Динамически создаваемые кнопки для каждого вопроса
        string answerLvl;                                   // Уровень ответа, определяющий уровень след вопроса
        XElement prevQuestionEl;                            // Вопрос, на который дан ответ в пред. итерации
        
        // Группы видов спорта в порядке невозростания нагрузки
        string[] groups = { "power", "speedpower", "run"     , 
                            "fight", "game"      , "sologame", 
                            "coord", "techo"     , "intel"   };
        int currentGroup;

        int health;                                         // Значение ОФП
        int first;                                          // Значение подходящести 1-го вида спорта в группе
        int second;                                         // Значение подходящести 2-го вида спорта в группе
        int third;                                          // Значение подходящести 3-го вида спорта в группе

        public Form1()
        {
            // Тотальная инициализация
            InitializeComponent();
            xmlFileName = "questions.xml";
            xDocument = XDocument.Load(xmlFileName);
            node = xDocument.FirstNode;
            questionEl = node.Document.Element("root").Element("basic").Element("question");
            currentGroup = 0;
        }

        // ---------------------------------------------------------------------------------------
        // Функция определения подходящих групп видов спорта
        //
        private void MakeGroupChoice()
        {
            if (health > 70)
            {
                currentGroup = 0;
            }
            else if (health > 60)
            {
                currentGroup = 1;
            }
            else if (health > 50)
            {
                currentGroup = 2;
            }
            else if (health > 40)
            {
                currentGroup = 3;
            }
            else if (health > 30)
            {
                currentGroup = 4;
            }
            else if (health > 20)
            {
                currentGroup = 5;
            }
            else if (health > 10)
            {
                currentGroup = 6;
            }
            else if (health > 0)
            {
                currentGroup = 7;
            }
            else if (health > -100)
            {
                currentGroup = 7;
            }
            questionEl = node.Document.Element("root").Element(groups[currentGroup]).Element("question");
        }

        // ---------------------------------------------------------------------------------------
        // Функция вывода результата теста
        //
        private void ShowResult()
        {
            nextButton1.Visible = true;
            nextButton1.Focus();
            welcomeRichTextBox1.Visible = true;
            exitButton1.Visible = true;
            resultsButton1.Visible = false;
            welcomeRichTextBox1.Text = "Вам подходит:\n";

            // Значение currentGroup берется на 1 больше, чем следует, потому что мы уже фактически перешли
            // к следующей группе, просто не показываем вопрос, а тормозим и выдаем результат
            if (currentGroup == 1)
            {               
                welcomeRichTextBox1.Text += "Бодибилдинг с уверенностью " + (float)first/100 + "\n";
                welcomeRichTextBox1.Text += "Тяжелая атлетика, метание ядра и пауэрлифтинг с уверенностью " + (float)second / 100 + "\n";                
            }
            else if (currentGroup == 2)
            {
                welcomeRichTextBox1.Text += "Плавание, дайвинг с уверенностью " + (float)first / 100 + "\n";
                welcomeRichTextBox1.Text += "Скалолазание, альпинизм с уверенностью " + (float)second / 100 + "\n";
                welcomeRichTextBox1.Text += "Гребля с уверенностью " + (float)third / 100 + "\n";
            }
            else if (currentGroup == 3)
            {
                welcomeRichTextBox1.Text += "Легкая атлетика, лыжный спорт с уверенностью " + (float)first / 100 + "\n";
                welcomeRichTextBox1.Text += "Велоспорт с уверенностью " + (float)second / 100 + "\n";
                welcomeRichTextBox1.Text += "Роликовый, коньковый спорт с уверенностью " + (float)(first+third) / 100 + "\n";
            }
            else if (currentGroup == 4)
            {
                welcomeRichTextBox1.Text += "Восточные боевые искусства с уверенностью " + (float)first / 100 + "\n";
                welcomeRichTextBox1.Text += "Бокс, кикбоксинг с уверенностью " + (float)second / 100 + "\n";
            }
            else if (currentGroup == 5)
            {
                welcomeRichTextBox1.Text += "Футбол с уверенностью " + (float)first / 100 + "\n";
                welcomeRichTextBox1.Text += "Хоккей с уверенностью " + (float)second / 100 + "\n";
                welcomeRichTextBox1.Text += "Баскетбол с уверенностью " + (float)third / 100 + "\n";
            }
            else if (currentGroup == 6)
            {
                welcomeRichTextBox1.Text += "Теннис, бейсбол, бадминтон с уверенностью " + (float)first / 100 + "\n";
            }
            else if (currentGroup == 7)
            {
                welcomeRichTextBox1.Text += "бильярд, гольф, боулинг, стрельба, пейнтбол, фехтование с уверенностью " + (float)first / 100 + "\n";                
            }
            else if (currentGroup == 8)
            {
                welcomeRichTextBox1.Text += "Парусный спорт с уверенностью " + (float)first / 100 + "\n";
                welcomeRichTextBox1.Text += "Парашутный спорт с уверенностью " + (float)second / 100 + "\n";
                welcomeRichTextBox1.Text += "Автогонки с уверенностью " + (float)third / 100 + "\n";
            }
            else if (currentGroup == 9)
            {
                welcomeRichTextBox1.Text += "Домино, карты с уверенностью " + (float)first / 100 + "\n";
                welcomeRichTextBox1.Text += "Шахматы, шашки, го с уверенностью " + (float)second / 100 + "\n";
            }

            welcomeRichTextBox1.Text += "Вы можете продолжить тест нажав Далее\n";
            first = 0;
            second = 0;
            third = 0;

            if (currentGroup == 10)
            {
                nextButton1.Visible = false;
                welcomeRichTextBox1.Text = "Вероятно, Вам следует попробовать укрепляющие виды спорта, такие, как йога, фитнесс, шейпинг и аэробика";
            }
        }

        // ---------------------------------------------------------------------------------------
        // Функция перехода к следующей группе
        //
        private void MoveToNextGroup(int skipResults)
        {
            if (skipResults != 1)
            {
                resultsButton1.Visible = true;
                nextButton1.Visible = false;
            }

            if (currentGroup + 1 < groups.Count())
            {                  
                questionEl = node.Document.Element("root").Element(groups[++currentGroup]).Element("question");
            }
            else
            {
                ++currentGroup;
                ShowResult();
            }           
        }

        // ---------------------------------------------------------------------------------------
        // Функция вывода очередного вопроса
        //
        private void ShowQuestion()
        {
            questionLabel1.Text = questionEl.Attribute("text").Value;

            if (radioButtons != null)                           // Если кнопки уже существуют 
            {
                for (int j = 0; j != radioButtons.Count(); j++)
                {
                    this.Controls.Remove(radioButtons[j]);      // Удаляем предыдущие кнопки с панели
                }
            }
            // Создаем новый набор кнопок
            radioButtons = new System.Windows.Forms.RadioButton[questionEl.Elements().Count()];

            int i = 0;
            foreach (XElement element in questionEl.Elements())
            {
                radioButtons[i] = new RadioButton();
                radioButtons[i].Text = element.Attribute("text").Value;
                radioButtons[i].UseCompatibleTextRendering = true;
                radioButtons[i].Width = this.Width - 58;
                radioButtons[i].Height = 20;
                radioButtons[i].Location = new System.Drawing.Point(58, 69 + i * 30);
                this.Controls.Add(radioButtons[i]);
                ++i;
            }
            radioButtons[0].Checked = true;
        }

        // ---------------------------------------------------------------------------------------
        // Функция обработки нажатия кнопки "Далее"
        //
        private void nextButton1_Click(object sender, EventArgs e)
        {
            welcomeRichTextBox1.Visible = false;
            exitButton1.Visible = false;
            int answer = 0;
            
            // Смотрим, нужно ли идти по веткам, или по основному пути
            if (radioButtons != null)
            {
                for (int i = 0; i != radioButtons.Count(); i++)
                {
                    if (radioButtons[i].Checked)
                    {
                        answer = i;
                    }
                }
                // Для вопросов из группы basic
                if (prevQuestionEl.Elements().ElementAt(answer).Attribute("health") != null)
                {
                    health += Int32.Parse(prevQuestionEl.Elements().ElementAt(answer).Attribute("health").Value);
                }
                // Для вопросов из остальных групп 
                if (prevQuestionEl.Elements().ElementAt(answer).Attribute("first") != null)
                {
                    first += Int32.Parse(prevQuestionEl.Elements().ElementAt(answer).Attribute("first").Value);
                }
                if (prevQuestionEl.Elements().ElementAt(answer).Attribute("second") != null)
                {
                    second += Int32.Parse(prevQuestionEl.Elements().ElementAt(answer).Attribute("second").Value);
                }
                if (prevQuestionEl.Elements().ElementAt(answer).Attribute("third") != null)
                {
                    third += Int32.Parse(prevQuestionEl.Elements().ElementAt(answer).Attribute("third").Value);
                }

                // Уровень ответа на пред вопрос
                answerLvl = prevQuestionEl.Elements().ElementAt(answer).Attribute("level").Value;

                if (answerLvl != "-1")
                {   // Ищем вопрос с подходящим уровнем
                    while (questionEl.Attribute("level").Value != answerLvl)
                    {   
                        if (questionEl.ElementsAfterSelf().Count() != 0)
                        {
                            questionEl = questionEl.ElementsAfterSelf().First();
                        }
                        else    // Если такого нет, идем к следующей группе
                        {
                            MoveToNextGroup(0);
                        }
                    }
                }   
                else    // -1 означает, что дальше по группе спрашивать бессмысленно
                {
                    first = 0;
                    second = 0;
                    third = 0; 
                    MoveToNextGroup(1);
                }
            }

            ShowQuestion();
            prevQuestionEl = questionEl;        // Запомним вопрос, на который ответили

            // Двигаемся к следующему вопросу
            if (questionEl.ElementsAfterSelf().Count() != 0)
            {
                questionEl = questionEl.ElementsAfterSelf().First();             
            }
            else // Закончились вопросы в группе
            {
                // Вызов промежуточного или финального обработчика
                if (questionEl.Parent.Name == "basic")
                {
                    MakeGroupChoice();
                }
                else
                {
                    MoveToNextGroup(0);
                }
            }
        }

        // ---------------------------------------------------------------------------------------
        // Функция обработки нажатия кнопки "Выход"
        //
        private void exitButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        // ---------------------------------------------------------------------------------------
        // Функция обработки нажатия кнопки "Показать результаты"
        //
        private void resultsButton1_Click(object sender, EventArgs e)
        {
            // Это тоже надо сделать, иначе потеряется значение последнего ответа
            int answer = 0;
            for (int i = 0; i != radioButtons.Count(); i++)
            {
                if (radioButtons[i].Checked)
                {
                    answer = i;
                }
            } 
            
            if (prevQuestionEl.Elements().ElementAt(answer).Attribute("first") != null)
            {
                first += Int32.Parse(prevQuestionEl.Elements().ElementAt(answer).Attribute("first").Value);
            }
            if (prevQuestionEl.Elements().ElementAt(answer).Attribute("second") != null)
            {
                second += Int32.Parse(prevQuestionEl.Elements().ElementAt(answer).Attribute("second").Value);
            }
            if (prevQuestionEl.Elements().ElementAt(answer).Attribute("third") != null)
            {
                third += Int32.Parse(prevQuestionEl.Elements().ElementAt(answer).Attribute("third").Value);
            } 
            
            ShowResult();
        }
    }
}
