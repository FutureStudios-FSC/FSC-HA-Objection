using Panuon.WPF;
using Panuon.WPF.UI;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
using System.ComponentModel;

namespace Objection_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        string imgSource, audioSource, character;
        string path = Directory.GetCurrentDirectory();
        string imgPath, audioPath;

        public MainWindow()
        {
            InitializeComponent();
            img.Visibility = Visibility.Hidden;

            // 开发者项目的路径
            if (path == "C:\\Users\\86139\\source\\repos\\Objection!\\bin\\Debug\\net8.0-windows")
            {
                path = "C:\\Users\\86139\\source\\repos\\Objection!\\";
            }

            langCombo.SelectedIndex = 2;
            charCombo.SelectedIndex = 0;

            
        }

        private void langCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(langCombo.SelectedIndex)
            {
                case 0:
                    objection_.Content = "异议！";
                    break;
                case 1:
                    objection_.Content = "異議あり！";
                    break;
                case 2:
                    objection_.Content = "Objection!";
                    break;
            }
        }

        private void objection_复制__C__Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择要打开的文件";
            openFileDialog.Filter = "所有文件|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string content = openFileDialog.FileName;
                    Clipboard.SetText(content);
                }
                catch (IOException ex)
                {
                    // 处理文件读取错误
                    MessageBoxX.Show("无法读取文件，异常：\n" + ex, "无法读取文件", MessageBoxIcon.Error);
                }
            }
            
        }

        private void officialWebpage_Click(object sender, RoutedEventArgs e)
        {
            if(!Directory.Exists("C:\\Program Files (x86)\\Half-Auto OBJECTION!\\Objection! 文件"))
            {
                MessageBoxX.Show("文件夹不存在，\n您可以把文件解压到注释中的位置，\n然后再试。", "文件夹不存在",MessageBoxIcon.Warning);
            }
            else
            {
                MessageBoxX.Show("文件夹正常，\n未检查文件完整性。", "文件夹正常",MessageBoxIcon.Success) ;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxX.Show("可以在objection.lol的/Audio/分支里尝试\r\n获得音效素材，如：/Audio/Vocal/其中有\r\n角色的喊话内容、音效等。\r\n\r\nAudio/Vocal/（数字）可以得到上述素材。\r\n例如1是Objection，2是Hold It。","网络素材",MessageBoxIcon.Info);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            music.Source = new Uri(Convert.ToString("https://objection.lol/Audio/deskslam.mp3"));
            music.Position = TimeSpan.Zero;
            music.Play();
        }

        private void charCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (charCombo.SelectedIndex)
            {
                case 0:
                    character = "pw/";
                    break;
                case 1:
                    character = "me/";
                    break;
                case 2:
                    character = "mf/";
                    break;
                case 3:
                    character = "mvk/";
                    break;
                case 4:
                    character = "fvk/";
                    break;
                case 5:
                    character = "gd/";
                    break;
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            switch (langCombo.SelectedIndex)
            {
                case 0:
                    audioSource = "zh.mp3";
                    imgSource = "zh.png";
                    break;
                case 1:
                    audioSource = "ja.mp3";
                    imgSource = "ja.png";
                    break;
                case 2:
                    audioSource = "en.mp3";
                    imgSource = "en.png";
                    break;
            }


            // https://forms.office.com/r/8twGQ6K5Z7

            imgPath = path + "\\Files\\" + Convert.ToString(imgSource);
            audioPath = path + "\\Files\\Vocal\\" + character + Convert.ToString(audioSource);

            if (imgText.Text != string.Empty)
            {
                imgPath = imgText.Text;
            }
            if (audioText.Text != string.Empty)
            {
                audioPath = audioText.Text;
            }

            try
            {
                mediaElement.Volume = volume.Value;
                mediaElement.Position = TimeSpan.Zero;
                mediaElement.Source = new Uri(audioPath);
                mediaElement.Play();
                
                img.Source = new BitmapImage(new Uri(imgPath));
                img.Visibility = Visibility.Visible;
                await Task.Delay(1000);
                
                img.Visibility = Visibility.Hidden;

                
            }
            catch
            {
                if (urlAuto.IsChecked == true)
                {
                    string[] a = new string[3] { "http://", "https://", "" };
                    bool succeed = false;
                    for (int i = 0; i <= 2; i++)
                    {
                        for (int j = 0; i <= 2; i++)
                        {
                            try
                            {
                                mediaElement.Volume = volume.Value;
                                mediaElement.Position = TimeSpan.Zero;
                                mediaElement.Source = new Uri(a[i] + Convert.ToString(audioSource));
                                mediaElement.Play();
                                img.Source = new BitmapImage(new Uri(a[j] + Convert.ToString(imgSource)));
                                img.Visibility = Visibility.Visible;
                                await Task.Delay(1000);
                                img.Visibility = Visibility.Hidden;
                                succeed = true;
                                break;
                            }
                            catch
                            {
                                succeed = false;
                            }
                        }
                    }
                    if (succeed == false)
                    {
                        MessageBoxX.Show("自定义路径错误，\n请先按照说明解压，\n如果链接是URL，请检查格式！", "无法异议", MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBoxX.Show("自定义路径错误，\n请先按照说明解压，\n如果链接是URL，请不要忘记前缀", "无法异议", MessageBoxIcon.Error);
                }
            }
        }
    }
}