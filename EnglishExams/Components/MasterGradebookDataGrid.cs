using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using EnglishExams.Models;

namespace EnglishExams.Components
{
    public class MasterGradebookDataGrid : DataGrid
    {
        public ObservableCollection<TestKey> ColumnHeaders
        {
            get => GetValue(ColumnHeadersProperty) as ObservableCollection<TestKey>;
            set => SetValue(ColumnHeadersProperty, value);
        }

        public static readonly DependencyProperty ColumnHeadersProperty = 
            DependencyProperty.Register(nameof(ColumnHeaders), 
                typeof(ObservableCollection<TestKey>),
                typeof(MasterGradebookDataGrid), 
                new PropertyMetadata(OnColumnsChanged));

        static void OnColumnsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var dataGrid = d as MasterGradebookDataGrid;

            dataGrid.Columns.Clear();

            dataGrid.Columns.Add(new DataGridTextColumn
            {
                Header = nameof(MasterGradebookTestResultModel.UserName),
                Binding = new Binding(nameof(MasterGradebookTestResultModel.UserName))
            });

            if (dataGrid.ColumnHeaders is null)
            {
                return;
            }

            foreach (var value in dataGrid.ColumnHeaders)
            {
                var column = new DataGridTextColumn
                {
                    Header = string.Concat(value.UnitName, 
                                           " - ", 
                                           value.LessonName),
                    
                    Binding = new Binding(nameof(MasterGradebookTestResultModel.Results))
                    {
                        ConverterParameter = value,
                        Converter = new MasterGradebookTestResultModelConverter(), 
                    }
                };

                dataGrid.Columns.Add(column);
            }
        }

        private class MasterGradebookTestResultModelConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                double result = default;

                var concreteUserGradebook = value as IEnumerable<GradebookTestResultModel>;

                if (!(value is null) && !(parameter is null))
                {
                    var concreteParam = parameter as TestKey;

                    var gradebook = concreteUserGradebook.FirstOrDefault(g => g == concreteParam);

                    if (gradebook != null)
                    {
                        result = gradebook.Points;
                    }
                }

                return result;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }

}