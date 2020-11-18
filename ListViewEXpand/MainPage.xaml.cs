using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListViewEXpand.Models;
using Xamarin.Forms;

namespace ListViewEXpand
{
    public partial class MainPage : ContentPage
    {

        private ObservableCollection<WorkoutGroup> _allGroups;
        private ObservableCollection<WorkoutGroup> _expandedGroups;

        public MainPage()
        {
            InitializeComponent();
            _allGroups = WorkoutGroup.All;
            UpdateListContent();
        }

        private void HeaderTapped(object sender, EventArgs args)
        {
            int selectedIndex = _expandedGroups.IndexOf(((WorkoutGroup)((Button)sender).CommandParameter));
            _allGroups[selectedIndex].Expanded = !_allGroups[selectedIndex].Expanded;
            UpdateListContent();
        }

        private void UpdateListContent()
        {
            _expandedGroups = new ObservableCollection<WorkoutGroup>();


            foreach (WorkoutGroup group in _allGroups)
            {
                //Create this new group with group above title,shortname, and if expanded
                WorkoutGroup newGroup = new WorkoutGroup(group.Title, group.ShortName, group.Expanded);

                //Set the count
                newGroup.WorkoutCount = group.Count;

                if (group.Expanded)
                {
                    foreach (Workout workout in group)
                    {
                        newGroup.Add(workout);
                    }
                }

                _expandedGroups.Add(newGroup);
            }

            GroupedView.ItemsSource = _expandedGroups;
        }
    }
}
