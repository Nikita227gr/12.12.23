﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Math;

namespace nikitka
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page4 : ContentPage
    {
        public Label TextBlockAnswer;
        public Entry TbNumberA, TbNumberB;
        public Page4()
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
                Text = "Задание 5",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                Margin = 10,
                HorizontalOptions = LayoutOptions.Center
            };
            Label TextA = new Label()
            {
                Text = "Число X",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                Margin = 10
            };
            Label TextB = new Label()
            {
                Text = "Число Y",
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
            Image image = new Image();
            image.Source = ImageSource.FromFile("image.png");
            grid.Children.Add(image, 0, 1);
            grid.Children.Add(title, 0, 0);
            Grid.SetColumnSpan(title, 2);
            grid.Children.Add(TextA, 0, 2); //A
            grid.Children.Add(TextB, 0, 3); //B
            grid.Children.Add(TextBlockAnswer, 0, 4); //Ответ текст
            Grid.SetColumnSpan(TextBlockAnswer, 2);
            TbNumberA = new Entry();
            TbNumberB = new Entry();
            grid.Children.Add(TbNumberA, 1, 2); //Ввод
            grid.Children.Add(TbNumberB, 1, 3);
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
            grid.Children.Add(stackLayout1, 0, 5); //Кнопка ок
            grid.Children.Add(st, 0, 6); //Кнопка след
            Grid.SetColumnSpan(stackLayout1, 2);
            Grid.SetColumnSpan(st, 2);
            Content = grid;
        }

        private async void BtnNext_Clicked(object sender, EventArgs e)
        {
            Page pg = new Page2();
            await Navigation.PushAsync(pg);
        }

        private void BtnOK_Clicked(object sender, EventArgs e)
        {
            int X = int.Parse(TbNumberA.Text);
            int Y = int.Parse(TbNumberB.Text);
            if (Pow(X-0,2) + Pow(Y-0,2) <= Pow(10,2) && Y >= -X)
            {
                TextBlockAnswer.Text = "Ответ: Да";
                if (Pow(X - 0, 2) + Pow(Y - 0, 2) == Pow(10, 2) || Y == -X)
                {
                    TextBlockAnswer.Text = "Ответ: На границе";
                }
            }
            else
            {
                TextBlockAnswer.Text = "Ответ: Нет";
            }
        }
    }
}