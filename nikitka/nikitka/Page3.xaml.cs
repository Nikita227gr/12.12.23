using System;
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
    public partial class Page3 : ContentPage
    {
        public Label TextBlockAnswer;
        public Entry TbNumberA;
        public Page3()
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
                Text = "Задание 4",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                Margin = 10,
                HorizontalOptions = LayoutOptions.Center
            };
            Label TextA = new Label()
            {
                Text = "Число x",
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
            grid.Children.Add(TextA, 0, 1); //A
            grid.Children.Add(TextBlockAnswer, 0, 2); //Ответ текст
            Grid.SetColumnSpan(TextBlockAnswer, 2);
            TbNumberA = new Entry();
            grid.Children.Add(TbNumberA, 1, 1);
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
            grid.Children.Add(stackLayout1, 0, 3); //Кнопка ок
            grid.Children.Add(st, 0, 5); //Кнопка след
            Grid.SetColumnSpan(stackLayout1, 2);
            Grid.SetColumnSpan(st, 2);
            Content = grid;
        }

        private async void BtnNext_Clicked(object sender, EventArgs e)
        {
            Page pg = new Page4();
            await Navigation.PushAsync(pg);
        }

        private void BtnOK_Clicked(object sender, EventArgs e)
        {
            double x = double.Parse(TbNumberA.Text);
            double y = 0;
            if(x < 0)
            {
                y = Pow(x, 5) - 10 - Pow(PI + x, 1 / 4);
            }
            else if (x >= 1)
            {
                y = x * (Pow(x, 4) + 3 * x) + Log(PI + x);
            }
            else
            {
                y = Pow((Pow(x, 3) + 3), 3) - Sqrt(0.5 * PI + x);
            }
            TextBlockAnswer.Text = $"Ответ: {y}";
        }
    }
}