using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp21
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Начальный путь (корневые диски)
            string initialPath = @"C:\";

            // Установка начального пути в TextBox
            textBox1.Text = initialPath;

            // Заполнение ListView файлами и папками из начального пути
            LoadDirectory(initialPath);
        }

        private void LoadDirectory(string path)
        {
            // Очистка ListView
            listView1.Items.Clear();

            try
            {
                // Получение списка файлов и папок в указанной директории
                string[] directories = Directory.GetDirectories(path);
                string[] files = Directory.GetFiles(path);

                // Добавление папок
                foreach (string directory in directories)
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(directory);
                    ListViewItem item = new ListViewItem(dirInfo.Name);
                    item.SubItems.Add("Папка");
                    item.SubItems.Add(dirInfo.LastWriteTime.ToString());
                    listView1.Items.Add(item);
                }

                // Добавление файлов
                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    ListViewItem item = new ListViewItem(fileInfo.Name);
                    item.SubItems.Add("Файл");
                    item.SubItems.Add(fileInfo.LastWriteTime.ToString());
                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при загрузке директории: " + ex.Message);
            }
        }

        private void btnBrowse_Click_1(object sender, EventArgs e)
        {
            // Открыть диалоговое окно выбора папки
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                // Установка выбранного пути в TextBox
                textBox1.Text = folderBrowserDialog.SelectedPath;

                // Загрузка файлов и папок из выбранной папки
                LoadDirectory(folderBrowserDialog.SelectedPath);
            }
        }
    }
}
