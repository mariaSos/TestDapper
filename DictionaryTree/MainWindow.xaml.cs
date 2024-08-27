using DictionaryTree.DataAccess;
using DictionaryTree.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Linq;

namespace DictionaryTree
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var singIn = Task.Run(() => LoadJson.ReadAsync<CLib[]>(@"C:\KursCSharp\MyProj\DictionaryTree\others\TreeTest.json")).Result;

            List<CLib> list = new List<CLib>();
            /* DriveInfo[] drives = DriveInfo.GetDrives();
             foreach (DriveInfo driveInfo in drives)
                 trvStructure.Items.Add(CreateTreeItem(driveInfo));*/
            // trvStructure.DataContext = node;
            if (singIn != null)
            {
                foreach (CLib node in singIn)
                {
                    
                    trvStructure.Items.Add(CreateTreeItem(node));

                   

                }
            }





        }

        private TreeViewItem CreateTreeItem(CLib o)
        {
            TreeViewItem item = new TreeViewItem();

            item.Header = o.Caption;
            item.DataContext = o;
            item.Tag = o;
            if (o.CntLeafs > 0) 
            {
                item.Items.Add("Loading...");
            }
            return item;
        }

        public void TreeViewItem_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = e.Source as TreeViewItem;
            CLib cl = item.DataContext as CLib;
            // MessageBox.Show(item.Tag.ToString());


            if ((item.Items.Count == 1) && (item.Items[0] is string))
            {
                item.Items.Clear();

                CLib expandedDir;

                if (item.Tag is CLib)
                    expandedDir = (item.Tag as CLib);

                if (item.Tag is CLib)
                    expandedDir = (item.Tag as CLib);
                var singIn = Task.Run(() => LoadJson.ReadAsync<CLib[]>(@$"C:\KursCSharp\MyProj\DictionaryTree\others\TreeTest{cl.Id}.json")).Result;

                try
                {

                    foreach (CLib subNode in singIn)
                    {
                        
                        item.Items.Add(CreateTreeItem(subNode));

                       
                        }

                    }
                
                catch { }

                //   var singIn = Task.Run(() => LoadJson.ReadAsync<CLib[]>(@"C:\KursCSharp\MyProj\DictionaryTree\others\TreeTest.json")).Result;


               
            }
        }

        public void TreeViewItem_Selected(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = e.Source as TreeViewItem;
            CLib cl = item.DataContext as CLib;
            //MessageBox.Show(cl.CntLeafs.ToString());
            try
            {
                var singIn = Task.Run(() => LoadJson.ReadAsync<CLib[]>(@$"C:\KursCSharp\MyProj\DictionaryTree\others\TreeTest{cl.Id}.json")).Result;

                List<CLib> list = new List<CLib>();
                /* DriveInfo[] drives = DriveInfo.GetDrives();
                 foreach (DriveInfo driveInfo in drives)
                     trvStructure.Items.Add(CreateTreeItem(driveInfo));*/
                // trvStructure.DataContext = node;
                trvStructure2.Items.Clear();
                if (singIn != null)
                {
                    foreach (CLib node in singIn)
                    {

                        trvStructure2.Items.Add(CreateTreeItem(node));



                    }
                }
            }catch{ }

        }


    }

}
