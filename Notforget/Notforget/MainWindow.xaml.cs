using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Notforget
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        //定義儲存路徑
        string FilePath = "";

        List<string> all = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            //新增一個Rectangle
            ToDoItem item = new ToDoItem();

            //放到ToDoList
            ToDoList.Children.Add(item);
        }

        //Date Task按鈕
        private void DateBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DateBlock.Background = Brushes.White;
            TaskBlock.Background = Brushes.Gray;

           
            // 產生開啟檔案視窗 OpenFileDialog 
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();

            // 顯示視窗
            Nullable<bool> result = dlg.ShowDialog();
             
            foreach (ToDoItem item in ToDoList.Children)
            {
                all.Add(item.GetTaskText());
            }


            // 當按下開啟之後的反應 
            if (result == true)
            {                            
                // 取得檔案路徑 
                FilePath = dlg.FileName;

                // 儲存檔案
                System.IO.File.WriteAllLines(FilePath,all);

            }
        }

        private void TaskBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DateBlock.Background = Brushes.Gray;
            TaskBlock.Background = Brushes.White;

        }
    }
}
