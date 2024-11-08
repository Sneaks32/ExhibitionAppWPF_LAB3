using ExhibitionAppWPF;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ExhibitionAppWPF
{
	public partial class MainWindow : Window
	{
		private List<Floor> floors;

		public MainWindow()
		{
			InitializeComponent();
			floors = DataManager.LoadData();
			LoadFloors();
		}

		private void LoadFloors()
		{
			FloorComboBox.Items.Clear();
			foreach (var floor in floors)
			{
				FloorComboBox.Items.Add(floor.FloorNumber);
			}
		}

		private void FloorComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (FloorComboBox.SelectedItem != null)
			{
				int selectedFloorNumber = (int)FloorComboBox.SelectedItem;
				var selectedFloor = floors.Find(f => f.FloorNumber == selectedFloorNumber);
				LoadHalls(selectedFloor);
			}
		}

		private void LoadHalls(Floor selectedFloor)
		{
			HallComboBox.Items.Clear();
			foreach (var hall in selectedFloor.Halls)
			{
				HallComboBox.Items.Add(hall.HallName);
			}
		}

		private void HallComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (HallComboBox.SelectedItem != null)
			{
				var selectedFloorNumber = (int)FloorComboBox.SelectedItem;
				var selectedFloor = floors.Find(f => f.FloorNumber == selectedFloorNumber);
				var selectedHallName = (string)HallComboBox.SelectedItem;
				var selectedHall = selectedFloor.Halls.Find(h => h.HallName == selectedHallName);
				DisplayExhibitDetails(selectedHall);
			}
		}

		private void DisplayExhibitDetails(Hall selectedHall)
		{
			string exhibitDetails = "Exhibits:\n";
			foreach (var exhibit in selectedHall.Exhibits)
			{
				exhibitDetails += $"Name: {exhibit.Name}\nDescription: {exhibit.Description}\nYear: {exhibit.Year}\nAuthor: {exhibit.Author}\n\n";
			}
			ExhibitDetailsTextBlock.Text = exhibitDetails;
		}
	}
}
