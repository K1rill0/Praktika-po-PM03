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

namespace StateControl.Desktop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Entities.WorldSkillsEntities _context = new Entities.WorldSkillsEntities();
        private List<PseudoEnt> _pseudoEnts = new List<PseudoEnt>();

        public MainWindow()
        {
            InitializeComponent();

            var rnd = new Random();
            _context.Equipment.ToList().ForEach(x =>
            {
                _pseudoEnts.Add(new PseudoEnt()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Type = (Type)rnd.Next(3),
                    IsWorking = rnd.Next(512) > 256
                });
            });


            MagistralEquipment.ItemsSource = _pseudoEnts.Where(x => x.Type == Type.Magistral);
            AccessEquipment.ItemsSource = _pseudoEnts.Where(x => x.Type == Type.Access);
            ClientEquipment.ItemsSource = _pseudoEnts.Where(x => x.Type == Type.Client);
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < MagistralEquipment.Items.Count; i++)
            {
                var item = MagistralEquipment.ItemContainerGenerator.ContainerFromIndex(i) as ListViewItem;
                if (item == null)
                {
                    continue;
                }

                item.Background = ((PseudoEnt)item.Content).IsWorking ? Brushes.Green : Brushes.Red;
            }

            for (int i = 0; i < AccessEquipment.Items.Count; i++)
            {
                var item = AccessEquipment.ItemContainerGenerator.ContainerFromIndex(i) as ListViewItem;
                if (item == null)
                {
                    continue;
                }

                item.Background = ((PseudoEnt)item.Content).IsWorking ? Brushes.Green : Brushes.Red;
            }

            for (int i = 0; i < ClientEquipment.Items.Count; i++)
            {
                var item = ClientEquipment.ItemContainerGenerator.ContainerFromIndex(i) as ListViewItem;
                if (item == null)
                {
                    continue;
                }

                item.Background = ((PseudoEnt)item.Content).IsWorking ? Brushes.Green : Brushes.Red;
            }
        }

        private class PseudoEnt : Entities.Equipment
        {
            public Type Type { get; set; }

            public bool IsWorking { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        private enum Type
        {
            Magistral = 0,
            Access,
            Client
        }
    }
}
