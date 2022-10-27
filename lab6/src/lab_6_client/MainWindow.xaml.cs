using lab_6_client.StudentNotesModifyService;
using System;
using System.Data.Services.Client;
using System.Windows;
using WsKakModel;

namespace lab_6_client
{
    public partial class MainWindow : Window
    {
        private readonly Uri _serviceUrl = new Uri("http://localhost:58061/StudentNotes.svc");
        private readonly StudentNotesModifyClient _modifyConnection = new StudentNotesModifyClient("http");

        public MainWindow() => InitializeComponent();

        public void OnGetStudentsClick(object sender, RoutedEventArgs e) => Exec(new WsKakEntities(_serviceUrl).Students);

        public void OnGetNotesClick(object sender, RoutedEventArgs e) => Exec(new WsKakEntities(_serviceUrl).Notes);

        private void Exec<T>(DataServiceQuery<T> serviceQuery)
        {
            Result.Text = string.Empty;

            if (!string.IsNullOrWhiteSpace(FilterColumn.Text) && !string.IsNullOrWhiteSpace(FilterValue.Text))
            {
                if (int.TryParse(FilterValue.Text, out var result))
                    serviceQuery = serviceQuery.AddQueryOption("$filter", $"{FilterColumn.Text} eq {result}");
                else
                    serviceQuery = serviceQuery.AddQueryOption("$filter", $"substringof('{FilterValue.Text}', {FilterColumn.Text})");
            }

            if (!string.IsNullOrWhiteSpace(OrderBy.Text))
                serviceQuery = serviceQuery.AddQueryOption("$orderby", OrderBy.Text);

            if (!string.IsNullOrWhiteSpace(Select.Text))
                serviceQuery = serviceQuery.AddQueryOption("$select", Select.Text);

            try
            {
                var queryResult = serviceQuery.Execute();

                foreach (var item in queryResult)
                {
                    if (item is Student student)
                        Result.Text += $"{student?.Id} - {student?.Name}\n";
                    else if (item is Note note)
                        Result.Text += $"{note?.Id} - {note?.Subject} \n\tОценка: {note?.Note1}\n\tID студента: {note?.StudentId}\n";
                }
            }
            catch (Exception ex)
            {
                Result.Text = ex.ToString();
            }
        }

        private void OnInsertStudent(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(InsertValue.Text))
            {
                _modifyConnection.Insert(InsertValue.Text);
                InsertValue.Text = string.Empty;
            }
        }

        private void OnUpdateStudent(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(UpdateIdValue.Text, out var studentId) && !string.IsNullOrWhiteSpace(UpdateNameValue.Text))
            {
                _modifyConnection.Update(studentId, UpdateNameValue.Text);
                UpdateIdValue.Text = string.Empty;
                UpdateNameValue.Text = string.Empty;
            }
        }
    }
}
