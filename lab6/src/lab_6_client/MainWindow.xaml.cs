using lab_6_client.StudentNotesModifyService;
using System;
using System.Data.Services.Client;
using System.Linq;
using System.Windows;
using WsKakModel;

namespace lab_6_client
{
    public partial class MainWindow : Window
    {
        private readonly Uri _serviceUrl = new Uri("http://localhost:58061/StudentNotes.svc");
        private readonly StudentNotesModifyClient _modifyConnection = new StudentNotesModifyClient("http");
        private readonly WsKakEntities _entities;

        public MainWindow()
        {
            _entities = new WsKakEntities(_serviceUrl);
            InitializeComponent();
        }

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
                // using Data Service to add student
                {
                    _entities.AddToStudents(new Student { Name = InsertValue.Text });
                    _entities.SaveChanges();
                }

                // using custom WCF service to add student
                {
                    //_modifyConnection.Insert(InsertValue.Text);
                }

                InsertValue.Text = string.Empty;
            }
        }

        private void OnUpdateStudent(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(UpdateIdValue.Text, out var studentId) && !string.IsNullOrWhiteSpace(UpdateNameValue.Text))
            {
                // using Data Service to update student
                {
                    var student = _entities.Students.Where(x => x.Id == studentId).First();
                    if (student == null) return;

                    student.Name = UpdateNameValue.Text;

                    _entities.UpdateObject(student);
                    _entities.SaveChanges();
                }

                // using another WCF service to update student
                {
                    //_modifyConnection.Update(studentId, UpdateNameValue.Text);
                }

                UpdateIdValue.Text = string.Empty;
                UpdateNameValue.Text = string.Empty;
            }
        }
    }
}
