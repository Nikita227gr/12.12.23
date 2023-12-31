﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace nikitka
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public Label TextBlockAnswer;
        public Entry TbNumberA, TbNumberB, TbNumberC;
        public Page2()
        {
            Grid grid = new Grid
            {
                RowSpacing = 5,
                RowDefinitions =
                {
                    new RowDefinition {Height = 50},
                    new RowDefinition {Height = 50},
                    new RowDefinition {Height = 50},
                    new RowDefinition {Height = 50},
                    new RowDefinition {Height = 50},
                    new RowDefinition {Height = 50},
                    new RowDefinition {},
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition {Width = 105},
                    new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
                }
            };
            Label title = new Label()
            {
                Text = "Задание 3",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                Margin = 10,
                HorizontalOptions = LayoutOptions.Center
            };
            Label TextA = new Label()
            {
                Text = "Число A",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                Margin = 10
            };
            Label TextB = new Label()
            {
                Text = "Число B",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                Margin = 10
            };
            Label TextC = new Label()
            {
                Text = "Число C",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                Margin = 10
            };
            TextBlockAnswer = new Label()
            {
                Text = "Ответ: ",
                FontSize = 20,
                Margin = 10
            };
            grid.Children.Add(title, 0, 0);
            Grid.SetColumnSpan(title, 2);
            grid.Children.Add(TextA, 0, 1);
            grid.Children.Add(TextB, 0, 2);
            grid.Children.Add(TextC, 0, 3);
            grid.Children.Add(TextBlockAnswer, 0, 4);
            Grid.SetColumnSpan(TextBlockAnswer, 2);
            TbNumberA = new Entry();
            TbNumberB = new Entry();
            TbNumberC = new Entry();
            grid.Children.Add(TbNumberA, 1, 1);
            grid.Children.Add(TbNumberB, 1, 2);
            grid.Children.Add(TbNumberC, 1, 3);
            StackLayout stackLayout1 = new StackLayout();
            stackLayout1.Orientation = StackOrientation.Horizontal;
            stackLayout1.HorizontalOptions = LayoutOptions.Center;
            StackLayout st = new StackLayout();
            st.Orientation = StackOrientation.Horizontal;
            st.HorizontalOptions = LayoutOptions.Center;
            Button BtnOK = new Button()
            {
                Text = "OK"
            };
            BtnOK.Clicked += BtnOK_Clicked;

            Button BtnNext = new Button()
            {
                Text = "Следующая страница"

            };
            BtnNext.VerticalOptions = LayoutOptions.End;
            BtnNext.Clicked += BtnNext_Clicked;
            stackLayout1.Children.Add(BtnOK);
            st.Children.Add(BtnNext);
            grid.Children.Add(stackLayout1, 0, 5);
            grid.Children.Add(st, 0, 6);
            Grid.SetColumnSpan(stackLayout1, 2);
            Grid.SetColumnSpan(st, 2);
            Content = grid;
        }

        private async void BtnNext_Clicked(object sender, EventArgs e)
        {
            Page pg = new Page3();
            await Navigation.PushAsync(pg);
        }

        private void BtnOK_Clicked(object sender, EventArgs e)
        {
            int A = int.Parse(TbNumberA.Text);
            int B = int.Parse(TbNumberB.Text);
            int C = int.Parse(TbNumberC.Text);
            TextBlockAnswer.Text = "Ответ: ";
            if (A < B)
            {
                if (B < C)
                {
                    TextBlockAnswer.Text += "Наименьшее число: " + A;
                    TextBlockAnswer.Text += "; Наибольшее число: " + C;
                }
                else if (A < C)
                {
                    TextBlockAnswer.Text += "Наименьшее число: " + A;
                    TextBlockAnswer.Text += "; Наибольшее число: " + B;
                }
                else
                {
                    TextBlockAnswer.Text += "Наименьшее число: " + C;
                    TextBlockAnswer.Text += "; Наибольшее число: " + B;
                }
            }
            else
            {
                if (B > C)
                {
                    TextBlockAnswer.Text += "Наименьшее число: " + C;
                    TextBlockAnswer.Text += "; Наибольшее число: " + A;
                }
                else if (A < C)
                {
                    TextBlockAnswer.Text += "Наименьшее число: " + B;
                    TextBlockAnswer.Text += "; Наибольшее число: " + C;
                }
                else
                {
                    TextBlockAnswer.Text += "Наименьшее число: " + B;
                    TextBlockAnswer.Text += "; Наибольшее число: " + A;
                }
            }
        }
    }
}