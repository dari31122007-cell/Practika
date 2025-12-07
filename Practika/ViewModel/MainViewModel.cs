using Practika.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practika.ViewModel
{
    internal class MainViewModel
    {
        public ObservableCollection<action_logs> action_Logs { get; set; }
        public ObservableCollection<body_type> body_type { get; set; }
        public ObservableCollection<brands> brands { get; set; }
        public ObservableCollection<cars> cars { get; set; }
        public ObservableCollection<car_images> car_images { get; set; }
        public ObservableCollection<categories> categories { get; set; }
        public ObservableCollection<color> color { get; set; }
        public ObservableCollection<engine_type> engine_type { get; set; }
        public ObservableCollection<favorites> favorites { get; set; }
        public ObservableCollection<messages> messages { get; set; }
        public ObservableCollection<models> models { get; set; }
        public ObservableCollection<orders> orders { get; set; }
        public ObservableCollection<reviews> reviews { get; set; }
        public ObservableCollection<roles> roles { get; set; }
        public ObservableCollection<status> status { get; set; }
        public ObservableCollection<transmission> transmission { get; set; }
        public ObservableCollection<users> users { get; set; }
        public MainViewModel()
        {
            LoadData();
        }
        private void LoadData()
        {
            using (var context = new AppDbContext())
            {
                
            }
        }
    }
}
