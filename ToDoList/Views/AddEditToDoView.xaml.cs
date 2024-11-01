﻿using MahApps.Metro.Controls;
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
using System.Windows.Shapes;
using ToDoList.Models;
using ToDoList.ViewModels;
using ToDoList.Models.Wrappers;

namespace ToDoList.Views
{
    /// <summary>
    /// Interaction logic for AddEditToDoView.xaml
    /// </summary>
    public partial class AddEditToDoView : MetroWindow
    {
        public AddEditToDoView(ToDoWrapper todo = null)
        {
            InitializeComponent();
            DataContext = new AddEditToDoViewModel(todo);
        }
    }
}
