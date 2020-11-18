using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ListViewEXpand.Models;

namespace ListViewEXpand
{
    public class WorkoutGroup : ObservableCollection<Workout>, INotifyPropertyChanged
    {
        private bool _expanded;

        public bool Expanded
        {
            get { return _expanded; }

            set { if (_expanded != value)
                {
                    _expanded = value;
                    OnPropertyChanged("Expanded");
                    OnPropertyChanged("StateIcon");
                }
            }
        }
        public string Title { get; set; }

        //Different icons for if Expanded true or false 
        public string StateIcon
        {
            get { return Expanded ? "" : ""; }
        }

        public string TitleWithItemCount
        {
            get { return string.Format("{0} ({1})", Title, FoodCount); }
        }

        public string ShortName { get; set; }

        public int FoodCount { get; set; }



        public WorkoutGroup(string title, string shortName, bool expanded = false)
        {
            Title = title;
            ShortName = shortName;
            Expanded = expanded;
        }
        public static ObservableCollection<WorkoutGroup> All { private set; get; }
        static WorkoutGroup()
        {
            ObservableCollection<WorkoutGroup> Groups = new ObservableCollection<WorkoutGroup>
            {
                new WorkoutGroup("Hitting","H")
                {
                    new Workout{Name="Tee Drill", Description="Hit on the tee",Icon="" },
                     new Workout{Name="Soft Toss", Description="Softly toss the ball from the side",Icon=""  },
                      new Workout{ Name="Front Toss", Description="Softly toss behind the L screen directly in fornt of the hitter",Icon="" },
                    new Workout{Name="BP", Description="Regular ole' BP",Icon=""  }
                },
                new WorkoutGroup("Fielding","F")
                {
                    new Workout{Name="Middle Inf", Description="Footwork",Icon=""  },
                     new Workout{Name="Outfield", Description="Footwork",Icon=""  },
                      new Workout{Name="Reads", Description="Outfield reads",Icon=""  },
                    new Workout{ Name="1st base", Description="Basic work",Icon="" }
                },
                new WorkoutGroup("Pitching","P")
                {
                    new Workout{Name="Strecth", Description="Pitching from the stretch",Icon=""  },
                     new Workout{Name="Windup", Description="Pitching from the windup",Icon=""  },
                      new Workout{Name="Pickoff", Description="Picking off baserunners",Icon=""  }
                }
            };
            All = Groups;
        }
        //TODO: move this elsewhere
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
