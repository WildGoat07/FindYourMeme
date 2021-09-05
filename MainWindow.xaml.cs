using Google.Apis.Customsearch.v1.Data;
using Hardcodet.Wpf.TaskbarNotification;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FindYourMeme
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty SearchingProperty = DependencyProperty.Register(
            nameof(Searching),
            typeof(bool),
            typeof(MainWindow),
            new PropertyMetadata(false));

        public static readonly DependencyProperty SearchTextProperty = DependencyProperty.Register(
                    nameof(SearchText),
            typeof(string),
            typeof(MainWindow),
            new PropertyMetadata(""));

        public static RoutedCommand ShowWindowCommand = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        public ObservableCollection<Result> Results { get; } = new();

        public bool Searching
        {
            get => (bool)GetValue(SearchingProperty);
            set => SetValue(SearchingProperty, value);
        }

        public string SearchText
        {
            get => (string)GetValue(SearchTextProperty);
            set => SetValue(SearchTextProperty, value);
        }

        private void CanShowWindow(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Visibility == Visibility.Collapsed;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CopyLinkButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var result = (Result)button.DataContext;
            Clipboard.SetText(result.Link);
        }

        private void HideButton_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }

        private async Task Search()
        {
            if (Searching)
                return;
            Searching = true;
            try
            {
                if (!string.IsNullOrWhiteSpace(SearchText))
                {
                    App.Request.Q = SearchText;
                    Results.Clear();
                    foreach (var item in (await App.Request.ExecuteAsync()).Items)
                        Results.Add(item);
                }
                Searching = false;
            }
            catch (Exception)
            {
                Searching = false;
            }
        }

        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            await Search();
        }

        private void ShowWindow(object sender, ExecutedRoutedEventArgs e)
        {
            Visibility = Visibility.Visible;
        }

        private async void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
                await Search();
        }
    }
}